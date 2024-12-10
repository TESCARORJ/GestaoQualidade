using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class SatisfacaoUsuarioMetaDomainService : ISatisfacaoUsuarioMetaDomainService
    {
        private readonly ISatisfacaoUsuarioMetaRepository _satisfacaoUsuarioMetaRepository;

        public SatisfacaoUsuarioMetaDomainService(
            ISatisfacaoUsuarioMetaRepository satisfacaoUsuarioMetaRepository)
        {
            _satisfacaoUsuarioMetaRepository = satisfacaoUsuarioMetaRepository;
        }

        public async Task<SatisfacaoUsuarioMeta> AddAsync(SatisfacaoUsuarioMeta entity)
        {
            await _satisfacaoUsuarioMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<SatisfacaoUsuarioMeta> UpdateAsync(SatisfacaoUsuarioMeta entity)
        {
            if (!await _satisfacaoUsuarioMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Satisfação de Usuário com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _satisfacaoUsuarioMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<SatisfacaoUsuarioMeta> DeleteAsync(long id)
        {
            var registro = await _satisfacaoUsuarioMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Satisfação de Usuário com ID {id} não encontrada.");
            }

            await _satisfacaoUsuarioMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<SatisfacaoUsuarioMeta?> GetByIdAsync(long id)
        {
            var registro = await _satisfacaoUsuarioMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Satisfação de Usuário com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<SatisfacaoUsuarioMeta>> GetAllAsync()
        {
            var registros = await _satisfacaoUsuarioMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<SatisfacaoUsuarioMeta>> GetAllAtivosAsync()
        {
            var registros = await _satisfacaoUsuarioMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _satisfacaoUsuarioMetaRepository.Dispose();
        }

    }
}
