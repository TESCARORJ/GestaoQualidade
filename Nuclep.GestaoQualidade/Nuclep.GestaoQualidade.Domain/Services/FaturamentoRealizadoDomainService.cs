using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class FaturamentoRealizadoDomainService : IFaturamentoRealizadoDomainService
    {
        private readonly IFaturamentoRealizadoRepository _faturamentoRealizadoRepository;

        public FaturamentoRealizadoDomainService(
            IFaturamentoRealizadoRepository faturamentoRealizadoRepository)
        {
            _faturamentoRealizadoRepository = faturamentoRealizadoRepository;
        }

        public async Task<FaturamentoRealizado> AddAsync(FaturamentoRealizado entity)
        {
            await _faturamentoRealizadoRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<FaturamentoRealizado>> AddListAsync(List<FaturamentoRealizado> entity)
        {
            foreach (var item in entity)
            {
                await _faturamentoRealizadoRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<FaturamentoRealizado> UpdateAsync(FaturamentoRealizado entity)
        {
            if (!await _faturamentoRealizadoRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Faturamento Realizados com ID {entity.Id} não foi encontrado ");
            }

            await _faturamentoRealizadoRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<FaturamentoRealizado> DeleteAsync(long id)
        {
            var registro = await _faturamentoRealizadoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            await _faturamentoRealizadoRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<FaturamentoRealizado?> GetByIdAsync(long id)
        {
            var registro = await _faturamentoRealizadoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Faturamento Realizados com ID {id} não foi encontrado ");
            }

            return registro;
        }


        public async Task<List<FaturamentoRealizado>> GetAllAsync()
        {
            var registros = await _faturamentoRealizadoRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

         public async Task<List<FaturamentoRealizado>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _faturamentoRealizadoRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<FaturamentoRealizado>> GetAllAtivosAsync()
        {
            var registros = await _faturamentoRealizadoRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _faturamentoRealizadoRepository.Dispose();
        }

    }
}

