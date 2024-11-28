using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class EficaciaTreinamentoDomainService : IEficaciaTreinamentoDomainService
    {
        private readonly IEficaciaTreinamentoRepository _eficaciaTreinamentoRepository;

        public EficaciaTreinamentoDomainService(
            IEficaciaTreinamentoRepository eficaciaTreinamentoRepository)
        {
            _eficaciaTreinamentoRepository = eficaciaTreinamentoRepository;
        }

        public async Task<EficaciaTreinamento> AddAsync(EficaciaTreinamento entity)
        {
            await _eficaciaTreinamentoRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<EficaciaTreinamento>> AddListAsync(List<EficaciaTreinamento> entity)
        {
            foreach (var item in entity)
            {
                await _eficaciaTreinamentoRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<EficaciaTreinamento> UpdateAsync(EficaciaTreinamento entity)
        {
            if (!await _eficaciaTreinamentoRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Eficácia de Treinamento com ID {entity.Id} não foi encontrada ");
            }

            await _eficaciaTreinamentoRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<EficaciaTreinamento> DeleteAsync(long id)
        {
            var registro = await _eficaciaTreinamentoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Eficácia de Treinamento com ID {id} não foi encontrada ");
            }

            await _eficaciaTreinamentoRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<EficaciaTreinamento?> GetByIdAsync(long id)
        {
            var registro = await _eficaciaTreinamentoRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Eficácia de Treinamento com ID {id} não foi encontrada ");
            }

            return registro;
        }


        public async Task<List<EficaciaTreinamento>> GetAllAsync()
        {
            var registros = await _eficaciaTreinamentoRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }
         public async Task<List<EficaciaTreinamento>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _eficaciaTreinamentoRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<EficaciaTreinamento>> GetAllAtivosAsync()
        {
            var registros = await _eficaciaTreinamentoRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _eficaciaTreinamentoRepository.Dispose();
        }

    }
}

