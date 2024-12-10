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
    public class ItensCadastradosMais15DiasAppService : IItensCadastradosMais15DiasAppService
    {
        private readonly IItensCadastradosMais15DiasDomainService _itensCadastradosMais15DiasDomainService;
        private readonly IItensCadastradosMais15DiasMetaDomainService _itensCadastradosMais15DiasMetaDomainService;
        private readonly IItensCadastradosMais15DiasMetaRepository _itensCadastradosMais15DiasMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IItensCadastradosMais15DiasRepository _itensCadastradosMais15DiasRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public ItensCadastradosMais15DiasAppService(
            IItensCadastradosMais15DiasDomainService itensCadastradosMais15DiasDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IItensCadastradosMais15DiasMetaDomainService itensCadastradosMais15DiasMetaDomainService,
            IItensCadastradosMais15DiasMetaRepository itensCadastradosMais15DiasMetaRepository,
            IItensCadastradosMais15DiasRepository itensCadastradosMais15DiasRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _itensCadastradosMais15DiasDomainService = itensCadastradosMais15DiasDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _itensCadastradosMais15DiasMetaDomainService = itensCadastradosMais15DiasMetaDomainService;
            _itensCadastradosMais15DiasMetaRepository = itensCadastradosMais15DiasMetaRepository;
            _itensCadastradosMais15DiasRepository = itensCadastradosMais15DiasRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<ItensCadastradosMais15Dias> itensCadastradosMais15DiasList = new List<ItensCadastradosMais15Dias>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var itensCadastradosMais15DiasCount = _itensCadastradosMais15DiasDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoItensCadastradosMais15DiasList = _itensCadastradosMais15DiasDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _itensCadastradosMais15DiasMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _itensCadastradosMais15DiasRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsItensCadastradosMais15Dias)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoItensCadastradosMais15DiasList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            ItensCadastradosMais15Dias itensCadastradosMais15Dias = new ItensCadastradosMais15Dias
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            itensCadastradosMais15DiasList.Add(itensCadastradosMais15Dias);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_ItensCadastradosMais15Dias").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Itens Cadastrados em Mais de 15 dias para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _itensCadastradosMais15DiasDomainService.AddListAsync(itensCadastradosMais15DiasList);

                transaction.Complete();

            }
        }

        public async Task<ItensCadastradosMais15DiasResponseDTO> UpdateAsync(long id, ItensCadastradosMais15DiasRequestDTO request)
        {
            var model = _mapper.Map<ItensCadastradosMais15Dias>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_ItensCadastradosMais15Dias");

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

                    var result = await _itensCadastradosMais15DiasDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<ItensCadastradosMais15DiasResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<ItensCadastradosMais15DiasResponseDTO> DeleteAsync(long id)
        {
            var model = await _itensCadastradosMais15DiasDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_ItensCadastradosMais15Dias".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Itens Cadastrados em Mais de 15 dias do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _itensCadastradosMais15DiasDomainService.DeleteAsync(id);

            return _mapper.Map<ItensCadastradosMais15DiasResponseDTO>(result);

        }

        public async Task<ItensCadastradosMais15DiasResponseDTO> GetByIdAsync(long id)
        {
            var result = await _itensCadastradosMais15DiasDomainService.GetByIdAsync(id);
            return _mapper.Map<ItensCadastradosMais15DiasResponseDTO>(result);
        }


        public async Task<List<ItensCadastradosMais15DiasResponseDTO>> GetAllAsync()
        {
            var result = await _itensCadastradosMais15DiasDomainService.GetAllAsync();

            return _mapper.Map<List<ItensCadastradosMais15DiasResponseDTO>>(result);
        }
        public async Task<List<ItensCadastradosMais15DiasResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _itensCadastradosMais15DiasDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<ItensCadastradosMais15DiasResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<ItensCadastradosMais15DiasResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _itensCadastradosMais15DiasDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<ItensCadastradosMais15DiasResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(ItensCadastradosMais15DiasRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                ItensCadastradosMais15Dias requestOld = _mapper.Map<ItensCadastradosMais15Dias>(GetByIdAsync(request.Id).Result);
                ItensCadastradosMais15Dias requestNew = _mapper.Map<ItensCadastradosMais15Dias>(request);

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
            _itensCadastradosMais15DiasDomainService.Dispose();
        }


    }
}
