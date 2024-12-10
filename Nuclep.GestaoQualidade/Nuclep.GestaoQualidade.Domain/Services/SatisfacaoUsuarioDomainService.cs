using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class SatisfacaoUsuarioDomainService : ISatisfacaoUsuarioDomainService
    {
        private readonly ISatisfacaoUsuarioRepository _satisfacaoUsuarioRepository;

        public SatisfacaoUsuarioDomainService(
            ISatisfacaoUsuarioRepository satisfacaoUsuarioRepository)
        {
            _satisfacaoUsuarioRepository = satisfacaoUsuarioRepository;
        }

        public async Task<SatisfacaoUsuario> AddAsync(SatisfacaoUsuario entity)
        {
            await _satisfacaoUsuarioRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<SatisfacaoUsuario>> AddListAsync(List<SatisfacaoUsuario> entity)
        {
            foreach (var item in entity)
            {
                await _satisfacaoUsuarioRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<SatisfacaoUsuario> UpdateAsync(SatisfacaoUsuario entity)
        {
            if (!await _satisfacaoUsuarioRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Satisfação de Usuário com ID {entity.Id} não encontrada.");
            }

            await _satisfacaoUsuarioRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<SatisfacaoUsuario> DeleteAsync(long id)
        {
            var registro = await _satisfacaoUsuarioRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Satisfação de Usuário com ID {id} não encontrada.");
            }

            await _satisfacaoUsuarioRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<SatisfacaoUsuario?> GetByIdAsync(long id)
        {
            var registro = await _satisfacaoUsuarioRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Satisfação de Usuário com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<SatisfacaoUsuario>> GetAllAsync()
        {
            var registro = _satisfacaoUsuarioRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<SatisfacaoUsuario>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _satisfacaoUsuarioRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<SatisfacaoUsuario>> GetAllAtivosAsync()
        {
            var registro = _satisfacaoUsuarioRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _satisfacaoUsuarioRepository.Dispose();
        }


    }
}
