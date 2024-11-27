using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class DefeitoSoldagemDomainService : IDefeitoSoldagemDomainService
    {
        private readonly IDefeitoSoldagemRepository _defeitoSoldagemRepository;

        public DefeitoSoldagemDomainService(
            IDefeitoSoldagemRepository defeitoSoldagemRepository)
        {
            _defeitoSoldagemRepository = defeitoSoldagemRepository;
        }

        public async Task<DefeitoSoldagem> AddAsync(DefeitoSoldagem entity)
        {
            await _defeitoSoldagemRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<DefeitoSoldagem>> AddListAsync(List<DefeitoSoldagem> entity)
        {
            foreach (var item in entity)
            {
                await _defeitoSoldagemRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<DefeitoSoldagem> UpdateAsync(DefeitoSoldagem entity)
        {
            if (!await _defeitoSoldagemRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Aderência Programação Mensal com ID {entity.Id} não encontrada.");
            }

            await _defeitoSoldagemRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<DefeitoSoldagem> DeleteAsync(long id)
        {
            var registro = await _defeitoSoldagemRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Aderência Programação Mensal com ID {id} não encontrada.");
            }

            await _defeitoSoldagemRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<DefeitoSoldagem?> GetByIdAsync(long id)
        {
            var registro = await _defeitoSoldagemRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Aderência Programação Mensal com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<DefeitoSoldagem>> GetAllAsync()
        {
            var registro = _defeitoSoldagemRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<DefeitoSoldagem>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _defeitoSoldagemRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<DefeitoSoldagem>> GetAllAtivosAsync()
        {
            var registro = _defeitoSoldagemRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _defeitoSoldagemRepository.Dispose();
        }


    }
}
