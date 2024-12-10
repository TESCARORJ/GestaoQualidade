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
using Nuclep.GestaoQualidade.Domain.Services;
using Nuclep.GestaoQualidade.SqlServer.Repositories;
using System.Transactions;

namespace Nuclep.GestaoQualidade.Application.Services
{
    public class DefeitoSoldagemMetaAppService : IDefeitoSoldagemMetaAppService
    {
        private readonly IDefeitoSoldagemMetaDomainService _defeitoSoldagemMetaDomainService;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;



        public DefeitoSoldagemMetaAppService(
            IDefeitoSoldagemMetaDomainService defeitoSoldagemMetaDomainService,
            IMapper mapper, IUsuarioSession usuarioSession, ILogTabelaRepository logTabelaRepository, ILogCrudRepository logCrudRepository)
        {
            _defeitoSoldagemMetaDomainService = defeitoSoldagemMetaDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
        }

        public async Task<DefeitoSoldagemMetaResponseDTO> AddAsync(DefeitoSoldagemMetaRequestDTO request)
        {
            var model = _mapper.Map<DefeitoSoldagemMeta>(request);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            model.DataHoraCadastro = DateTime.Now;
            model.UsuarioCadastro = await _usuarioSession.GetUsuarioLogado();
            model.IsAtivo = true;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_DefeitoSoldagemMeta");

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

                    var result = await _defeitoSoldagemMetaDomainService.AddAsync(model);

                    transaction.Complete();

                    return _mapper.Map<DefeitoSoldagemMetaResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }


            }


        }
        public async Task<DefeitoSoldagemMetaResponseDTO> UpdateAsync(long id, DefeitoSoldagemMetaRequestDTO request)
        {
            var model = _mapper.Map<DefeitoSoldagemMeta>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_DefeitoSoldagemMeta");

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

                    var result = await _defeitoSoldagemMetaDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<DefeitoSoldagemMetaResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }



        }

        public async Task<DefeitoSoldagemMetaResponseDTO> DeleteAsync(long id)
        {
            var model = await _defeitoSoldagemMetaDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_DefeitoSoldagemMeta".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $"Meta Aderência Programação Mensal do período {model.Meta} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _defeitoSoldagemMetaDomainService.DeleteAsync(id);

            return _mapper.Map<DefeitoSoldagemMetaResponseDTO>(result);

        }

        public async Task<DefeitoSoldagemMetaResponseDTO> GetByIdAsync(long id)
        {
            var result = await _defeitoSoldagemMetaDomainService.GetByIdAsync(id);
            return _mapper.Map<DefeitoSoldagemMetaResponseDTO>(result);
        }


        public async Task<List<DefeitoSoldagemMetaResponseDTO>> GetAllAsync()
        {
            var result = await _defeitoSoldagemMetaDomainService.GetAllAsync();

            return _mapper.Map<List<DefeitoSoldagemMetaResponseDTO>>(result);
        }

        public async Task<List<DefeitoSoldagemMetaResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _defeitoSoldagemMetaDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<DefeitoSoldagemMetaResponseDTO>>(result);
        }

        private async Task<List<LogCrud>> Logar(DefeitoSoldagemMetaRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            LogTabela logTabela = await _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == tabela.ToLower());


            //Log de diferenças
            if (request.Id != 0)
            {
                DefeitoSoldagemMeta requestOld = _mapper.Map<DefeitoSoldagemMeta>(GetByIdAsync(request.Id).Result);
                DefeitoSoldagemMeta requestNew = _mapper.Map<DefeitoSoldagemMeta>(request);

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
            _defeitoSoldagemMetaDomainService.Dispose();
        }


    }
}
