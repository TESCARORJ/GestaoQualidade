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
    public class DefeitoSoldagemAppService : IDefeitoSoldagemAppService
    {
        private readonly IDefeitoSoldagemDomainService _defeitoSoldagemDomainService;
        private readonly IDefeitoSoldagemMetaDomainService _defeitoSoldagemMetaDomainService;
        private readonly IDefeitoSoldagemMetaRepository _defeitoSoldagemMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IDefeitoSoldagemRepository _defeitoSoldagemRepository;
        private readonly ILocalidadeRepository _localidadeRepository;



        public DefeitoSoldagemAppService(
            IDefeitoSoldagemDomainService defeitoSoldagemDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IDefeitoSoldagemMetaDomainService defeitoSoldagemMetaDomainService,
            IDefeitoSoldagemMetaRepository defeitoSoldagemMetaRepository,
            IDefeitoSoldagemRepository defeitoSoldagemRepository,
            ILocalidadeRepository localidadeRepository)
        {
            _defeitoSoldagemDomainService = defeitoSoldagemDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _defeitoSoldagemMetaDomainService = defeitoSoldagemMetaDomainService;
            _defeitoSoldagemMetaRepository = defeitoSoldagemMetaRepository;
            _defeitoSoldagemRepository = defeitoSoldagemRepository;
            _localidadeRepository = localidadeRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<DefeitoSoldagem> defeitoSoldagemList = new List<DefeitoSoldagem>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;


            // var itaguaiCount = _defeitoSoldagemRepository.GetAllAsync(x => x.UsuarioCadastro == usuarioLogado && x.Localidade.Id == 1).Result.Select(x => x.Id).Any();

            //var aramarCount = _session.Query<DefeitoSoldagem>().Where(x => x.UsuarioCadastro == usuarioLogado && x.Localidade.Id == 2).Select(x => x.Id).Any();
            //var aramarList = _session.Query<DefeitoSoldagem>().Where(x => x.UsuarioCadastro == usuarioLogado && x.Localidade.Id == 2).Select(x => x.Ano).Distinct().ToList();

            //var condensadorCount = _session.Query<DefeitoSoldagem>().Where(x => x.UsuarioCadastro == usuarioLogado && x.Localidade.Id == 3).Select(x => x.Id).Any();
            //var condensadorList = _session.Query<DefeitoSoldagem>().Where(x => x.UsuarioCadastro == usuarioLogado && x.Localidade.Id == 3).Select(x => x.Ano).Distinct().ToList();

            //var vprCount = _session.Query<DefeitoSoldagem>().Where(x => x.UsuarioCadastro == usuarioLogado && x.Localidade.Id == 4).Select(x => x.Id).Any();
            //var vprList = _session.Query<DefeitoSoldagem>().Where(x => x.UsuarioCadastro == usuarioLogado && x.Localidade.Id == 4).Select(x => x.Ano).Distinct().ToList();
            
            var itaguaiList = _defeitoSoldagemRepository.GetAllUsarioLogadoAsync(usuarioLogado.Id).Result.Where(x => x.Localidade != null && x.Localidade.Id == 1).ToList();
            var aramarList = _defeitoSoldagemRepository.GetAllUsarioLogadoAsync(usuarioLogado.Id).Result.Where(x =>  x.Localidade != null && x.Localidade.Id == 2).ToList();
            var condensadorList = _defeitoSoldagemRepository.GetAllUsarioLogadoAsync(usuarioLogado.Id).Result.Where(x => x.Localidade != null && x.Localidade.Id == 3).ToList();
            var vprList = _defeitoSoldagemRepository.GetAllUsarioLogadoAsync(usuarioLogado.Id).Result.Where(x => x.Localidade != null && x.Localidade.Id == 4).ToList();

            var MetaList = _defeitoSoldagemMetaRepository.GetAllAsync().Result.ToList();

            if (usuarioLogado.IsLocalidadeItaguai)
            {
                foreach (var meta in MetaList)
                {
                    if (!itaguaiList.Any(x => x.LocalidadeId == 1 && x.Ano == meta.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            DefeitoSoldagem defeitoSoldagem = new DefeitoSoldagem
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = meta.Ano,
                                Mes = (EnumMes)i,
                                Localidade = _localidadeRepository.GetOneAsync(x => x.Id == 1).Result //Itaguai
                            };

                            defeitoSoldagemList.Add(defeitoSoldagem);
                        }
                    }
                }


            }

            if (usuarioLogado.IsLocalidadeAramar)
            {
                foreach (var meta in MetaList)
                {
                    if (!aramarList.Any(x => x.LocalidadeId == 2 && x.Ano == meta.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            DefeitoSoldagem defeitoSoldagem = new DefeitoSoldagem
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = meta.Ano,
                                Mes = (EnumMes)i,
                                Localidade = _localidadeRepository.GetOneAsync(x => x.Id == 2).Result //Aramar
                            };

                            defeitoSoldagemList.Add(defeitoSoldagem);
                        }
                    }
                }


            }

            if (usuarioLogado.IsCondensador)
            {
                foreach (var meta in MetaList)
                {
                    if (!condensadorList.Any(x => x.LocalidadeId == 3 && x.Ano == meta.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            DefeitoSoldagem defeitoSoldagem = new DefeitoSoldagem
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = meta.Ano,
                                Mes = (EnumMes)i,
                                Localidade = _localidadeRepository.GetOneAsync(x => x.Id == 3).Result //Condensador
                            };

                            defeitoSoldagemList.Add(defeitoSoldagem);
                        }
                    }
                }


            }

            if (usuarioLogado.IsVPR)
            {
                foreach (var meta in MetaList)
                {
                    if (!vprList.Any(x => x.LocalidadeId == 4 && x.Ano == meta.Ano))
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            DefeitoSoldagem defeitoSoldagem = new DefeitoSoldagem
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = meta.Ano,
                                Mes = (EnumMes)i,
                                Localidade = _localidadeRepository.GetOneAsync(x => x.Id == 4).Result //VPR
                            };

                            defeitoSoldagemList.Add(defeitoSoldagem);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_DefeitoSoldagem").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Defeito de Soldagem para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                logs.Add(log);

                _logCrudRepository.AddListAsync(logs).Wait();

                await _defeitoSoldagemRepository.AddListAsync(defeitoSoldagemList);

                transaction.Complete();

            }


        }


        public async Task<DefeitoSoldagemResponseDTO> UpdateAsync(long id, DefeitoSoldagemRequestDTO request)
        {
            var model = _mapper.Map<DefeitoSoldagem>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_DefeitoSoldagem");

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

                    var result = await _defeitoSoldagemDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<DefeitoSoldagemResponseDTO>(result);
                }
                catch (Exception ex)
                {

                    throw;
                }
            }



        }



        public async Task<DefeitoSoldagemResponseDTO> DeleteAsync(long id)
        {
            var model = await _defeitoSoldagemDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_DefeitoSoldagem".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Aderência Programação Mensal de valor {model.Mes} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _defeitoSoldagemDomainService.DeleteAsync(id);

            return _mapper.Map<DefeitoSoldagemResponseDTO>(result);

        }

        public async Task<DefeitoSoldagemResponseDTO> GetByIdAsync(long id)
        {
            var result = await _defeitoSoldagemDomainService.GetByIdAsync(id);
            return _mapper.Map<DefeitoSoldagemResponseDTO>(result);
        }


        public async Task<List<DefeitoSoldagemResponseDTO>> GetAllAsync()
        {
            var result = await _defeitoSoldagemDomainService.GetAllAsync();

            return _mapper.Map<List<DefeitoSoldagemResponseDTO>>(result);
        }
        public async Task<List<DefeitoSoldagemResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _defeitoSoldagemDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            var lista = _mapper.Map<List<DefeitoSoldagemResponseDTO>>(result);

            return lista ;
        }

        public async Task<List<DefeitoSoldagemResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _defeitoSoldagemDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<DefeitoSoldagemResponseDTO>>(result);
        }

        private List<LogCrud> Logar(DefeitoSoldagemRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                DefeitoSoldagem requestOld = _mapper.Map<DefeitoSoldagem>(GetByIdAsync(request.Id).Result);
                DefeitoSoldagem requestNew = _mapper.Map<DefeitoSoldagem>(request);

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
            _defeitoSoldagemDomainService.Dispose();
        }


    }
}
