using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class NaoConformidadeDomainService : INaoConformidadeDomainService
    {
        private readonly INaoConformidadeRepository _naoConformidadeRepository;

        public NaoConformidadeDomainService(
            INaoConformidadeRepository naoConformidadeRepository)
        {
            _naoConformidadeRepository = naoConformidadeRepository;
        }

        public async Task<NaoConformidade> AddAsync(NaoConformidade entity)
        {
            await _naoConformidadeRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<NaoConformidade>> AddListAsync(List<NaoConformidade> entity)
        {
            foreach (var item in entity)
            {
                await _naoConformidadeRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<NaoConformidade> UpdateAsync(NaoConformidade entity)
        {
            if (!await _naoConformidadeRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Não Conformidade com ID {entity.Id} não encontrada.");
            }

            await _naoConformidadeRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<NaoConformidade> DeleteAsync(long id)
        {
            var registro = await _naoConformidadeRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Não Conformidade com ID {id} não encontrada.");
            }

            await _naoConformidadeRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<NaoConformidade?> GetByIdAsync(long id)
        {
            var registro = await _naoConformidadeRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Não Conformidade com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<NaoConformidade>> GetAllAsync()
        {
            var registro = _naoConformidadeRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<NaoConformidade>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _naoConformidadeRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<NaoConformidade>> GetAllAtivosAsync()
        {
            var registro = _naoConformidadeRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _naoConformidadeRepository.Dispose();
        }


    }
}
