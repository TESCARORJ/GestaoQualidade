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
    public class FaturamentoRealizadoMetaDomainService : IFaturamentoRealizadoMetaDomainService
    {
        private readonly IFaturamentoRealizadoMetaRepository _faturamentoRealizadoMetaRepository;

        public FaturamentoRealizadoMetaDomainService(
            IFaturamentoRealizadoMetaRepository faturamentoRealizadoMetaRepository)
        {
            _faturamentoRealizadoMetaRepository = faturamentoRealizadoMetaRepository;
        }

        public async Task<FaturamentoRealizadoMeta> AddAsync(FaturamentoRealizadoMeta entity)
        {
            await _faturamentoRealizadoMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<FaturamentoRealizadoMeta> UpdateAsync(FaturamentoRealizadoMeta entity)
        {
            if (!await _faturamentoRealizadoMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _faturamentoRealizadoMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<FaturamentoRealizadoMeta> DeleteAsync(long id)
        {
            var registro = await _faturamentoRealizadoMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _faturamentoRealizadoMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<FaturamentoRealizadoMeta?> GetByIdAsync(long id)
        {
            var registro = await _faturamentoRealizadoMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<FaturamentoRealizadoMeta>> GetAllAsync()
        {
            var registros = await _faturamentoRealizadoMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<FaturamentoRealizadoMeta>> GetAllAtivosAsync()
        {
            var registros = await _faturamentoRealizadoMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _faturamentoRealizadoMetaRepository.Dispose();
        }

    }
}

