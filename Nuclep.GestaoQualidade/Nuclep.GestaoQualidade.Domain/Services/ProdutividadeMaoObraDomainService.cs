using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class ProdutividadeMaoObraDomainService : IProdutividadeMaoObraDomainService
    {
        private readonly IProdutividadeMaoObraRepository _produtividadeMaoObraRepository;

        public ProdutividadeMaoObraDomainService(
            IProdutividadeMaoObraRepository produtividadeMaoObraRepository)
        {
            _produtividadeMaoObraRepository = produtividadeMaoObraRepository;
        }

        public async Task<ProdutividadeMaoObra> AddAsync(ProdutividadeMaoObra entity)
        {
            await _produtividadeMaoObraRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<ProdutividadeMaoObra>> AddListAsync(List<ProdutividadeMaoObra> entity)
        {
            foreach (var item in entity)
            {
                await _produtividadeMaoObraRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<ProdutividadeMaoObra> UpdateAsync(ProdutividadeMaoObra entity)
        {
            if (!await _produtividadeMaoObraRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Aderência Programação Mensal com ID {entity.Id} não encontrada.");
            }

            await _produtividadeMaoObraRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<ProdutividadeMaoObra> DeleteAsync(long id)
        {
            var registro = await _produtividadeMaoObraRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Aderência Programação Mensal com ID {id} não encontrada.");
            }

            await _produtividadeMaoObraRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<ProdutividadeMaoObra?> GetByIdAsync(long id)
        {
            var registro = await _produtividadeMaoObraRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Aderência Programação Mensal com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<ProdutividadeMaoObra>> GetAllAsync()
        {
            var registro = _produtividadeMaoObraRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<ProdutividadeMaoObra>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _produtividadeMaoObraRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<ProdutividadeMaoObra>> GetAllAtivosAsync()
        {
            var registro = _produtividadeMaoObraRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _produtividadeMaoObraRepository.Dispose();
        }


    }
}
