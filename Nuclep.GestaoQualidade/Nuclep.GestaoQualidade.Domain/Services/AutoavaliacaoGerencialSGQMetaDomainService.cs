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
    public class AutoavaliacaoGerencialSGQMetaDomainService : IAutoavaliacaoGerencialSGQMetaDomainService
    {
        private readonly IAutoavaliacaoGerencialSGQMetaRepository _autoavaliacaoGerencialSGQMetaRepository;

        public AutoavaliacaoGerencialSGQMetaDomainService(
            IAutoavaliacaoGerencialSGQMetaRepository autoavaliacaoGerencialSGQMetaRepository)
        {
            _autoavaliacaoGerencialSGQMetaRepository = autoavaliacaoGerencialSGQMetaRepository;
        }

        public async Task<AutoavaliacaoGerencialSGQMeta> AddAsync(AutoavaliacaoGerencialSGQMeta entity)
        {
            await _autoavaliacaoGerencialSGQMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<AutoavaliacaoGerencialSGQMeta> UpdateAsync(AutoavaliacaoGerencialSGQMeta entity)
        {
            if (!await _autoavaliacaoGerencialSGQMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _autoavaliacaoGerencialSGQMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<AutoavaliacaoGerencialSGQMeta> DeleteAsync(long id)
        {
            var registro = await _autoavaliacaoGerencialSGQMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _autoavaliacaoGerencialSGQMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<AutoavaliacaoGerencialSGQMeta?> GetByIdAsync(long id)
        {
            var registro = await _autoavaliacaoGerencialSGQMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<AutoavaliacaoGerencialSGQMeta>> GetAllAsync()
        {
            var registros = await _autoavaliacaoGerencialSGQMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<AutoavaliacaoGerencialSGQMeta>> GetAllAtivosAsync()
        {
            var registros = await _autoavaliacaoGerencialSGQMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _autoavaliacaoGerencialSGQMetaRepository.Dispose();
        }

    }
}

