﻿using AutoMapper;
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
using System.Transactions;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class OcupacaoMaoObraMetaAppService : IOcupacaoMaoObraMetaAppService
    {
        private readonly IOcupacaoMaoObraMetaDomainService _ocupacaoMaoObraMetaDomainService;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;



        public OcupacaoMaoObraMetaAppService(
            IOcupacaoMaoObraMetaDomainService ocupacaoMaoObraMetaDomainService,
            IMapper mapper, IUsuarioSession usuarioSession, ILogTabelaRepository logTabelaRepository, ILogCrudRepository logCrudRepository)
        {
            _ocupacaoMaoObraMetaDomainService = ocupacaoMaoObraMetaDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
        }

        public async Task<OcupacaoMaoObraMetaResponseDTO> AddAsync(OcupacaoMaoObraMetaRequestDTO request)
        {
            var model = _mapper.Map<OcupacaoMaoObraMeta>(request);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            model.DataHoraCadastro = DateTime.Now;
            model.UsuarioCadastro = await _usuarioSession.GetUsuarioLogado();
            model.IsAtivo = true;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_OcupacaoMaoObraMeta");

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

                    var result = await _ocupacaoMaoObraMetaDomainService.AddAsync(model);

                    transaction.Complete();

                    return _mapper.Map<OcupacaoMaoObraMetaResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }


            }


        }
        public async Task<OcupacaoMaoObraMetaResponseDTO> UpdateAsync(long id, OcupacaoMaoObraMetaRequestDTO request)
        {
            var model = _mapper.Map<OcupacaoMaoObraMeta>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_OcupacaoMaoObraMeta");

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

                    var result = await _ocupacaoMaoObraMetaDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<OcupacaoMaoObraMetaResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }

        public async Task<OcupacaoMaoObraMetaResponseDTO> DeleteAsync(long id)
        {
            var model = await _ocupacaoMaoObraMetaDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_OcupacaoMaoObraMeta".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $"Meta Ocupação de Mão de Obra do período {model.Meta} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _ocupacaoMaoObraMetaDomainService.DeleteAsync(id);

            return _mapper.Map<OcupacaoMaoObraMetaResponseDTO>(result);

        }

        public async Task<OcupacaoMaoObraMetaResponseDTO> GetByIdAsync(long id)
        {
            var result = await _ocupacaoMaoObraMetaDomainService.GetByIdAsync(id);
            return _mapper.Map<OcupacaoMaoObraMetaResponseDTO>(result);
        }


        public async Task<List<OcupacaoMaoObraMetaResponseDTO>> GetAllAsync()
        {
            var result = await _ocupacaoMaoObraMetaDomainService.GetAllAsync();

            return _mapper.Map<List<OcupacaoMaoObraMetaResponseDTO>>(result);
        }

        public async Task<List<OcupacaoMaoObraMetaResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _ocupacaoMaoObraMetaDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<OcupacaoMaoObraMetaResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(OcupacaoMaoObraMetaRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());

            //Log de diferenças
            if (request.Id != 0)
            {
                OcupacaoMaoObraMeta requestOld = _mapper.Map<OcupacaoMaoObraMeta>(GetByIdAsync(request.Id).Result);
                OcupacaoMaoObraMeta requestNew = _mapper.Map<OcupacaoMaoObraMeta>(request);

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
            _ocupacaoMaoObraMetaDomainService.Dispose();
        }


    }
}
