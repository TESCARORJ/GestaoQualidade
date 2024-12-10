using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class TempoMedioEmissaoOCItensCriticosMetaDomainService : ITempoMedioEmissaoOCItensCriticosMetaDomainService
    {
        private readonly ITempoMedioEmissaoOCItensCriticosMetaRepository _tempoMedioEmissaoOCItensCriticosMetaRepository;

        public TempoMedioEmissaoOCItensCriticosMetaDomainService(
            ITempoMedioEmissaoOCItensCriticosMetaRepository tempoMedioEmissaoOCItensCriticosMetaRepository)
        {
            _tempoMedioEmissaoOCItensCriticosMetaRepository = tempoMedioEmissaoOCItensCriticosMetaRepository;
        }

        public async Task<TempoMedioEmissaoOCItensCriticosMeta> AddAsync(TempoMedioEmissaoOCItensCriticosMeta entity)
        {
            await _tempoMedioEmissaoOCItensCriticosMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<TempoMedioEmissaoOCItensCriticosMeta> UpdateAsync(TempoMedioEmissaoOCItensCriticosMeta entity)
        {
            if (!await _tempoMedioEmissaoOCItensCriticosMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Tempo Médio de Emissão OC de Itens Criticos com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _tempoMedioEmissaoOCItensCriticosMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<TempoMedioEmissaoOCItensCriticosMeta> DeleteAsync(long id)
        {
            var registro = await _tempoMedioEmissaoOCItensCriticosMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Tempo Médio de Emissão OC de Itens Criticos com ID {id} não encontrada.");
            }

            await _tempoMedioEmissaoOCItensCriticosMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<TempoMedioEmissaoOCItensCriticosMeta?> GetByIdAsync(long id)
        {
            var registro = await _tempoMedioEmissaoOCItensCriticosMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Tempo Médio de Emissão OC de Itens Criticos com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllAsync()
        {
            var registros = await _tempoMedioEmissaoOCItensCriticosMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<TempoMedioEmissaoOCItensCriticosMeta>> GetAllAtivosAsync()
        {
            var registros = await _tempoMedioEmissaoOCItensCriticosMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _tempoMedioEmissaoOCItensCriticosMetaRepository.Dispose();
        }

    }
}
