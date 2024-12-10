using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class ItensCadastradosMais15DiasDomainService : IItensCadastradosMais15DiasDomainService
    {
        private readonly IItensCadastradosMais15DiasRepository _itensCadastradosMais15DiasRepository;

        public ItensCadastradosMais15DiasDomainService(
            IItensCadastradosMais15DiasRepository itensCadastradosMais15DiasRepository)
        {
            _itensCadastradosMais15DiasRepository = itensCadastradosMais15DiasRepository;
        }

        public async Task<ItensCadastradosMais15Dias> AddAsync(ItensCadastradosMais15Dias entity)
        {
            await _itensCadastradosMais15DiasRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<ItensCadastradosMais15Dias>> AddListAsync(List<ItensCadastradosMais15Dias> entity)
        {
            foreach (var item in entity)
            {
                await _itensCadastradosMais15DiasRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<ItensCadastradosMais15Dias> UpdateAsync(ItensCadastradosMais15Dias entity)
        {
            if (!await _itensCadastradosMais15DiasRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Itens Cadastrados Mais 15 Dias com ID {entity.Id} não encontrada.");
            }

            await _itensCadastradosMais15DiasRepository.UpdateAsync(entity);

            return entity;

        }

        public async Task<ItensCadastradosMais15Dias> DeleteAsync(long id)
        {
            var registro = await _itensCadastradosMais15DiasRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Itens Cadastrados Mais 15 Dias com ID {id} não encontrada.");
            }

            await _itensCadastradosMais15DiasRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<ItensCadastradosMais15Dias?> GetByIdAsync(long id)
        {
            var registro = await _itensCadastradosMais15DiasRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Itens Cadastrados Mais 15 Dias com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<ItensCadastradosMais15Dias>> GetAllAsync()
        {
            var registro = _itensCadastradosMais15DiasRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }
        public Task<List<ItensCadastradosMais15Dias>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro = _itensCadastradosMais15DiasRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public Task<List<ItensCadastradosMais15Dias>> GetAllAtivosAsync()
        {
            var registro = _itensCadastradosMais15DiasRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _itensCadastradosMais15DiasRepository.Dispose();
        }


    }
}
