using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class SatisfacaoClientesMetaDomainService : ISatisfacaoClientesMetaDomainService
    {
        private readonly ISatisfacaoClientesMetaRepository _satisfacaoClientesMetaRepository;

        public SatisfacaoClientesMetaDomainService(
            ISatisfacaoClientesMetaRepository satisfacaoClientesMetaRepository)
        {
            _satisfacaoClientesMetaRepository = satisfacaoClientesMetaRepository;
        }

        public async Task<SatisfacaoClientesMeta> AddAsync(SatisfacaoClientesMeta entity)
        {
            await _satisfacaoClientesMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<SatisfacaoClientesMeta> UpdateAsync(SatisfacaoClientesMeta entity)
        {
            if (!await _satisfacaoClientesMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Satisfação de Clientes com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _satisfacaoClientesMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<SatisfacaoClientesMeta> DeleteAsync(long id)
        {
            var registro = await _satisfacaoClientesMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Satisfação de Clientes com ID {id} não encontrada.");
            }

            await _satisfacaoClientesMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<SatisfacaoClientesMeta?> GetByIdAsync(long id)
        {
            var registro = await _satisfacaoClientesMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Satisfação de Clientes com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<SatisfacaoClientesMeta>> GetAllAsync()
        {
            var registros = await _satisfacaoClientesMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<SatisfacaoClientesMeta>> GetAllAtivosAsync()
        {
            var registros = await _satisfacaoClientesMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _satisfacaoClientesMetaRepository.Dispose();
        }

    }
}
