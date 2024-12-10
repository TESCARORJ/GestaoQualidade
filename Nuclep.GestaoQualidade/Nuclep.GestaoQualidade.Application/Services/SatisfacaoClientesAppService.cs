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
    public class SatisfacaoClientesAppService : ISatisfacaoClientesAppService
    {
        private readonly ISatisfacaoClientesDomainService _satisfacaoClientesDomainService;
        private readonly ISatisfacaoClientesMetaDomainService _satisfacaoClientesMetaDomainService;
        private readonly ISatisfacaoClientesMetaRepository _satisfacaoClientesMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly ISatisfacaoClientesRepository _satisfacaoClientesRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public SatisfacaoClientesAppService(
            ISatisfacaoClientesDomainService satisfacaoClientesDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            ISatisfacaoClientesMetaDomainService satisfacaoClientesMetaDomainService,
            ISatisfacaoClientesMetaRepository satisfacaoClientesMetaRepository,
            ISatisfacaoClientesRepository satisfacaoClientesRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _satisfacaoClientesDomainService = satisfacaoClientesDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _satisfacaoClientesMetaDomainService = satisfacaoClientesMetaDomainService;
            _satisfacaoClientesMetaRepository = satisfacaoClientesMetaRepository;
            _satisfacaoClientesRepository = satisfacaoClientesRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<SatisfacaoClientes> satisfacaoClientesList = new List<SatisfacaoClientes>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var satisfacaoClientesCount = _satisfacaoClientesDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoSatisfacaoClientesList = _satisfacaoClientesDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _satisfacaoClientesMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _satisfacaoClientesRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsSatisfacaoClientes)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoSatisfacaoClientesList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            SatisfacaoClientes satisfacaoClientes = new SatisfacaoClientes
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            satisfacaoClientesList.Add(satisfacaoClientes);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_SatisfacaoClientes").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Satisfação de Clientes para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _satisfacaoClientesDomainService.AddListAsync(satisfacaoClientesList);

                transaction.Complete();

            }
        }

        public async Task<SatisfacaoClientesResponseDTO> UpdateAsync(long id, SatisfacaoClientesRequestDTO request)
        {
            var model = _mapper.Map<SatisfacaoClientes>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_SatisfacaoClientes");

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

                    var result = await _satisfacaoClientesDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<SatisfacaoClientesResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<SatisfacaoClientesResponseDTO> DeleteAsync(long id)
        {
            var model = await _satisfacaoClientesDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_SatisfacaoClientes".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Satisfação de Clientes do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _satisfacaoClientesDomainService.DeleteAsync(id);

            return _mapper.Map<SatisfacaoClientesResponseDTO>(result);

        }

        public async Task<SatisfacaoClientesResponseDTO> GetByIdAsync(long id)
        {
            var result = await _satisfacaoClientesDomainService.GetByIdAsync(id);
            return _mapper.Map<SatisfacaoClientesResponseDTO>(result);
        }


        public async Task<List<SatisfacaoClientesResponseDTO>> GetAllAsync()
        {
            var result = await _satisfacaoClientesDomainService.GetAllAsync();

            return _mapper.Map<List<SatisfacaoClientesResponseDTO>>(result);
        }
        public async Task<List<SatisfacaoClientesResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _satisfacaoClientesDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<SatisfacaoClientesResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<SatisfacaoClientesResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _satisfacaoClientesDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<SatisfacaoClientesResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(SatisfacaoClientesRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                SatisfacaoClientes requestOld = _mapper.Map<SatisfacaoClientes>(GetByIdAsync(request.Id).Result);
                SatisfacaoClientes requestNew = _mapper.Map<SatisfacaoClientes>(request);

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
            _satisfacaoClientesDomainService.Dispose();
        }


    }
}
