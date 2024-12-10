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
    public class NaoConformidadeAppService : INaoConformidadeAppService
    {
        private readonly INaoConformidadeDomainService _naoConformidadeDomainService;
        private readonly INaoConformidadeMetaDomainService _naoConformidadeMetaDomainService;
        private readonly INaoConformidadeMetaRepository _naoConformidadeMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly INaoConformidadeRepository _naoConformidadeRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public NaoConformidadeAppService(
            INaoConformidadeDomainService naoConformidadeDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            INaoConformidadeMetaDomainService naoConformidadeMetaDomainService,
            INaoConformidadeMetaRepository naoConformidadeMetaRepository,
            INaoConformidadeRepository naoConformidadeRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _naoConformidadeDomainService = naoConformidadeDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _naoConformidadeMetaDomainService = naoConformidadeMetaDomainService;
            _naoConformidadeMetaRepository = naoConformidadeMetaRepository;
            _naoConformidadeRepository = naoConformidadeRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<NaoConformidade> naoConformidadeList = new List<NaoConformidade>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var naoConformidadeCount = _naoConformidadeDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoNaoConformidadeList = _naoConformidadeDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _naoConformidadeMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _naoConformidadeRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsNaoConformidade)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoNaoConformidadeList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            NaoConformidade naoConformidade = new NaoConformidade
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            naoConformidadeList.Add(naoConformidade);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_NaoConformidade").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Não Conformidade para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _naoConformidadeDomainService.AddListAsync(naoConformidadeList);

                transaction.Complete();

            }
        }

        public async Task<NaoConformidadeResponseDTO> UpdateAsync(long id, NaoConformidadeRequestDTO request)
        {
            var model = _mapper.Map<NaoConformidade>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_NaoConformidade");

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

                    var result = await _naoConformidadeDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<NaoConformidadeResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<NaoConformidadeResponseDTO> DeleteAsync(long id)
        {
            var model = await _naoConformidadeDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_NaoConformidade".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Não Conformidade do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _naoConformidadeDomainService.DeleteAsync(id);

            return _mapper.Map<NaoConformidadeResponseDTO>(result);

        }

        public async Task<NaoConformidadeResponseDTO> GetByIdAsync(long id)
        {
            var result = await _naoConformidadeDomainService.GetByIdAsync(id);
            return _mapper.Map<NaoConformidadeResponseDTO>(result);
        }


        public async Task<List<NaoConformidadeResponseDTO>> GetAllAsync()
        {
            var result = await _naoConformidadeDomainService.GetAllAsync();

            return _mapper.Map<List<NaoConformidadeResponseDTO>>(result);
        }
        public async Task<List<NaoConformidadeResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _naoConformidadeDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<NaoConformidadeResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<NaoConformidadeResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _naoConformidadeDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<NaoConformidadeResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(NaoConformidadeRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                NaoConformidade requestOld = _mapper.Map<NaoConformidade>(GetByIdAsync(request.Id).Result);
                NaoConformidade requestNew = _mapper.Map<NaoConformidade>(request);

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
            _naoConformidadeDomainService.Dispose();
        }


    }
}
