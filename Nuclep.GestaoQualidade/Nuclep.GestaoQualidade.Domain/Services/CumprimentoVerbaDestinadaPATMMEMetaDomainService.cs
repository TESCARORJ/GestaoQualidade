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
    public class CumprimentoVerbaDestinadaPATMMEMetaDomainService : ICumprimentoVerbaDestinadaPATMMEMetaDomainService
    {
        private readonly ICumprimentoVerbaDestinadaPATMMEMetaRepository _cumprimentoVerbaDestinadaPATMMEMetaRepository;

        public CumprimentoVerbaDestinadaPATMMEMetaDomainService(
            ICumprimentoVerbaDestinadaPATMMEMetaRepository cumprimentoVerbaDestinadaPATMMEMetaRepository)
        {
            _cumprimentoVerbaDestinadaPATMMEMetaRepository = cumprimentoVerbaDestinadaPATMMEMetaRepository;
        }

        public async Task<CumprimentoVerbaDestinadaPATMMEMeta> AddAsync(CumprimentoVerbaDestinadaPATMMEMeta entity)
        {
            await _cumprimentoVerbaDestinadaPATMMEMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<CumprimentoVerbaDestinadaPATMMEMeta> UpdateAsync(CumprimentoVerbaDestinadaPATMMEMeta entity)
        {
            if (!await _cumprimentoVerbaDestinadaPATMMEMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Cumprimento de Verba Destinada ao PAT pelo MME com ID {entity.Id} não foi encontrada ");
            }

            await _cumprimentoVerbaDestinadaPATMMEMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<CumprimentoVerbaDestinadaPATMMEMeta> DeleteAsync(long id)
        {
            var registro = await _cumprimentoVerbaDestinadaPATMMEMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Cumprimento de Verba Destinada ao PAT pelo MME com ID {id} não foi encontrada ");
            }

            await _cumprimentoVerbaDestinadaPATMMEMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<CumprimentoVerbaDestinadaPATMMEMeta?> GetByIdAsync(long id)
        {
            var registro = await _cumprimentoVerbaDestinadaPATMMEMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Cumprimento de Verba Destinada ao PAT pelo MME com ID {id} não foi encontrada ");
            }

            return registro;
        }


        public async Task<List<CumprimentoVerbaDestinadaPATMMEMeta>> GetAllAsync()
        {
            var registros = await _cumprimentoVerbaDestinadaPATMMEMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<CumprimentoVerbaDestinadaPATMMEMeta>> GetAllAtivosAsync()
        {
            var registros = await _cumprimentoVerbaDestinadaPATMMEMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _cumprimentoVerbaDestinadaPATMMEMetaRepository.Dispose();
        }

    }
}

