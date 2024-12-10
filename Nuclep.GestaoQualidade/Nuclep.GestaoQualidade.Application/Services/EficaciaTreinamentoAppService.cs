using AutoMapper;
using Nuclep.GestaoQualidade.Application.DTOs;
using Nuclep.GestaoQualidade.Application.Helpers;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Application.Interfaces.Sistema;
using Nuclep.GestaoQualidade.Domain.Enumeradores;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System.Transactions;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class EficaciaTreinamentoAppService : IEficaciaTreinamentoAppService
    {
        private readonly IEficaciaTreinamentoDomainService _eficaciaTreinamentoDomainService;
        private readonly IEficaciaTreinamentoMetaDomainService _eficaciaTreinamentoMetaDomainService;
        private readonly IEficaciaTreinamentoMetaRepository _eficaciaTreinamentoMetaRepository;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;
        private readonly IEficaciaTreinamentoRepository _eficaciaTreinamentoRepository;



        public EficaciaTreinamentoAppService(
            IEficaciaTreinamentoDomainService eficaciaTreinamentoDomainService,
            IMapper mapper,
            IUsuarioSession usuarioSession,
            ILogTabelaRepository logTabelaRepository,
            ILogCrudRepository logCrudRepository,
            IEficaciaTreinamentoMetaDomainService eficaciaTreinamentoMetaDomainService,
            IEficaciaTreinamentoMetaRepository eficaciaTreinamentoMetaRepository,
            IEficaciaTreinamentoRepository eficaciaTreinamentoRepository)
        {
            _eficaciaTreinamentoDomainService = eficaciaTreinamentoDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
            _eficaciaTreinamentoMetaDomainService = eficaciaTreinamentoMetaDomainService;
            _eficaciaTreinamentoMetaRepository = eficaciaTreinamentoMetaRepository;
            _eficaciaTreinamentoRepository = eficaciaTreinamentoRepository;
        }


        public async Task GararPerguntasAsync()
        {
            List<EficaciaTreinamento> eficaciaTreinamentoList = new List<EficaciaTreinamento>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            var eficaciaTreinamentoCount = _eficaciaTreinamentoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).Any();
            var anoEficaciaTreinamentoList = _eficaciaTreinamentoDomainService.GetAllAsync().Result.Where(x => x.UsuarioCadastro == usuarioLogado).ToList();
            var anoMetalList = _eficaciaTreinamentoMetaDomainService.GetAllAsync().Result.ToList();
            //  var anolList = _eficaciaTreinamentoRepository.GetAllAsync(x => x.Ano > 0).Result.ToList();

            if (usuarioLogado.IsEficaciaTreinamento)
            {
                foreach (var ano in anoMetalList)
                {
                    if (!anoEficaciaTreinamentoList.Any(x => x.Ano == ano.Ano))
                    {
                        for (int i = 1; i <= 2; i++)
                        {
                            EficaciaTreinamento eficaciaTreinamento = new EficaciaTreinamento
                            {
                                IsAtivo = true,
                                UsuarioCadastro = usuarioLogado,
                                DataHoraCadastro = DateTime.Now,
                                Ano = ano.Ano,
                                Semestre = (EnumSemestre)i,
                                Meta = (int)ano.Meta
                            };

                            eficaciaTreinamentoList.Add(eficaciaTreinamento);
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
                    LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome == "Ind_EficaciaTreinamento").Result.Id,
                    Descricao = $"Cadastrado períodos de preenchimento de Eficácia de Treinamento para o usuário {usuarioLogado.Nome} em {DateTime.Now}",
                };

                await _logCrudRepository.AddListAsync(logs);

                await _eficaciaTreinamentoDomainService.AddListAsync(eficaciaTreinamentoList);

                transaction.Complete();

            }
        }


        public async Task<EficaciaTreinamentoResponseDTO> UpdateAsync(long id, EficaciaTreinamentoRequestDTO request)
        {
            var model = _mapper.Map<EficaciaTreinamento>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_EficaciaTreinamento");

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

                    var result = await _eficaciaTreinamentoDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<EficaciaTreinamentoResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }



        public async Task<EficaciaTreinamentoResponseDTO> DeleteAsync(long id)
        {
            var model = await _eficaciaTreinamentoDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_EficaciaTreinamento".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $" Eficácia de Treinamento do período {model.Semestre} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _eficaciaTreinamentoDomainService.DeleteAsync(id);

            return _mapper.Map<EficaciaTreinamentoResponseDTO>(result);

        }

        public async Task<EficaciaTreinamentoResponseDTO> GetByIdAsync(long id)
        {
            var result = await _eficaciaTreinamentoDomainService.GetByIdAsync(id);
            return _mapper.Map<EficaciaTreinamentoResponseDTO>(result);
        }


        public async Task<List<EficaciaTreinamentoResponseDTO>> GetAllAsync()
        {
            var result = await _eficaciaTreinamentoDomainService.GetAllAsync();

            return _mapper.Map<List<EficaciaTreinamentoResponseDTO>>(result);
        }
        public async Task<List<EficaciaTreinamentoResponseDTO>> GetAllUsarioLogadoAsync()
        {
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            var result = await _eficaciaTreinamentoDomainService.GetAllUsarioLogadoAsync(usuarioLogado.Id);

            return _mapper.Map<List<EficaciaTreinamentoResponseDTO>>(result);
        }

        public async Task<List<EficaciaTreinamentoResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _eficaciaTreinamentoDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<EficaciaTreinamentoResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(EficaciaTreinamentoRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());


            //Log de diferenças
            if (request.Id != 0)
            {
                EficaciaTreinamento requestOld = _mapper.Map<EficaciaTreinamento>(GetByIdAsync(request.Id).Result);
                EficaciaTreinamento requestNew = _mapper.Map<EficaciaTreinamento>(request);

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
            _eficaciaTreinamentoDomainService.Dispose();
        }


    }
}
