using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class DefeitoSoldagemMetaDomainService : IDefeitoSoldagemMetaDomainService
    {
        private readonly IDefeitoSoldagemMetaRepository _defeitoSoldagemMetaRepository;

        public DefeitoSoldagemMetaDomainService(
            IDefeitoSoldagemMetaRepository defeitoSoldagemMetaRepository)
        {
            _defeitoSoldagemMetaRepository = defeitoSoldagemMetaRepository;
        }

        public async Task<DefeitoSoldagemMeta> AddAsync(DefeitoSoldagemMeta entity)
        {
            await _defeitoSoldagemMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<DefeitoSoldagemMeta> UpdateAsync(DefeitoSoldagemMeta entity)
        {
            if (!await _defeitoSoldagemMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Aderência Programação Mensal com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _defeitoSoldagemMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<DefeitoSoldagemMeta> DeleteAsync(long id)
        {
            var registro = await _defeitoSoldagemMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Aderência Programação Mensal com ID {id} não encontrada.");
            }

            await _defeitoSoldagemMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<DefeitoSoldagemMeta?> GetByIdAsync(long id)
        {
            var registro = await _defeitoSoldagemMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Aderência Programação Mensal com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<DefeitoSoldagemMeta>> GetAllAsync()
        {
            var registros = await _defeitoSoldagemMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<DefeitoSoldagemMeta>> GetAllAtivosAsync()
        {
            var registros = await _defeitoSoldagemMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _defeitoSoldagemMetaRepository.Dispose();
        }

    }
}
