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
    public class DuracaoProcessoLicitacaoMetaDomainService : IDuracaoProcessoLicitacaoMetaDomainService
    {
        private readonly IDuracaoProcessoLicitacaoMetaRepository _duracaoProcessoLicitacaoMetaRepository;

        public DuracaoProcessoLicitacaoMetaDomainService(
            IDuracaoProcessoLicitacaoMetaRepository duracaoProcessoLicitacaoMetaRepository)
        {
            _duracaoProcessoLicitacaoMetaRepository = duracaoProcessoLicitacaoMetaRepository;
        }

        public async Task<DuracaoProcessoLicitacaoMeta> AddAsync(DuracaoProcessoLicitacaoMeta entity)
        {
            await _duracaoProcessoLicitacaoMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<DuracaoProcessoLicitacaoMeta> UpdateAsync(DuracaoProcessoLicitacaoMeta entity)
        {
            if (!await _duracaoProcessoLicitacaoMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _duracaoProcessoLicitacaoMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<DuracaoProcessoLicitacaoMeta> DeleteAsync(long id)
        {
            var registro = await _duracaoProcessoLicitacaoMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _duracaoProcessoLicitacaoMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<DuracaoProcessoLicitacaoMeta?> GetByIdAsync(long id)
        {
            var registro = await _duracaoProcessoLicitacaoMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<DuracaoProcessoLicitacaoMeta>> GetAllAsync()
        {
            var registros = await _duracaoProcessoLicitacaoMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<DuracaoProcessoLicitacaoMeta>> GetAllAtivosAsync()
        {
            var registros = await _duracaoProcessoLicitacaoMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _duracaoProcessoLicitacaoMetaRepository.Dispose();
        }

    }
}

