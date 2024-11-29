using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class RejeicaoMateriaisDomainService : IRejeicaoMateriaisDomainService
    {
        private readonly IRejeicaoMateriaisRepository _rejeicaoMateriaisRepository;

        public RejeicaoMateriaisDomainService(
            IRejeicaoMateriaisRepository rejeicaoMateriaisRepository)
        {
            _rejeicaoMateriaisRepository = rejeicaoMateriaisRepository;
        }

        public async Task<RejeicaoMateriais> AddAsync(RejeicaoMateriais entity)
        {
            await _rejeicaoMateriaisRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<RejeicaoMateriais>> AddListAsync(List<RejeicaoMateriais> entity)
        {
            foreach (var item in entity)
            {
                await _rejeicaoMateriaisRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<RejeicaoMateriais> UpdateAsync(RejeicaoMateriais entity)
        {
            if (!await _rejeicaoMateriaisRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _rejeicaoMateriaisRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<RejeicaoMateriais> DeleteAsync(long id)
        {
            var registro = await _rejeicaoMateriaisRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _rejeicaoMateriaisRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<RejeicaoMateriais?> GetByIdAsync(long id)
        {
            var registro = await _rejeicaoMateriaisRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<RejeicaoMateriais>> GetAllAsync()
        {
            var registros = await _rejeicaoMateriaisRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

         public async Task<List<RejeicaoMateriais>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _rejeicaoMateriaisRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<RejeicaoMateriais>> GetAllAtivosAsync()
        {
            var registros = await _rejeicaoMateriaisRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _rejeicaoMateriaisRepository.Dispose();
        }

    }
}

