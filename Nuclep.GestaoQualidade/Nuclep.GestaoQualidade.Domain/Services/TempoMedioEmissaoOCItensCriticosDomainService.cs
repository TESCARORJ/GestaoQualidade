using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class TempoMedioEmissaoOCItensCriticosDomainService : ITempoMedioEmissaoOCItensCriticosDomainService
    {
        private readonly ITempoMedioEmissaoOCItensCriticosRepository _tempoMedioEmissaoOCItensCriticosRepository;

        public TempoMedioEmissaoOCItensCriticosDomainService(
            ITempoMedioEmissaoOCItensCriticosRepository tempoMedioEmissaoOCItensCriticosRepository)
        {
            _tempoMedioEmissaoOCItensCriticosRepository = tempoMedioEmissaoOCItensCriticosRepository;
        }

        public async Task<TempoMedioEmissaoOCItensCriticos> AddAsync(TempoMedioEmissaoOCItensCriticos entity)
        {
            await _tempoMedioEmissaoOCItensCriticosRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<TempoMedioEmissaoOCItensCriticos>> AddListAsync(List<TempoMedioEmissaoOCItensCriticos> entity)
        {
            foreach (var item in entity)
            {
                await _tempoMedioEmissaoOCItensCriticosRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<TempoMedioEmissaoOCItensCriticos> UpdateAsync(TempoMedioEmissaoOCItensCriticos entity)
        {
            if (!await _tempoMedioEmissaoOCItensCriticosRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Tempo Médio de Emissão OC de Itens Criticos com ID {entity.Id} não encontrada.");
            }

            await _tempoMedioEmissaoOCItensCriticosRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<TempoMedioEmissaoOCItensCriticos> DeleteAsync(long id)
        {
            var registro = await _tempoMedioEmissaoOCItensCriticosRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Tempo Médio de Emissão OC de Itens Criticos com ID {id} não encontrada.");
            }

            await _tempoMedioEmissaoOCItensCriticosRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<TempoMedioEmissaoOCItensCriticos?> GetByIdAsync(long id)
        {
            var registro = await _tempoMedioEmissaoOCItensCriticosRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Tempo Médio de Emissão OC de Itens Criticos com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllAsync()
        {
            var registro = _tempoMedioEmissaoOCItensCriticosRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _tempoMedioEmissaoOCItensCriticosRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<TempoMedioEmissaoOCItensCriticos>> GetAllAtivosAsync()
        {
            var registro = _tempoMedioEmissaoOCItensCriticosRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _tempoMedioEmissaoOCItensCriticosRepository.Dispose();
        }


    }
}
