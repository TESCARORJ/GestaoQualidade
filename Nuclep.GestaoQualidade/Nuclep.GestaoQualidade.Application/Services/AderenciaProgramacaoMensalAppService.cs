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
    public class AderenciaProgramacaoMensalAppService : IAderenciaProgramacaoMensalAppService
    {
        private readonly IAderenciaProgramacaoMensalDomainService _aderenciaProgramacaoMensalDomainService;
        private readonly IAderenciaProgramacaoMensalMetaDomainService _aderenciaProgramacaoMensalMetaDomainService;
        private readonly IAderenciaProgramacaoMensalMetaRepository _aderenciaProgramacaoMensalMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IAderenciaProgramacaoMensalRepository _aderenciaProgramacaoMensalRepository;



        public AderenciaProgramacaoMensalAppService(
            IAderenciaProgramacaoMensalDomainService aderenciaProgramacaoMensalDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IAderenciaProgramacaoMensalMetaDomainService aderenciaProgramacaoMensalMetaDomainService,
            IAderenciaProgramacaoMensalMetaRepository aderenciaProgramacaoMensalMetaRepository,
            IAderenciaProgramacaoMensalRepository aderenciaProgramacaoMensalRepository)
        {
            _aderenciaProgramacaoMensalDomainService = aderenciaProgramacaoMensalDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _aderenciaProgramacaoMensalMetaDomainService = aderenciaProgramacaoMensalMetaDomainService;
            _aderenciaProgramacaoMensalMetaRepository = aderenciaProgramacaoMensalMetaRepository;
            _aderenciaProgramacaoMensalRepository = aderenciaProgramacaoMensalRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<AderenciaProgramacaoMensal> aderenciaProgramacaoMensalList = new List<AderenciaProgramacaoMensal>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var aderenciaProgramacaoMensalCount = _aderenciaProgramacaoMensalDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoAderenciaProgramacaoMensalList = _aderenciaProgramacaoMensalDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _aderenciaProgramacaoMensalMetaDomainService.GetAllAsync().Result.ToList();
          //  var anolList = _aderenciaProgramacaoMensalRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsAderenciaProgramacaoMensal)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoAderenciaProgramacaoMensalList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            AderenciaProgramacaoMensal aderenciaProgramacaoMensal = new AderenciaProgramacaoMensal
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            aderenciaProgramacaoMensalList.Add(aderenciaProgramacaoMensal);
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
                    //LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome == "AderenciaProgramacaoMensal").Result,
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_AderenciaProgramacaoMensal").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Aderência à Programação Mensal para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };
                
                await _logCrudRepository.AddListAsync(logs);

                await _aderenciaProgramacaoMensalDomainService.AddListAsync(aderenciaProgramacaoMensalList);

                transaction.Complete();

            }
        }


        public async Task<AderenciaProgramacaoMensalResponseDTO> UpdateAsync(long id, AderenciaProgramacaoMensalRequestDTO request)
        {
            var model = _mapper.Map<AderenciaProgramacaoMensal>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_AderenciaProgramacaoMensal");

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

                    var result = await _aderenciaProgramacaoMensalDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<AderenciaProgramacaoMensalResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }

     

        public async Task<AderenciaProgramacaoMensalResponseDTO> DeleteAsync(long id)
        {
            var model = await _aderenciaProgramacaoMensalDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                //LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_AderenciaProgramacaoMensal".ToLower()).Result,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_AderenciaProgramacaoMensal".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Aderência Programação Mensal do período {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _aderenciaProgramacaoMensalDomainService.DeleteAsync(id);

            return _mapper.Map<AderenciaProgramacaoMensalResponseDTO>(result);

        }

        public async Task<AderenciaProgramacaoMensalResponseDTO> GetByIdAsync(long id)
        {
            var result = await _aderenciaProgramacaoMensalDomainService.GetByIdAsync(id);
            return _mapper.Map<AderenciaProgramacaoMensalResponseDTO>(result);
        }


        public async Task<List<AderenciaProgramacaoMensalResponseDTO>> GetAllAsync()
        {
            var result = await _aderenciaProgramacaoMensalDomainService.GetAllAsync();

            return _mapper.Map<List<AderenciaProgramacaoMensalResponseDTO>>(result);
        }

         public async Task<List<AderenciaProgramacaoMensalResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _aderenciaProgramacaoMensalDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<AderenciaProgramacaoMensalResponseDTO>>(result);
        }

        public async Task<List<AderenciaProgramacaoMensalResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _aderenciaProgramacaoMensalDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<AderenciaProgramacaoMensalResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(AderenciaProgramacaoMensalRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());



            //Log de diferenças
            if (request.Id != 0)
            {
                AderenciaProgramacaoMensal requestOld = _mapper.Map<AderenciaProgramacaoMensal>(GetByIdAsync(request.Id).Result);
                AderenciaProgramacaoMensal requestNew = _mapper.Map<AderenciaProgramacaoMensal>(request);

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
            _aderenciaProgramacaoMensalDomainService.Dispose();
        }


    }
}
