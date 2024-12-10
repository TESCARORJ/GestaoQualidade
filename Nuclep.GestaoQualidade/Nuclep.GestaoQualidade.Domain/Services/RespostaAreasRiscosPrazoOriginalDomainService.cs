using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class RespostaAreasRiscosPrazoOriginalDomainService : IRespostaAreasRiscosPrazoOriginalDomainService
    {
        private readonly IRespostaAreasRiscosPrazoOriginalRepository _respostaAreasRiscosPrazoOriginalRepository;

        public RespostaAreasRiscosPrazoOriginalDomainService(
            IRespostaAreasRiscosPrazoOriginalRepository respostaAreasRiscosPrazoOriginalRepository)
        {
            _respostaAreasRiscosPrazoOriginalRepository = respostaAreasRiscosPrazoOriginalRepository;
        }

        public async Task<RespostaAreasRiscosPrazoOriginal> AddAsync(RespostaAreasRiscosPrazoOriginal entity)
        {
            await _respostaAreasRiscosPrazoOriginalRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<RespostaAreasRiscosPrazoOriginal>> AddListAsync(List<RespostaAreasRiscosPrazoOriginal> entity)
        {
            foreach (var item in entity)
            {
                await _respostaAreasRiscosPrazoOriginalRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<RespostaAreasRiscosPrazoOriginal> UpdateAsync(RespostaAreasRiscosPrazoOriginal entity)
        {
            if (!await _respostaAreasRiscosPrazoOriginalRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Resposta de Áreas de Riscos Prazo Original com ID {entity.Id} não foi encontrado ");
            }

            await _respostaAreasRiscosPrazoOriginalRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<RespostaAreasRiscosPrazoOriginal> DeleteAsync(long id)
        {
            var registro = await _respostaAreasRiscosPrazoOriginalRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Resposta de Áreas de Riscos Prazo Original com ID {id} não foi encontrado ");
            }

            await _respostaAreasRiscosPrazoOriginalRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<RespostaAreasRiscosPrazoOriginal?> GetByIdAsync(long id)
        {
            var registro = await _respostaAreasRiscosPrazoOriginalRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Resposta de Áreas de Riscos Prazo Original com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllAsync()
        {
            var registros = await _respostaAreasRiscosPrazoOriginalRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

         public async Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _respostaAreasRiscosPrazoOriginalRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<RespostaAreasRiscosPrazoOriginal>> GetAllAtivosAsync()
        {
            var registros = await _respostaAreasRiscosPrazoOriginalRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _respostaAreasRiscosPrazoOriginalRepository.Dispose();
        }

    }
}

