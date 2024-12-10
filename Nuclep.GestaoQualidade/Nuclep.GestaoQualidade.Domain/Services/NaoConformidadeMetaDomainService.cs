using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class NaoConformidadeMetaDomainService : INaoConformidadeMetaDomainService
    {
        private readonly INaoConformidadeMetaRepository _naoConformidadeMetaRepository;

        public NaoConformidadeMetaDomainService(
            INaoConformidadeMetaRepository naoConformidadeMetaRepository)
        {
            _naoConformidadeMetaRepository = naoConformidadeMetaRepository;
        }

        public async Task<NaoConformidadeMeta> AddAsync(NaoConformidadeMeta entity)
        {
            await _naoConformidadeMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<NaoConformidadeMeta> UpdateAsync(NaoConformidadeMeta entity)
        {
            if (!await _naoConformidadeMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Não Conformidade com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _naoConformidadeMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<NaoConformidadeMeta> DeleteAsync(long id)
        {
            var registro = await _naoConformidadeMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Não Conformidade com ID {id} não encontrada.");
            }

            await _naoConformidadeMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<NaoConformidadeMeta?> GetByIdAsync(long id)
        {
            var registro = await _naoConformidadeMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Não Conformidade com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<NaoConformidadeMeta>> GetAllAsync()
        {
            var registros = await _naoConformidadeMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<NaoConformidadeMeta>> GetAllAtivosAsync()
        {
            var registros = await _naoConformidadeMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _naoConformidadeMetaRepository.Dispose();
        }

    }
}
