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
    public class DuracaoProcessoLicitacaoMetaAppService : IDuracaoProcessoLicitacaoMetaAppService
    {
        private readonly IDuracaoProcessoLicitacaoMetaDomainService _duracaoProcessoLicitacaoMetaDomainService;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;



        public DuracaoProcessoLicitacaoMetaAppService(
            IDuracaoProcessoLicitacaoMetaDomainService duracaoProcessoLicitacaoMetaDomainService, 
            IMapper mapper, IUsuarioSession usuarioSession, ILogTabelaRepository logTabelaRepository, ILogCrudRepository logCrudRepository)
        {
            _duracaoProcessoLicitacaoMetaDomainService = duracaoProcessoLicitacaoMetaDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
        }

        public async Task<DuracaoProcessoLicitacaoMetaResponseDTO> AddAsync(DuracaoProcessoLicitacaoMetaRequestDTO request)
        {
            var model = _mapper.Map<DuracaoProcessoLicitacaoMeta>(request);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            model.DataHoraCadastro = DateTime.Now;
            model.UsuarioCadastro = await _usuarioSession.GetUsuarioLogado();
            model.IsAtivo = true;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_DuracaoProcessoLicitacaoMeta");

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

                    var result = await _duracaoProcessoLicitacaoMetaDomainService.AddAsync(model);

                    transaction.Complete();

                    return _mapper.Map<DuracaoProcessoLicitacaoMetaResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }


            }


        }
        public async Task<DuracaoProcessoLicitacaoMetaResponseDTO> UpdateAsync(long id, DuracaoProcessoLicitacaoMetaRequestDTO request)
        {
            var model = _mapper.Map<DuracaoProcessoLicitacaoMeta>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_DuracaoProcessoLicitacaoMeta");

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

                    var result = await _duracaoProcessoLicitacaoMetaDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<DuracaoProcessoLicitacaoMetaResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }

               

        }

        public async Task<DuracaoProcessoLicitacaoMetaResponseDTO> DeleteAsync(long id)
        {
            var model = await _duracaoProcessoLicitacaoMetaDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                Usuario = usuarioLogado,
                LogTipo = LogTipo.Cadastrado,
                LogTabela = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_DuracaoProcessoLicitacaoMeta".ToLower()).Result,
                IdReferencia = model.Id,
                Descricao = $"Meta Aderência Programação Mensal de valor {model.Meta} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _duracaoProcessoLicitacaoMetaDomainService.DeleteAsync(id);

            return _mapper.Map<DuracaoProcessoLicitacaoMetaResponseDTO>(result);

        }

        public async Task<DuracaoProcessoLicitacaoMetaResponseDTO> GetByIdAsync(long id)
        {
            var result = await _duracaoProcessoLicitacaoMetaDomainService.GetByIdAsync(id);
            return _mapper.Map<DuracaoProcessoLicitacaoMetaResponseDTO>(result);
        }


        public async Task<List<DuracaoProcessoLicitacaoMetaResponseDTO>> GetAllAsync()
        {
            var result = await _duracaoProcessoLicitacaoMetaDomainService.GetAllAsync();

            return _mapper.Map<List<DuracaoProcessoLicitacaoMetaResponseDTO>>(result);
        }

        public async Task<List<DuracaoProcessoLicitacaoMetaResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _duracaoProcessoLicitacaoMetaDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<DuracaoProcessoLicitacaoMetaResponseDTO>>(result);
        }

        private List<LogCrud> Logar(DuracaoProcessoLicitacaoMetaRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                DuracaoProcessoLicitacaoMeta requestOld = _mapper.Map<DuracaoProcessoLicitacaoMeta>(GetByIdAsync(request.Id).Result);
                DuracaoProcessoLicitacaoMeta requestNew = _mapper.Map<DuracaoProcessoLicitacaoMeta>(request);

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
            _duracaoProcessoLicitacaoMetaDomainService.Dispose();
        }


    }
}
