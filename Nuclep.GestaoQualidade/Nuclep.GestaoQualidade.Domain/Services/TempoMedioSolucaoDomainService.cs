using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class TempoMedioSolucaoDomainService : ITempoMedioSolucaoDomainService
    {
        private readonly ITempoMedioSolucaoRepository _tempoMedioSolucaoRepository;

        public TempoMedioSolucaoDomainService(
            ITempoMedioSolucaoRepository tempoMedioSolucaoRepository)
        {
            _tempoMedioSolucaoRepository = tempoMedioSolucaoRepository;
        }

        public async Task<TempoMedioSolucao> AddAsync(TempoMedioSolucao entity)
        {
            await _tempoMedioSolucaoRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<TempoMedioSolucao>> AddListAsync(List<TempoMedioSolucao> entity)
        {
            foreach (var item in entity)
            {
                await _tempoMedioSolucaoRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<TempoMedioSolucao> UpdateAsync(TempoMedioSolucao entity)
        {
            if (!await _tempoMedioSolucaoRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Tempo Médio Solução com ID {entity.Id} não encontrada.");
            }

            await _tempoMedioSolucaoRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<TempoMedioSolucao> DeleteAsync(long id)
        {
            var registro = await _tempoMedioSolucaoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Tempo Médio Solução com ID {id} não encontrada.");
            }

            await _tempoMedioSolucaoRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<TempoMedioSolucao?> GetByIdAsync(long id)
        {
            var registro = await _tempoMedioSolucaoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Tempo Médio Solução com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<TempoMedioSolucao>> GetAllAsync()
        {
            var registro = _tempoMedioSolucaoRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<TempoMedioSolucao>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _tempoMedioSolucaoRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<TempoMedioSolucao>> GetAllAtivosAsync()
        {
            var registro = _tempoMedioSolucaoRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _tempoMedioSolucaoRepository.Dispose();
        }


    }
}
