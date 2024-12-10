using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class TaxaConformidadeDocumentosQualidadeDomainService : ITaxaConformidadeDocumentosQualidadeDomainService
    {
        private readonly ITaxaConformidadeDocumentosQualidadeRepository _taxaConformidadeDocumentosQualidadeRepository;

        public TaxaConformidadeDocumentosQualidadeDomainService(
            ITaxaConformidadeDocumentosQualidadeRepository taxaConformidadeDocumentosQualidadeRepository)
        {
            _taxaConformidadeDocumentosQualidadeRepository = taxaConformidadeDocumentosQualidadeRepository;
        }

        public async Task<TaxaConformidadeDocumentosQualidade> AddAsync(TaxaConformidadeDocumentosQualidade entity)
        {
            await _taxaConformidadeDocumentosQualidadeRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<TaxaConformidadeDocumentosQualidade>> AddListAsync(List<TaxaConformidadeDocumentosQualidade> entity)
        {
            foreach (var item in entity)
            {
                await _taxaConformidadeDocumentosQualidadeRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<TaxaConformidadeDocumentosQualidade> UpdateAsync(TaxaConformidadeDocumentosQualidade entity)
        {
            if (!await _taxaConformidadeDocumentosQualidadeRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _taxaConformidadeDocumentosQualidadeRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<TaxaConformidadeDocumentosQualidade> DeleteAsync(long id)
        {
            var registro = await _taxaConformidadeDocumentosQualidadeRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _taxaConformidadeDocumentosQualidadeRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<TaxaConformidadeDocumentosQualidade?> GetByIdAsync(long id)
        {
            var registro = await _taxaConformidadeDocumentosQualidadeRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }

        public async Task<List<TaxaConformidadeDocumentosQualidade>> GetAllAsync()
        {
            var registros = await _taxaConformidadeDocumentosQualidadeRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<TaxaConformidadeDocumentosQualidade>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _taxaConformidadeDocumentosQualidadeRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<TaxaConformidadeDocumentosQualidade>> GetAllAtivosAsync()
        {
            var registros = await _taxaConformidadeDocumentosQualidadeRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _taxaConformidadeDocumentosQualidadeRepository.Dispose();
        }

    }
}

