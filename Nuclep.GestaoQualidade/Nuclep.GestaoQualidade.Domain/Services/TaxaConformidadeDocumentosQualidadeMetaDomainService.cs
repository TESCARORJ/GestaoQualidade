using FluentValidation;
using Microsoft.Win32;
using Nuclep.GestaoQualidade.Domain.Extensions;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class TaxaConformidadeDocumentosQualidadeMetaDomainService : ITaxaConformidadeDocumentosQualidadeMetaDomainService
    {
        private readonly ITaxaConformidadeDocumentosQualidadeMetaRepository _taxaConformidadeDocumentosQualidadeMetaRepository;

        public TaxaConformidadeDocumentosQualidadeMetaDomainService(
            ITaxaConformidadeDocumentosQualidadeMetaRepository taxaConformidadeDocumentosQualidadeMetaRepository)
        {
            _taxaConformidadeDocumentosQualidadeMetaRepository = taxaConformidadeDocumentosQualidadeMetaRepository;
        }

        public async Task<TaxaConformidadeDocumentosQualidadeMeta> AddAsync(TaxaConformidadeDocumentosQualidadeMeta entity)
        {
            await _taxaConformidadeDocumentosQualidadeMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<TaxaConformidadeDocumentosQualidadeMeta> UpdateAsync(TaxaConformidadeDocumentosQualidadeMeta entity)
        {
            if (!await _taxaConformidadeDocumentosQualidadeMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _taxaConformidadeDocumentosQualidadeMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<TaxaConformidadeDocumentosQualidadeMeta> DeleteAsync(long id)
        {
            var registro = await _taxaConformidadeDocumentosQualidadeMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _taxaConformidadeDocumentosQualidadeMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<TaxaConformidadeDocumentosQualidadeMeta?> GetByIdAsync(long id)
        {
            var registro = await _taxaConformidadeDocumentosQualidadeMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<TaxaConformidadeDocumentosQualidadeMeta>> GetAllAsync()
        {
            var registros = await _taxaConformidadeDocumentosQualidadeMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<TaxaConformidadeDocumentosQualidadeMeta>> GetAllAtivosAsync()
        {
            var registros = await _taxaConformidadeDocumentosQualidadeMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _taxaConformidadeDocumentosQualidadeMetaRepository.Dispose();
        }

    }
}

