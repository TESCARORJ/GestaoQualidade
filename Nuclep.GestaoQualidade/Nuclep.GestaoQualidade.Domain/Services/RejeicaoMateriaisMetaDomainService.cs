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
    public class RejeicaoMateriaisMetaDomainService : IRejeicaoMateriaisMetaDomainService
    {
        private readonly IRejeicaoMateriaisMetaRepository _rejeicaoMateriaisMetaRepository;

        public RejeicaoMateriaisMetaDomainService(
            IRejeicaoMateriaisMetaRepository rejeicaoMateriaisMetaRepository)
        {
            _rejeicaoMateriaisMetaRepository = rejeicaoMateriaisMetaRepository;
        }

        public async Task<RejeicaoMateriaisMeta> AddAsync(RejeicaoMateriaisMeta entity)
        {
            await _rejeicaoMateriaisMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<RejeicaoMateriaisMeta> UpdateAsync(RejeicaoMateriaisMeta entity)
        {
            if (!await _rejeicaoMateriaisMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Rejeição de Materiais com ID {entity.Id} não foi encontrado ");
            }

            await _rejeicaoMateriaisMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<RejeicaoMateriaisMeta> DeleteAsync(long id)
        {
            var registro = await _rejeicaoMateriaisMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Rejeição de Materiais com ID {id} não foi encontrado ");
            }

            await _rejeicaoMateriaisMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<RejeicaoMateriaisMeta?> GetByIdAsync(long id)
        {
            var registro = await _rejeicaoMateriaisMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Rejeição de Materiais com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<RejeicaoMateriaisMeta>> GetAllAsync()
        {
            var registros = await _rejeicaoMateriaisMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<RejeicaoMateriaisMeta>> GetAllAtivosAsync()
        {
            var registros = await _rejeicaoMateriaisMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _rejeicaoMateriaisMetaRepository.Dispose();
        }

    }
}

