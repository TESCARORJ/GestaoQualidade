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
    public class AcaoCorrecaoAvaliadaEficazMetaDomainService : IAcaoCorrecaoAvaliadaEficazMetaDomainService
    {
        private readonly IAcaoCorrecaoAvaliadaEficazMetaRepository _acaoCorrecaoAvaliadaEficazMetaRepository;

        public AcaoCorrecaoAvaliadaEficazMetaDomainService(
            IAcaoCorrecaoAvaliadaEficazMetaRepository acaoCorrecaoAvaliadaEficazMetaRepository)
        {
            _acaoCorrecaoAvaliadaEficazMetaRepository = acaoCorrecaoAvaliadaEficazMetaRepository;
        }

        public async Task<AcaoCorrecaoAvaliadaEficazMeta> AddAsync(AcaoCorrecaoAvaliadaEficazMeta entity)
        {
            await _acaoCorrecaoAvaliadaEficazMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<AcaoCorrecaoAvaliadaEficazMeta> UpdateAsync(AcaoCorrecaoAvaliadaEficazMeta entity)
        {
            if (!await _acaoCorrecaoAvaliadaEficazMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Ação Correção Avaliada Eficaz com ID {entity.Id} não foi encontrada ");
            }

            await _acaoCorrecaoAvaliadaEficazMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<AcaoCorrecaoAvaliadaEficazMeta> DeleteAsync(long id)
        {
            var registro = await _acaoCorrecaoAvaliadaEficazMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Ação Correção Avaliada Eficaz com ID {id} não foi encontrada ");
            }

            await _acaoCorrecaoAvaliadaEficazMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<AcaoCorrecaoAvaliadaEficazMeta?> GetByIdAsync(long id)
        {
            var registro = await _acaoCorrecaoAvaliadaEficazMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Ação Correção Avaliada Eficaz com ID {id} não foi encontrada ");
            }

            return registro;
        }


        public async Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAsync()
        {
            var registros = await _acaoCorrecaoAvaliadaEficazMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<AcaoCorrecaoAvaliadaEficazMeta>> GetAllAtivosAsync()
        {
            var registros = await _acaoCorrecaoAvaliadaEficazMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _acaoCorrecaoAvaliadaEficazMetaRepository.Dispose();
        }

    }
}

