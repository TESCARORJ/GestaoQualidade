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
    public class RespostaAreasRiscosPrazoOriginalMetaDomainService : IRespostaAreasRiscosPrazoOriginalMetaDomainService
    {
        private readonly IRespostaAreasRiscosPrazoOriginalMetaRepository _respostaAreasRiscosPrazoOriginalMetaRepository;

        public RespostaAreasRiscosPrazoOriginalMetaDomainService(
            IRespostaAreasRiscosPrazoOriginalMetaRepository respostaAreasRiscosPrazoOriginalMetaRepository)
        {
            _respostaAreasRiscosPrazoOriginalMetaRepository = respostaAreasRiscosPrazoOriginalMetaRepository;
        }

        public async Task<RespostaAreasRiscosPrazoOriginalMeta> AddAsync(RespostaAreasRiscosPrazoOriginalMeta entity)
        {
            await _respostaAreasRiscosPrazoOriginalMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<RespostaAreasRiscosPrazoOriginalMeta> UpdateAsync(RespostaAreasRiscosPrazoOriginalMeta entity)
        {
            if (!await _respostaAreasRiscosPrazoOriginalMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Resposta de Áreas de Riscos Prazo Original com ID {entity.Id} não foi encontrado ");
            }

            await _respostaAreasRiscosPrazoOriginalMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<RespostaAreasRiscosPrazoOriginalMeta> DeleteAsync(long id)
        {
            var registro = await _respostaAreasRiscosPrazoOriginalMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Resposta de Áreas de Riscos Prazo Original com ID {id} não foi encontrado ");
            }

            await _respostaAreasRiscosPrazoOriginalMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<RespostaAreasRiscosPrazoOriginalMeta?> GetByIdAsync(long id)
        {
            var registro = await _respostaAreasRiscosPrazoOriginalMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Resposta de Áreas de Riscos Prazo Original com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllAsync()
        {
            var registros = await _respostaAreasRiscosPrazoOriginalMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<RespostaAreasRiscosPrazoOriginalMeta>> GetAllAtivosAsync()
        {
            var registros = await _respostaAreasRiscosPrazoOriginalMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _respostaAreasRiscosPrazoOriginalMetaRepository.Dispose();
        }

    }
}

