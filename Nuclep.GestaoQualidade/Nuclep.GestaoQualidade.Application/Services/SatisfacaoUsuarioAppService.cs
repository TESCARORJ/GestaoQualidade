using AutoMapper;
using Microsoft.AspNetCore.Http;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Helpers;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Application.Interfaces.Sistema;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using Nuclep.GestaoQualidade.Domain.Services;
using Nuclep.GestaoQualidade.SqlServer.Repositories;
using System.Globalization;
using System.Transactions;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class SatisfacaoUsuarioAppService : ISatisfacaoUsuarioAppService
    {
        private readonly ISatisfacaoUsuarioDomainService _satisfacaoUsuarioDomainService;
        private readonly ISatisfacaoUsuarioMetaDomainService _satisfacaoUsuarioMetaDomainService;
        private readonly ISatisfacaoUsuarioMetaRepository _satisfacaoUsuarioMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly ISatisfacaoUsuarioRepository _satisfacaoUsuarioRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public SatisfacaoUsuarioAppService(
            ISatisfacaoUsuarioDomainService satisfacaoUsuarioDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            ISatisfacaoUsuarioMetaDomainService satisfacaoUsuarioMetaDomainService,
            ISatisfacaoUsuarioMetaRepository satisfacaoUsuarioMetaRepository,
            ISatisfacaoUsuarioRepository satisfacaoUsuarioRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _satisfacaoUsuarioDomainService = satisfacaoUsuarioDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _satisfacaoUsuarioMetaDomainService = satisfacaoUsuarioMetaDomainService;
            _satisfacaoUsuarioMetaRepository = satisfacaoUsuarioMetaRepository;
            _satisfacaoUsuarioRepository = satisfacaoUsuarioRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<SatisfacaoUsuario> satisfacaoUsuarioList = new List<SatisfacaoUsuario>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var satisfacaoUsuarioCount = _satisfacaoUsuarioDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoSatisfacaoUsuarioList = _satisfacaoUsuarioDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _satisfacaoUsuarioMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _satisfacaoUsuarioRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsSatisfacaoUsuario)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoSatisfacaoUsuarioList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            SatisfacaoUsuario satisfacaoUsuario = new SatisfacaoUsuario
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            satisfacaoUsuarioList.Add(satisfacaoUsuario);
                        }
                    }
                }
            }

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var logs = new List<LogCrud>();
                var log = new LogCrud()
                {
                    IdReferencia = usuarioLogado.Id,
                    DataHoraCadastro = DateTime.Now,
                    UsuarioId = usuarioLogado.Id,
                    UsuarioNome = usuarioLogado.Nome,
                    LogTipo = LogTipo.Cadastrado,
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_SatisfacaoUsuario").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Satisfação de Usuario para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _satisfacaoUsuarioDomainService.AddListAsync(satisfacaoUsuarioList);

                transaction.Complete();

            }
        }

        public async Task<SatisfacaoUsuarioResponseDTO> UpdateAsync(long id, SatisfacaoUsuarioRequestDTO request)
        {
            var model = _mapper.Map<SatisfacaoUsuario>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_SatisfacaoUsuario");

            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var item in await logs)
                    {
                        item.IdReferencia = model.Id;
                        await _logCrudRepository.AddAsync(item);
                    }

                    var result = await _satisfacaoUsuarioDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<SatisfacaoUsuarioResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<SatisfacaoUsuarioResponseDTO> DeleteAsync(long id)
        {
            var model = await _satisfacaoUsuarioDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_SatisfacaoUsuario".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Satisfação de Usuario do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _satisfacaoUsuarioDomainService.DeleteAsync(id);

            return _mapper.Map<SatisfacaoUsuarioResponseDTO>(result);

        }

        public async Task<SatisfacaoUsuarioResponseDTO> GetByIdAsync(long id)
        {
            var result = await _satisfacaoUsuarioDomainService.GetByIdAsync(id);
            return _mapper.Map<SatisfacaoUsuarioResponseDTO>(result);
        }


        public async Task<List<SatisfacaoUsuarioResponseDTO>> GetAllAsync()
        {
            var result = await _satisfacaoUsuarioDomainService.GetAllAsync();

            return _mapper.Map<List<SatisfacaoUsuarioResponseDTO>>(result);
        }
        public async Task<List<SatisfacaoUsuarioResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _satisfacaoUsuarioDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<SatisfacaoUsuarioResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<SatisfacaoUsuarioResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _satisfacaoUsuarioDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<SatisfacaoUsuarioResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(SatisfacaoUsuarioRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                SatisfacaoUsuario requestOld = _mapper.Map<SatisfacaoUsuario>(GetByIdAsync(request.Id).Result);
                SatisfacaoUsuario requestNew = _mapper.Map<SatisfacaoUsuario>(request);

                logs.AddRange(from diff in ViewModelHelper.PublicInstancePropertiesEqual(requestOld, requestNew)
                              where !diff.Key.EndsWith("Id")
                              let propCamelcase =
                                                System.Text.RegularExpressions.Regex.Replace(diff.Key, "([A-Z])", " $1",
                                                    System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
                              select new LogCrud(usuarioLogado.Id, usuarioLogado.Nome
                              , LogTipo.Alterado
                              , logTabela.Id
                              , logTabela.Nome
                              , propCamelcase,
                              (diff.Value.Item1 == null || string.IsNullOrEmpty(diff.Value.Item1.ToString())
                              ? "'sem dado'"
                              : diff.Value.Item1.ToString())
                              ,
                              (diff.Value.Item2 == null || string.IsNullOrEmpty(diff.Value.Item2.ToString())
                                                    ? "'sem dado'"
                                                    : diff.Value.Item2.ToString())
                                                ));
            }
            else
            {
                try
                {
                    logs.Add(new LogCrud(usuarioLogado.Id, usuarioLogado.Nome, LogTipo.Cadastrado, logTabela.Id, logTabela.Nome, null, null, null));
                }
                catch (Exception ex)
                {

                    throw;
                }

            }

            return logs;
        }

        public void Dispose()
        {
            _satisfacaoUsuarioDomainService.Dispose();
        }


    }
}
