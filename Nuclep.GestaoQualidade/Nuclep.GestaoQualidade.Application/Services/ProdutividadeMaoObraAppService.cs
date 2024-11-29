﻿using AutoMapper;
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
    public class ProdutividadeMaoObraAppService : IProdutividadeMaoObraAppService
    {
        private readonly IProdutividadeMaoObraDomainService _produtividadeMaoObraDomainService;
        private readonly IProdutividadeMaoObraMetaDomainService _produtividadeMaoObraMetaDomainService;
        private readonly IProdutividadeMaoObraMetaRepository _produtividadeMaoObraMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IProdutividadeMaoObraRepository _produtividadeMaoObraRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public ProdutividadeMaoObraAppService(
            IProdutividadeMaoObraDomainService produtividadeMaoObraDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IProdutividadeMaoObraMetaDomainService produtividadeMaoObraMetaDomainService,
            IProdutividadeMaoObraMetaRepository produtividadeMaoObraMetaRepository,
            IProdutividadeMaoObraRepository produtividadeMaoObraRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _produtividadeMaoObraDomainService = produtividadeMaoObraDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _produtividadeMaoObraMetaDomainService = produtividadeMaoObraMetaDomainService;
            _produtividadeMaoObraMetaRepository = produtividadeMaoObraMetaRepository;
            _produtividadeMaoObraRepository = produtividadeMaoObraRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<ProdutividadeMaoObra> produtividadeMaoObraList = new List<ProdutividadeMaoObra>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var produtividadeMaoObraCount = _produtividadeMaoObraDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoProdutividadeMaoObraList = _produtividadeMaoObraDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _produtividadeMaoObraMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _produtividadeMaoObraRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsProdutividadeMaoObra)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoProdutividadeMaoObraList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            ProdutividadeMaoObra produtividadeMaoObra = new ProdutividadeMaoObra
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            produtividadeMaoObraList.Add(produtividadeMaoObra);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_ProdutividadeMaoObra").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Faturamentos Realizados para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _produtividadeMaoObraDomainService.AddListAsync(produtividadeMaoObraList);

                transaction.Complete();

            }
        }

        public async Task<ProdutividadeMaoObraResponseDTO> UpdateAsync(long id, ProdutividadeMaoObraRequestDTO request)
        {
            var model = _mapper.Map<ProdutividadeMaoObra>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_ProdutividadeMaoObra");

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

                    var result = await _produtividadeMaoObraDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<ProdutividadeMaoObraResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<ProdutividadeMaoObraResponseDTO> DeleteAsync(long id)
        {
            var model = await _produtividadeMaoObraDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_ProdutividadeMaoObra".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Aderência Programação Mensal de valor {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _produtividadeMaoObraDomainService.DeleteAsync(id);

            return _mapper.Map<ProdutividadeMaoObraResponseDTO>(result);

        }

        public async Task<ProdutividadeMaoObraResponseDTO> GetByIdAsync(long id)
        {
            var result = await _produtividadeMaoObraDomainService.GetByIdAsync(id);
            return _mapper.Map<ProdutividadeMaoObraResponseDTO>(result);
        }


        public async Task<List<ProdutividadeMaoObraResponseDTO>> GetAllAsync()
        {
            var result = await _produtividadeMaoObraDomainService.GetAllAsync();

            return _mapper.Map<List<ProdutividadeMaoObraResponseDTO>>(result);
        }
        public async Task<List<ProdutividadeMaoObraResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _produtividadeMaoObraDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<ProdutividadeMaoObraResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<ProdutividadeMaoObraResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _produtividadeMaoObraDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<ProdutividadeMaoObraResponseDTO>>(result);
        }

        private List<LogCrud> Logar(ProdutividadeMaoObraRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                ProdutividadeMaoObra requestOld = _mapper.Map<ProdutividadeMaoObra>(GetByIdAsync(request.Id).Result);
                ProdutividadeMaoObra requestNew = _mapper.Map<ProdutividadeMaoObra>(request);

                logs.AddRange(from diff in ViewModelHelper.PublicInstancePropertiesEqual(requestOld, requestNew)
                              where !diff.Key.EndsWith("Id")
                              let propCamelcase =
                                                System.Text.RegularExpressions.Regex.Replace(diff.Key, "([A-Z])", " $1",
                                                    System.Text.RegularExpressions.RegexOptions.Compiled).Trim()
                              select new LogCrud(usuarioLogado.Id, usuarioLogado.Nome
                              , LogTipo.Alterado
                              , _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result.Id
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
                logs.Add(new LogCrud(usuarioLogado.Id, usuarioLogado.Nome, LogTipo.Cadastrado,
                    _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result.Id, null,
                    null, null));
            }

            return logs;
        }

        public void Dispose()
        {
            _produtividadeMaoObraDomainService.Dispose();
        }


    }
}