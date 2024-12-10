using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class SatisfacaoClientesDomainService : ISatisfacaoClientesDomainService
    {
        private readonly ISatisfacaoClientesRepository _satisfacaoClientesRepository;

        public SatisfacaoClientesDomainService(
            ISatisfacaoClientesRepository satisfacaoClientesRepository)
        {
            _satisfacaoClientesRepository = satisfacaoClientesRepository;
        }

        public async Task<SatisfacaoClientes> AddAsync(SatisfacaoClientes entity)
        {
            await _satisfacaoClientesRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<SatisfacaoClientes>> AddListAsync(List<SatisfacaoClientes> entity)
        {
            foreach (var item in entity)
            {
                await _satisfacaoClientesRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<SatisfacaoClientes> UpdateAsync(SatisfacaoClientes entity)
        {
            if (!await _satisfacaoClientesRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Satisfação de Clientes com ID {entity.Id} não encontrada.");
            }

            await _satisfacaoClientesRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<SatisfacaoClientes> DeleteAsync(long id)
        {
            var registro = await _satisfacaoClientesRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Satisfação de Clientes com ID {id} não encontrada.");
            }

            await _satisfacaoClientesRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<SatisfacaoClientes?> GetByIdAsync(long id)
        {
            var registro = await _satisfacaoClientesRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Satisfação de Clientes com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<SatisfacaoClientes>> GetAllAsync()
        {
            var registro = _satisfacaoClientesRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<SatisfacaoClientes>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _satisfacaoClientesRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<SatisfacaoClientes>> GetAllAtivosAsync()
        {
            var registro = _satisfacaoClientesRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _satisfacaoClientesRepository.Dispose();
        }


    }
}
