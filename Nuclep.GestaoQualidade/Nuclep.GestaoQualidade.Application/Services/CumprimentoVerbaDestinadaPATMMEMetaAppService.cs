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
    public class CumprimentoVerbaDestinadaPATMMEMetaAppService : ICumprimentoVerbaDestinadaPATMMEMetaAppService
    {
        private readonly ICumprimentoVerbaDestinadaPATMMEMetaDomainService _cumprimentoVerbaDestinadaPATMMEMetaDomainService;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;



        public CumprimentoVerbaDestinadaPATMMEMetaAppService(
            ICumprimentoVerbaDestinadaPATMMEMetaDomainService cumprimentoVerbaDestinadaPATMMEMetaDomainService, 
            IMapper mapper, IUsuarioSession usuarioSession, ILogTabelaRepository logTabelaRepository, ILogCrudRepository logCrudRepository)
        {
            _cumprimentoVerbaDestinadaPATMMEMetaDomainService = cumprimentoVerbaDestinadaPATMMEMetaDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
        }

        public async Task<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO> AddAsync(CumprimentoVerbaDestinadaPATMMEMetaRequestDTO request)
        {
            var model = _mapper.Map<CumprimentoVerbaDestinadaPATMMEMeta>(request);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            model.DataHoraCadastro = DateTime.Now;
            model.UsuarioCadastro = await _usuarioSession.GetUsuarioLogado();
            model.IsAtivo = true;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_CumprimentoVerbaDestinadaPATMMEMeta");

            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var item in logs)
                    {
                        item.IdReferencia = model.Id;
                        await _logCrudRepository.AddAsync(item);
                    }

                    var result = await _cumprimentoVerbaDestinadaPATMMEMetaDomainService.AddAsync(model);

                    transaction.Complete();

                    return _mapper.Map<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }


            }


        }
        public async Task<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO> UpdateAsync(long id, CumprimentoVerbaDestinadaPATMMEMetaRequestDTO request)
        {
            var model = _mapper.Map<CumprimentoVerbaDestinadaPATMMEMeta>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_CumprimentoVerbaDestinadaPATMMEMeta");

            // Inicia uma transação
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var item in logs)
                    {
                        item.IdReferencia = model.Id;
                        await _logCrudRepository.AddAsync(item);
                    }

                    var result = await _cumprimentoVerbaDestinadaPATMMEMetaDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }

               

        }

        public async Task<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO> DeleteAsync(long id)
        {
            var model = await _cumprimentoVerbaDestinadaPATMMEMetaDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                Usuario = usuarioLogado,
                LogTipo = LogTipo.Cadastrado,
                LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_CumprimentoVerbaDestinadaPATMMEMeta".ToLower()).Result,
                IdReferencia = model.Id,
                Descricao = $"Meta Aderência Programação Mensal de valor {model.Meta} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _cumprimentoVerbaDestinadaPATMMEMetaDomainService.DeleteAsync(id);

            return _mapper.Map<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>(result);

        }

        public async Task<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO> GetByIdAsync(long id)
        {
            var result = await _cumprimentoVerbaDestinadaPATMMEMetaDomainService.GetByIdAsync(id);
            return _mapper.Map<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>(result);
        }


        public async Task<List<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>> GetAllAsync()
        {
            var result = await _cumprimentoVerbaDestinadaPATMMEMetaDomainService.GetAllAsync();

            return _mapper.Map<List<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>>(result);
        }

        public async Task<List<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _cumprimentoVerbaDestinadaPATMMEMetaDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<CumprimentoVerbaDestinadaPATMMEMetaResponseDTO>>(result);
        }

        private List<LogCrud> Logar(CumprimentoVerbaDestinadaPATMMEMetaRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                CumprimentoVerbaDestinadaPATMMEMeta requestOld = _mapper.Map<CumprimentoVerbaDestinadaPATMMEMeta>(GetByIdAsync(request.Id).Result);
                CumprimentoVerbaDestinadaPATMMEMeta requestNew = _mapper.Map<CumprimentoVerbaDestinadaPATMMEMeta>(request);

                logs.AddRange(from diff in ViewModelHelper.PublicInstancePropertiesEqual(requestOld, requestNew)
                              where !diff.Key.EndsWith("Id")
                              let propCamelcase =
                                                System.Text.RegularExpressions.Regex.Replace(diff.Key, "([A-Z])", " $1",
                                                    System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
                              select new LogCrud(usuarioLogado
                              , LogTipo.Alterado
                              , _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result
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
                    logs.Add(new LogCrud(usuarioLogado, LogTipo.Cadastrado,
                   _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result, null,
                   null, null));
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
            _cumprimentoVerbaDestinadaPATMMEMetaDomainService.Dispose();
        }


    }
}