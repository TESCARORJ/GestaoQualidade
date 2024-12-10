using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class ProdutividadeMaoObraMetaDomainService : IProdutividadeMaoObraMetaDomainService
    {
        private readonly IProdutividadeMaoObraMetaRepository _produtividadeMaoObraMetaRepository;

        public ProdutividadeMaoObraMetaDomainService(
            IProdutividadeMaoObraMetaRepository produtividadeMaoObraMetaRepository)
        {
            _produtividadeMaoObraMetaRepository = produtividadeMaoObraMetaRepository;
        }

        public async Task<ProdutividadeMaoObraMeta> AddAsync(ProdutividadeMaoObraMeta entity)
        {
            await _produtividadeMaoObraMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<ProdutividadeMaoObraMeta> UpdateAsync(ProdutividadeMaoObraMeta entity)
        {
            if (!await _produtividadeMaoObraMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Produtividade de Mão de Obra com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _produtividadeMaoObraMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<ProdutividadeMaoObraMeta> DeleteAsync(long id)
        {
            var registro = await _produtividadeMaoObraMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Produtividade de Mão de Obra com ID {id} não encontrada.");
            }

            await _produtividadeMaoObraMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<ProdutividadeMaoObraMeta?> GetByIdAsync(long id)
        {
            var registro = await _produtividadeMaoObraMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Produtividade de Mão de Obra com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<ProdutividadeMaoObraMeta>> GetAllAsync()
        {
            var registros = await _produtividadeMaoObraMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<ProdutividadeMaoObraMeta>> GetAllAtivosAsync()
        {
            var registros = await _produtividadeMaoObraMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _produtividadeMaoObraMetaRepository.Dispose();
        }

    }
}
