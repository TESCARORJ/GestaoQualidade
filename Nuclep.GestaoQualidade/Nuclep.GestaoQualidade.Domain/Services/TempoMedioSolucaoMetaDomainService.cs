using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class TempoMedioSolucaoMetaDomainService : ITempoMedioSolucaoMetaDomainService
    {
        private readonly ITempoMedioSolucaoMetaRepository _tempoMedioSolucaoMetaRepository;

        public TempoMedioSolucaoMetaDomainService(
            ITempoMedioSolucaoMetaRepository tempoMedioSolucaoMetaRepository)
        {
            _tempoMedioSolucaoMetaRepository = tempoMedioSolucaoMetaRepository;
        }

        public async Task<TempoMedioSolucaoMeta> AddAsync(TempoMedioSolucaoMeta entity)
        {
            await _tempoMedioSolucaoMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<TempoMedioSolucaoMeta> UpdateAsync(TempoMedioSolucaoMeta entity)
        {
            if (!await _tempoMedioSolucaoMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Tempo Médio Solução com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _tempoMedioSolucaoMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<TempoMedioSolucaoMeta> DeleteAsync(long id)
        {
            var registro = await _tempoMedioSolucaoMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Tempo Médio Solução com ID {id} não encontrada.");
            }

            await _tempoMedioSolucaoMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<TempoMedioSolucaoMeta?> GetByIdAsync(long id)
        {
            var registro = await _tempoMedioSolucaoMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Tempo Médio Solução com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<TempoMedioSolucaoMeta>> GetAllAsync()
        {
            var registros = await _tempoMedioSolucaoMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<TempoMedioSolucaoMeta>> GetAllAtivosAsync()
        {
            var registros = await _tempoMedioSolucaoMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _tempoMedioSolucaoMetaRepository.Dispose();
        }

    }
}
