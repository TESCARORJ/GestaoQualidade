using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class DuracaoProcessoLicitacaoDomainService : IDuracaoProcessoLicitacaoDomainService
    {
        private readonly IDuracaoProcessoLicitacaoRepository _duracaoProcessoLicitacaoRepository;

        public DuracaoProcessoLicitacaoDomainService(
            IDuracaoProcessoLicitacaoRepository duracaoProcessoLicitacaoRepository)
        {
            _duracaoProcessoLicitacaoRepository = duracaoProcessoLicitacaoRepository;
        }

        public async Task<DuracaoProcessoLicitacao> AddAsync(DuracaoProcessoLicitacao entity)
        {
            await _duracaoProcessoLicitacaoRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<DuracaoProcessoLicitacao>> AddListAsync(List<DuracaoProcessoLicitacao> entity)
        {
            foreach (var item in entity)
            {
                await _duracaoProcessoLicitacaoRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<DuracaoProcessoLicitacao> UpdateAsync(DuracaoProcessoLicitacao entity)
        {
            if (!await _duracaoProcessoLicitacaoRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _duracaoProcessoLicitacaoRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<DuracaoProcessoLicitacao> DeleteAsync(long id)
        {
            var registro = await _duracaoProcessoLicitacaoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _duracaoProcessoLicitacaoRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<DuracaoProcessoLicitacao?> GetByIdAsync(long id)
        {
            var registro = await _duracaoProcessoLicitacaoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<DuracaoProcessoLicitacao>> GetAllAsync()
        {
            var registros = await _duracaoProcessoLicitacaoRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<DuracaoProcessoLicitacao>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _duracaoProcessoLicitacaoRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<DuracaoProcessoLicitacao>> GetAllAtivosAsync()
        {
            var registros = await _duracaoProcessoLicitacaoRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _duracaoProcessoLicitacaoRepository.Dispose();
        }

    }
}

