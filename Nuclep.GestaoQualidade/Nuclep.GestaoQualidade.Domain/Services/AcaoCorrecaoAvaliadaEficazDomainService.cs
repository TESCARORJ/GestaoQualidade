using FluentValidation;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class AcaoCorrecaoAvaliadaEficazDomainService : IAcaoCorrecaoAvaliadaEficazDomainService
    {
        private readonly IAcaoCorrecaoAvaliadaEficazRepository _acaoCorrecaoAvaliadaEficazRepository;

        public AcaoCorrecaoAvaliadaEficazDomainService(
            IAcaoCorrecaoAvaliadaEficazRepository acaoCorrecaoAvaliadaEficazRepository)
        {
            _acaoCorrecaoAvaliadaEficazRepository = acaoCorrecaoAvaliadaEficazRepository;
        }

        public async Task<AcaoCorrecaoAvaliadaEficaz> AddAsync(AcaoCorrecaoAvaliadaEficaz entity)
        {
            await _acaoCorrecaoAvaliadaEficazRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<AcaoCorrecaoAvaliadaEficaz>> AddListAsync(List<AcaoCorrecaoAvaliadaEficaz> entity)
        {
            foreach (var item in entity)
            {
                await _acaoCorrecaoAvaliadaEficazRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<AcaoCorrecaoAvaliadaEficaz> UpdateAsync(AcaoCorrecaoAvaliadaEficaz entity)
        {
            if (!await _acaoCorrecaoAvaliadaEficazRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Ação Correção Avaliada Eficaz com ID {entity.Id} não foi encontrada ");
            }

            await _acaoCorrecaoAvaliadaEficazRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<AcaoCorrecaoAvaliadaEficaz> DeleteAsync(long id)
        {
            var registro = await _acaoCorrecaoAvaliadaEficazRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Ação Correção Avaliada Eficaz com ID {id} não foi encontrada ");
            }

            await _acaoCorrecaoAvaliadaEficazRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<AcaoCorrecaoAvaliadaEficaz?> GetByIdAsync(long id)
        {
            var registro = await _acaoCorrecaoAvaliadaEficazRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Ação Correção Avaliada Eficaz com ID {id} não foi encontrada ");
            }

            return registro;
        }


        public async Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllAsync()
        {
            var registros = await _acaoCorrecaoAvaliadaEficazRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }
         public async Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registros = await _acaoCorrecaoAvaliadaEficazRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;

        }

        public async Task<List<AcaoCorrecaoAvaliadaEficaz>> GetAllAtivosAsync()
        {
            var registros = await _acaoCorrecaoAvaliadaEficazRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception($"Não foi encontrado nennhum resgistro");
            }

            return registros;
        }
        public void Dispose()
        {
            _acaoCorrecaoAvaliadaEficazRepository.Dispose();
        }

    }
}

