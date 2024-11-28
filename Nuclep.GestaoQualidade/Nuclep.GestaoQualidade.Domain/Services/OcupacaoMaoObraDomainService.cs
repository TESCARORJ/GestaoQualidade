using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class OcupacaoMaoObraDomainService : IOcupacaoMaoObraDomainService
    {
        private readonly IOcupacaoMaoObraRepository _ocupacaoMaoObraRepository;

        public OcupacaoMaoObraDomainService(
            IOcupacaoMaoObraRepository ocupacaoMaoObraRepository)
        {
            _ocupacaoMaoObraRepository = ocupacaoMaoObraRepository;
        }

        public async Task<OcupacaoMaoObra> AddAsync(OcupacaoMaoObra entity)
        {
            await _ocupacaoMaoObraRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<OcupacaoMaoObra>> AddListAsync(List<OcupacaoMaoObra> entity)
        {
            foreach (var item in entity)
            {
                await _ocupacaoMaoObraRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<OcupacaoMaoObra> UpdateAsync(OcupacaoMaoObra entity)
        {
            if (!await _ocupacaoMaoObraRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Aderência Programação Mensal com ID {entity.Id} não encontrada.");
            }

            await _ocupacaoMaoObraRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<OcupacaoMaoObra> DeleteAsync(long id)
        {
            var registro = await _ocupacaoMaoObraRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Aderência Programação Mensal com ID {id} não encontrada.");
            }

            await _ocupacaoMaoObraRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<OcupacaoMaoObra?> GetByIdAsync(long id)
        {
            var registro = await _ocupacaoMaoObraRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Aderência Programação Mensal com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<OcupacaoMaoObra>> GetAllAsync()
        {
            var registro = _ocupacaoMaoObraRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<OcupacaoMaoObra>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _ocupacaoMaoObraRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<OcupacaoMaoObra>> GetAllAtivosAsync()
        {
            var registro = _ocupacaoMaoObraRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _ocupacaoMaoObraRepository.Dispose();
        }


    }
}
