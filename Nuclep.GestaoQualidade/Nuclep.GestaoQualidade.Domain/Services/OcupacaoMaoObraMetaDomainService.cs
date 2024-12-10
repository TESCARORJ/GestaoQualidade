using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class OcupacaoMaoObraMetaDomainService : IOcupacaoMaoObraMetaDomainService
    {
        private readonly IOcupacaoMaoObraMetaRepository _ocupacaoMaoObraMetaRepository;

        public OcupacaoMaoObraMetaDomainService(
            IOcupacaoMaoObraMetaRepository ocupacaoMaoObraMetaRepository)
        {
            _ocupacaoMaoObraMetaRepository = ocupacaoMaoObraMetaRepository;
        }

        public async Task<OcupacaoMaoObraMeta> AddAsync(OcupacaoMaoObraMeta entity)
        {
            await _ocupacaoMaoObraMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<OcupacaoMaoObraMeta> UpdateAsync(OcupacaoMaoObraMeta entity)
        {
            if (!await _ocupacaoMaoObraMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Ocupação de Mão de Obra com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _ocupacaoMaoObraMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<OcupacaoMaoObraMeta> DeleteAsync(long id)
        {
            var registro = await _ocupacaoMaoObraMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Ocupação de Mão de Obra com ID {id} não encontrada.");
            }

            await _ocupacaoMaoObraMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<OcupacaoMaoObraMeta?> GetByIdAsync(long id)
        {
            var registro = await _ocupacaoMaoObraMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Ocupação de Mão de Obra com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<OcupacaoMaoObraMeta>> GetAllAsync()
        {
            var registros = await _ocupacaoMaoObraMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<OcupacaoMaoObraMeta>> GetAllAtivosAsync()
        {
            var registros = await _ocupacaoMaoObraMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _ocupacaoMaoObraMetaRepository.Dispose();
        }

    }
}
