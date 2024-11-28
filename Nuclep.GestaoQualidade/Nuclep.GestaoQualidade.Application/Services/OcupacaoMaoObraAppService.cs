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
    public class OcupacaoMaoObraAppService : IOcupacaoMaoObraAppService
    {
        private readonly IOcupacaoMaoObraDomainService _ocupacaoMaoObraDomainService;
        private readonly IOcupacaoMaoObraMetaDomainService _ocupacaoMaoObraMetaDomainService;
        private readonly IOcupacaoMaoObraMetaRepository _ocupacaoMaoObraMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IOcupacaoMaoObraRepository _ocupacaoMaoObraRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public OcupacaoMaoObraAppService(
            IOcupacaoMaoObraDomainService ocupacaoMaoObraDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IOcupacaoMaoObraMetaDomainService ocupacaoMaoObraMetaDomainService,
            IOcupacaoMaoObraMetaRepository ocupacaoMaoObraMetaRepository,
            IOcupacaoMaoObraRepository ocupacaoMaoObraRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _ocupacaoMaoObraDomainService = ocupacaoMaoObraDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _ocupacaoMaoObraMetaDomainService = ocupacaoMaoObraMetaDomainService;
            _ocupacaoMaoObraMetaRepository = ocupacaoMaoObraMetaRepository;
            _ocupacaoMaoObraRepository = ocupacaoMaoObraRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<OcupacaoMaoObra> ocupacaoMaoObraList = new List<OcupacaoMaoObra>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var ocupacaoMaoObraCount = _ocupacaoMaoObraDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoOcupacaoMaoObraList = _ocupacaoMaoObraDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _ocupacaoMaoObraMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _ocupacaoMaoObraRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsOcupacaoMaoObra)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoOcupacaoMaoObraList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            OcupacaoMaoObra ocupacaoMaoObra = new OcupacaoMaoObra
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Mes = (EnumMes)i,
                                Meta = (int)ano.Meta
                            };

                            ocupacaoMaoObraList.Add(ocupacaoMaoObra);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_OcupacaoMaoObra").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Faturamentos Realizados para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _ocupacaoMaoObraDomainService.AddListAsync(ocupacaoMaoObraList);

                transaction.Complete();

            }
        }

        public async Task<OcupacaoMaoObraResponseDTO> UpdateAsync(long id, OcupacaoMaoObraRequestDTO request)
        {
            var model = _mapper.Map<OcupacaoMaoObra>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_OcupacaoMaoObra");

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

                    var result = await _ocupacaoMaoObraDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<OcupacaoMaoObraResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<OcupacaoMaoObraResponseDTO> DeleteAsync(long id)
        {
            var model = await _ocupacaoMaoObraDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_OcupacaoMaoObra".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Aderência Programação Mensal de valor {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _ocupacaoMaoObraDomainService.DeleteAsync(id);

            return _mapper.Map<OcupacaoMaoObraResponseDTO>(result);

        }

        public async Task<OcupacaoMaoObraResponseDTO> GetByIdAsync(long id)
        {
            var result = await _ocupacaoMaoObraDomainService.GetByIdAsync(id);
            return _mapper.Map<OcupacaoMaoObraResponseDTO>(result);
        }


        public async Task<List<OcupacaoMaoObraResponseDTO>> GetAllAsync()
        {
            var result = await _ocupacaoMaoObraDomainService.GetAllAsync();

            return _mapper.Map<List<OcupacaoMaoObraResponseDTO>>(result);
        }
        public async Task<List<OcupacaoMaoObraResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _ocupacaoMaoObraDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<OcupacaoMaoObraResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<OcupacaoMaoObraResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _ocupacaoMaoObraDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<OcupacaoMaoObraResponseDTO>>(result);
        }

        private List<LogCrud> Logar(OcupacaoMaoObraRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                OcupacaoMaoObra requestOld = _mapper.Map<OcupacaoMaoObra>(GetByIdAsync(request.Id).Result);
                OcupacaoMaoObra requestNew = _mapper.Map<OcupacaoMaoObra>(request);

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
            _ocupacaoMaoObraDomainService.Dispose();
        }


    }
}
