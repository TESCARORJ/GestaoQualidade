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
    public class TempoReparoEquipamentosProgramadosObrasMetaDomainService : ITempoReparoEquipamentosProgramadosObrasMetaDomainService
    {
        private readonly ITempoReparoEquipamentosProgramadosObrasMetaRepository _tempoReparoEquipamentosProgramadosObrasMetaRepository;

        public TempoReparoEquipamentosProgramadosObrasMetaDomainService(
            ITempoReparoEquipamentosProgramadosObrasMetaRepository tempoReparoEquipamentosProgramadosObrasMetaRepository)
        {
            _tempoReparoEquipamentosProgramadosObrasMetaRepository = tempoReparoEquipamentosProgramadosObrasMetaRepository;
        }

        public async Task<TempoReparoEquipamentosProgramadosObrasMeta> AddAsync(TempoReparoEquipamentosProgramadosObrasMeta entity)
        {           
            await _tempoReparoEquipamentosProgramadosObrasMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<TempoReparoEquipamentosProgramadosObrasMeta> UpdateAsync(TempoReparoEquipamentosProgramadosObrasMeta entity)
        {
            if (!await _tempoReparoEquipamentosProgramadosObrasMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Tempo de Reparo de Equipamentos Programados Obras com ID {entity.Id} não foi encontrada ");
            }

            await _tempoReparoEquipamentosProgramadosObrasMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<TempoReparoEquipamentosProgramadosObrasMeta> DeleteAsync(long id)
        {
            var registro = await _tempoReparoEquipamentosProgramadosObrasMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Tempo de Reparo de Equipamentos Programados Obras com ID {id} não foi encontrada ");
            }

            await _tempoReparoEquipamentosProgramadosObrasMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<TempoReparoEquipamentosProgramadosObrasMeta?> GetByIdAsync(long id)
        {
            var registro = await _tempoReparoEquipamentosProgramadosObrasMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Tempo de Reparo de Equipamentos Programados Obras com ID {id} não foi encontrada ");
            }

            return registro;
        }

        public async Task<List<TempoReparoEquipamentosProgramadosObrasMeta>> GetAllAsync()
        {
            var registros = await _tempoReparoEquipamentosProgramadosObrasMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }
         public async Task<List<TempoReparoEquipamentosProgramadosObrasMeta>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _tempoReparoEquipamentosProgramadosObrasMetaRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<TempoReparoEquipamentosProgramadosObrasMeta>> GetAllAtivosAsync()
        {
            var registros = await _tempoReparoEquipamentosProgramadosObrasMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _tempoReparoEquipamentosProgramadosObrasMetaRepository.Dispose();
        }

    }
}

