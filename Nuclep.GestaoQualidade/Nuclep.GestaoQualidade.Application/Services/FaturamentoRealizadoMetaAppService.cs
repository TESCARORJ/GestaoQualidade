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
    public class FaturamentoRealizadoMetaAppService : IFaturamentoRealizadoMetaAppService
    {
        private readonly IFaturamentoRealizadoMetaDomainService _faturamentoRealizadoMetaDomainService;
        private readonly IMapper _mapper;
        private IUsuarioSession _usuarioSession;
        private readonly ILogTabelaRepository _logTabelaRepository;
        private readonly ILogCrudRepository _logCrudRepository;



        public FaturamentoRealizadoMetaAppService(
            IFaturamentoRealizadoMetaDomainService faturamentoRealizadoMetaDomainService, 
            IMapper mapper, IUsuarioSession usuarioSession, ILogTabelaRepository logTabelaRepository, ILogCrudRepository logCrudRepository)
        {
            _faturamentoRealizadoMetaDomainService = faturamentoRealizadoMetaDomainService;
            _mapper = mapper;
            _usuarioSession = usuarioSession;
            _logTabelaRepository = logTabelaRepository;
            _logCrudRepository = logCrudRepository;
        }

        public async Task<FaturamentoRealizadoMetaResponseDTO> AddAsync(FaturamentoRealizadoMetaRequestDTO request)
        {
            var model = _mapper.Map<FaturamentoRealizadoMeta>(request);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            model.DataHoraCadastro = DateTime.Now;
            model.UsuarioCadastro = await _usuarioSession.GetUsuarioLogado();
            model.IsAtivo = true;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_FaturamentoRealizadoMeta");

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

                    var result = await _faturamentoRealizadoMetaDomainService.AddAsync(model);

                    transaction.Complete();

                    return _mapper.Map<FaturamentoRealizadoMetaResponseDTO>(result);

                }
                catch (Exception ex)
                {

                    throw;
                }


            }


        }
        public async Task<FaturamentoRealizadoMetaResponseDTO> UpdateAsync(long id, FaturamentoRealizadoMetaRequestDTO request)
        {
            var model = _mapper.Map<FaturamentoRealizadoMeta>(request);

            model.Id = id;

            // Adiciona o log de CRUD
            var logs = Logar(request, "Ind_FaturamentoRealizadoMeta");

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

                    var result = await _faturamentoRealizadoMetaDomainService.UpdateAsync(model);

                    transaction.Complete();

                    return _mapper.Map<FaturamentoRealizadoMetaResponseDTO>(result);
                }
                catch (Exception)
                {

                    throw;
                }
            }

               

        }

        public async Task<FaturamentoRealizadoMetaResponseDTO> DeleteAsync(long id)
        {
            var model = await _faturamentoRealizadoMetaDomainService.GetByIdAsync(id);
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;

            // Adiciona o log de CRUD
            var logCrud = new LogCrud
            {
                DataHoraCadastro = DateTime.Now,
                UsuarioId = usuarioLogado.Id,
                UsuarioNome = usuarioLogado.Nome,
                LogTipo = LogTipo.Cadastrado,
                LogTabelaId = _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower() == "Ind_FaturamentoRealizadoMeta".ToLower()).Result.Id,
                IdReferencia = model.Id,
                Descricao = $"Meta Aderência Programação Mensal de valor {model.Meta} excluída no sistema por {usuarioLogado.Nome}, ID: {usuarioLogado.Id} em {DateTime.Now}."
            };

            var result = await _faturamentoRealizadoMetaDomainService.DeleteAsync(id);

            return _mapper.Map<FaturamentoRealizadoMetaResponseDTO>(result);

        }

        public async Task<FaturamentoRealizadoMetaResponseDTO> GetByIdAsync(long id)
        {
            var result = await _faturamentoRealizadoMetaDomainService.GetByIdAsync(id);
            return _mapper.Map<FaturamentoRealizadoMetaResponseDTO>(result);
        }


        public async Task<List<FaturamentoRealizadoMetaResponseDTO>> GetAllAsync()
        {
            var result = await _faturamentoRealizadoMetaDomainService.GetAllAsync();

            return _mapper.Map<List<FaturamentoRealizadoMetaResponseDTO>>(result);
        }

        public async Task<List<FaturamentoRealizadoMetaResponseDTO>> GetAllAtivosAsync()
        {
            var result = await _faturamentoRealizadoMetaDomainService.GetAllAtivosAsync();

            return _mapper.Map<List<FaturamentoRealizadoMetaResponseDTO>>(result);
        }

        private List<LogCrud> Logar(FaturamentoRealizadoMetaRequestDTO request, string tabela)
        {
            var logs = new List<LogCrud>();
            var usuarioLogado = _usuarioSession.GetUsuarioLogado().Result;
            //Log de diferenças
            if (request.Id != 0)
            {
                FaturamentoRealizadoMeta requestOld = _mapper.Map<FaturamentoRealizadoMeta>(GetByIdAsync(request.Id).Result);
                FaturamentoRealizadoMeta requestNew = _mapper.Map<FaturamentoRealizadoMeta>(request);

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
                try
                {
                    logs.Add(new LogCrud(usuarioLogado.Id, usuarioLogado.Nome, LogTipo.Cadastrado,
                   _logTabelaRepository.GetOneAsync(x => x.Nome.ToLower().Equals(tabela.ToLower())).Result.Id, null,
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
            _faturamentoRealizadoMetaDomainService.Dispose();
        }


    }
}
