using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class AutoavaliacaoGerencialSGQDomainService : IAutoavaliacaoGerencialSGQDomainService
    {
        private readonly IAutoavaliacaoGerencialSGQRepository _autoavaliacaoGerencialSGQRepository;

        public AutoavaliacaoGerencialSGQDomainService(
            IAutoavaliacaoGerencialSGQRepository autoavaliacaoGerencialSGQRepository)
        {
            _autoavaliacaoGerencialSGQRepository = autoavaliacaoGerencialSGQRepository;
        }

        public async Task<AutoavaliacaoGerencialSGQ> AddAsync(AutoavaliacaoGerencialSGQ entity)
        {
            await _autoavaliacaoGerencialSGQRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<AutoavaliacaoGerencialSGQ>> AddListAsync(List<AutoavaliacaoGerencialSGQ> entity)
        {
            foreach (var item in entity)
            {
                await _autoavaliacaoGerencialSGQRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<AutoavaliacaoGerencialSGQ> UpdateAsync(AutoavaliacaoGerencialSGQ entity)
        {
            if (!await _autoavaliacaoGerencialSGQRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _autoavaliacaoGerencialSGQRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<AutoavaliacaoGerencialSGQ> DeleteAsync(long id)
        {
            var registro = await _autoavaliacaoGerencialSGQRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _autoavaliacaoGerencialSGQRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<AutoavaliacaoGerencialSGQ?> GetByIdAsync(long id)
        {
            var registro = await _autoavaliacaoGerencialSGQRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }

        public async Task<List<AutoavaliacaoGerencialSGQ>> GetAllAsync()
        {
            var registros = await _autoavaliacaoGerencialSGQRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<AutoavaliacaoGerencialSGQ>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _autoavaliacaoGerencialSGQRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<AutoavaliacaoGerencialSGQ>> GetAllAtivosAsync()
        {
            var registros = await _autoavaliacaoGerencialSGQRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _autoavaliacaoGerencialSGQRepository.Dispose();
        }

    }
}

