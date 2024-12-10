using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class TempoReparoEquipamentosProgramadosObrasDomainService : ITempoReparoEquipamentosProgramadosObrasDomainService
    {
        private readonly ITempoReparoEquipamentosProgramadosObrasRepository _tempoReparoEquipamentosProgramadosObrasRepository;

        public TempoReparoEquipamentosProgramadosObrasDomainService(
            ITempoReparoEquipamentosProgramadosObrasRepository tempoReparoEquipamentosProgramadosObrasRepository)
        {
            _tempoReparoEquipamentosProgramadosObrasRepository = tempoReparoEquipamentosProgramadosObrasRepository;
        }

        public async Task<TempoReparoEquipamentosProgramadosObras> AddAsync(TempoReparoEquipamentosProgramadosObras entity)
        {
            await _tempoReparoEquipamentosProgramadosObrasRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<TempoReparoEquipamentosProgramadosObras>> AddListAsync(List<TempoReparoEquipamentosProgramadosObras> entity)
        {
            foreach (var item in entity)
            {
                await _tempoReparoEquipamentosProgramadosObrasRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<TempoReparoEquipamentosProgramadosObras> UpdateAsync(TempoReparoEquipamentosProgramadosObras entity)
        {
            if (!await _tempoReparoEquipamentosProgramadosObrasRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Tempo Médio Solução com ID {entity.Id} não encontrada.");
            }

            await _tempoReparoEquipamentosProgramadosObrasRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<TempoReparoEquipamentosProgramadosObras> DeleteAsync(long id)
        {
            var registro = await _tempoReparoEquipamentosProgramadosObrasRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Tempo Médio Solução com ID {id} não encontrada.");
            }

            await _tempoReparoEquipamentosProgramadosObrasRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<TempoReparoEquipamentosProgramadosObras?> GetByIdAsync(long id)
        {
            var registro = await _tempoReparoEquipamentosProgramadosObrasRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Tempo Médio Solução com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllAsync()
        {
            var registro = _tempoReparoEquipamentosProgramadosObrasRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _tempoReparoEquipamentosProgramadosObrasRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<TempoReparoEquipamentosProgramadosObras>> GetAllAtivosAsync()
        {
            var registro = _tempoReparoEquipamentosProgramadosObrasRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _tempoReparoEquipamentosProgramadosObrasRepository.Dispose();
        }


    }
}
