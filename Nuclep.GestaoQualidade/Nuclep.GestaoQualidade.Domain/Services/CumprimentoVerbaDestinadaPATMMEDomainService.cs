using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class CumprimentoVerbaDestinadaPATMMEDomainService : ICumprimentoVerbaDestinadaPATMMEDomainService
    {
        private readonly ICumprimentoVerbaDestinadaPATMMERepository _cumprimentoVerbaDestinadaPATMMERepository;

        public CumprimentoVerbaDestinadaPATMMEDomainService(
            ICumprimentoVerbaDestinadaPATMMERepository cumprimentoVerbaDestinadaPATMMERepository)
        {
            _cumprimentoVerbaDestinadaPATMMERepository = cumprimentoVerbaDestinadaPATMMERepository;
        }

        public async Task<CumprimentoVerbaDestinadaPATMME> AddAsync(CumprimentoVerbaDestinadaPATMME entity)
        {
            await _cumprimentoVerbaDestinadaPATMMERepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<CumprimentoVerbaDestinadaPATMME>> AddListAsync(List<CumprimentoVerbaDestinadaPATMME> entity)
        {
            foreach (var item in entity)
            {
                await _cumprimentoVerbaDestinadaPATMMERepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<CumprimentoVerbaDestinadaPATMME> UpdateAsync(CumprimentoVerbaDestinadaPATMME entity)
        {
            if (!await _cumprimentoVerbaDestinadaPATMMERepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Cumprimento de Verba Destinada ao PAT pelo MME com ID {entity.Id} não foi encontrada ");
            }

            await _cumprimentoVerbaDestinadaPATMMERepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<CumprimentoVerbaDestinadaPATMME> DeleteAsync(long id)
        {
            var registro = await _cumprimentoVerbaDestinadaPATMMERepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Cumprimento de Verba Destinada ao PAT pelo MME com ID {id} não foi encontrada ");
            }

            await _cumprimentoVerbaDestinadaPATMMERepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<CumprimentoVerbaDestinadaPATMME?> GetByIdAsync(long id)
        {
            var registro = await _cumprimentoVerbaDestinadaPATMMERepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Cumprimento de Verba Destinada ao PAT pelo MME com ID {id} não foi encontrada ");
            }

            return registro;
        }


        public async Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllAsync()
        {
            var registros = await _cumprimentoVerbaDestinadaPATMMERepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }
         public async Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _cumprimentoVerbaDestinadaPATMMERepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<CumprimentoVerbaDestinadaPATMME>> GetAllAtivosAsync()
        {
            var registros = await _cumprimentoVerbaDestinadaPATMMERepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _cumprimentoVerbaDestinadaPATMMERepository.Dispose();
        }

    }
}

