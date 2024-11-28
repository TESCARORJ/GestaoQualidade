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
    public class EficaciaTreinamentoMetaDomainService : IEficaciaTreinamentoMetaDomainService
    {
        private readonly IEficaciaTreinamentoMetaRepository _eficaciaTreinamentoMetaRepository;

        public EficaciaTreinamentoMetaDomainService(
            IEficaciaTreinamentoMetaRepository eficaciaTreinamentoMetaRepository)
        {
            _eficaciaTreinamentoMetaRepository = eficaciaTreinamentoMetaRepository;
        }

        public async Task<EficaciaTreinamentoMeta> AddAsync(EficaciaTreinamentoMeta entity)
        {
            await _eficaciaTreinamentoMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<EficaciaTreinamentoMeta> UpdateAsync(EficaciaTreinamentoMeta entity)
        {
            if (!await _eficaciaTreinamentoMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Eficácia de Treinamento com ID {entity.Id} não foi encontrada ");
            }

            await _eficaciaTreinamentoMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<EficaciaTreinamentoMeta> DeleteAsync(long id)
        {
            var registro = await _eficaciaTreinamentoMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Eficácia de Treinamento com ID {id} não foi encontrada ");
            }

            await _eficaciaTreinamentoMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<EficaciaTreinamentoMeta?> GetByIdAsync(long id)
        {
            var registro = await _eficaciaTreinamentoMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Eficácia de Treinamento com ID {id} não foi encontrada ");
            }

            return registro;
        }


        public async Task<List<EficaciaTreinamentoMeta>> GetAllAsync()
        {
            var registros = await _eficaciaTreinamentoMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<EficaciaTreinamentoMeta>> GetAllAtivosAsync()
        {
            var registros = await _eficaciaTreinamentoMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _eficaciaTreinamentoMetaRepository.Dispose();
        }

    }
}

