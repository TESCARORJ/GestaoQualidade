using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class ItensCadastradosMais15DiasMetaDomainService : IItensCadastradosMais15DiasMetaDomainService
    {
        private readonly IItensCadastradosMais15DiasMetaRepository _itensCadastradosMais15DiasMetaRepository;

        public ItensCadastradosMais15DiasMetaDomainService(
            IItensCadastradosMais15DiasMetaRepository itensCadastradosMais15DiasMetaRepository)
        {
            _itensCadastradosMais15DiasMetaRepository = itensCadastradosMais15DiasMetaRepository;
        }

        public async Task<ItensCadastradosMais15DiasMeta> AddAsync(ItensCadastradosMais15DiasMeta entity)
        {
            await _itensCadastradosMais15DiasMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<ItensCadastradosMais15DiasMeta> UpdateAsync(ItensCadastradosMais15DiasMeta entity)
        {
            if (!await _itensCadastradosMais15DiasMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Tempo Médio Solução com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result;

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo;

            await _itensCadastradosMais15DiasMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<ItensCadastradosMais15DiasMeta> DeleteAsync(long id)
        {
            var registro = await _itensCadastradosMais15DiasMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Itens Cadastrados Mais 15 Dias com ID {id} não encontrada.");
            }

            await _itensCadastradosMais15DiasMetaRepository.DeleteAsync(registro);

            return registro;
        }


        public async Task<ItensCadastradosMais15DiasMeta?> GetByIdAsync(long id)
        {
            var registro = await _itensCadastradosMais15DiasMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Itens Cadastrados Mais 15 Dias com ID {id} não encontrada.");
            }

            return registro;
        }


        public async Task<List<ItensCadastradosMais15DiasMeta>> GetAllAsync()
        {
            var registros = await _itensCadastradosMais15DiasMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }

        public async Task<List<ItensCadastradosMais15DiasMeta>> GetAllAtivosAsync()
        {
            var registros = await _itensCadastradosMais15DiasMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _itensCadastradosMais15DiasMetaRepository.Dispose();
        }

    }
}
