using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UsuarioDomainService(
            IUsuarioRepository UsuarioRepository
            )
        {
            _UsuarioRepository = UsuarioRepository;
        }

        public async Task<Usuario> AddAsync(Usuario entity)
        {
            await _UsuarioRepository.AddAsync(entity);
            return entity;
        }

        public async Task<Usuario> UpdateAsync(Usuario entity)
        {
            if (!await _UsuarioRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Usuário com ID {entity.Id} não foi encontrada ");
            }

            try
            {
                await _UsuarioRepository.UpdateAsync(entity);

            }
            catch (Exception ex)
            {

                throw;
            }

            return entity;

        }

        public async Task<Usuario> DeleteAsync(long id)
        {
            var registro = await _UsuarioRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Usuário com ID {id} não foi encontrado ");
            }

            await _UsuarioRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<Usuario?> GetByIdAsync(long id)
        {
            var registro = await _UsuarioRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Usuário com ID {id} não foi encontrado ");
            }

            return registro;
        }

        public async Task<Usuario?> GetByNameAsync(string nome)
        {
            var registro = await _UsuarioRepository.GetOneAsync(x => x.Nome == nome);

            if (registro == null)
            {
                throw new Exception($"Usuário com Nome {nome} não foi encontrado");
            }

            return registro;
        }

         public async Task<Usuario?> GetByLoginAsync(string login)
        {
            var registro = await _UsuarioRepository.GetOneAsync(x => x.NomeAD == login);

            if (registro == null)
            {
                throw new Exception($"Usuário com Nome {login} não foi encontrado");
            }

            return registro;
        }

        

        public async Task<List<Usuario?>> GetByNameListAsync(string nome)
        {
            var registro = _UsuarioRepository.GetAllAsync().Result.Where(x => x.Nome.Contains(nome)).ToList();

            if (registro == null)
            {
                throw new Exception($"Usuário com Nome {nome} não foi encontrado");
            }

            return registro;
        }


        public async Task<List<Usuario>> GetAllAsync()
        {
            var registros = await _UsuarioRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<Usuario>> GetAllAtivosAsync()
        {
            var registros = await _UsuarioRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }

        public async Task<bool> ExisteUsuario(string nomeAD)
        {
            var registro = await _UsuarioRepository.VerifyExistsAsync(x => x.NomeAD == nomeAD);

            if (registro == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registro;
        }

        public void Dispose()
        {
            _UsuarioRepository.Dispose();
        }

    }
}

