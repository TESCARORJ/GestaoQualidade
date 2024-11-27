using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class CumprimentoEtapasPACDentroPrazoDomainService : ICumprimentoEtapasPACDentroPrazoDomainService
    {
        private readonly ICumprimentoEtapasPACDentroPrazoRepository _aderenciaProgramacaoMensalRepository;

        public CumprimentoEtapasPACDentroPrazoDomainService(
            ICumprimentoEtapasPACDentroPrazoRepository aderenciaProgramacaoMensalRepository)
        {
            _aderenciaProgramacaoMensalRepository = aderenciaProgramacaoMensalRepository;
        }

        public async Task<CumprimentoEtapasPACDentroPrazo> AddAsync(CumprimentoEtapasPACDentroPrazo entity)
        {
            await _aderenciaProgramacaoMensalRepository.AddAsync(entity);
            return entity;
        }

        public async Task<List<CumprimentoEtapasPACDentroPrazo>> AddListAsync(List<CumprimentoEtapasPACDentroPrazo> entity)
        {
            foreach (var item in entity)
            {
                await _aderenciaProgramacaoMensalRepository.AddAsync(item);
            }

            return entity;
        }

        public async Task<CumprimentoEtapasPACDentroPrazo> UpdateAsync(CumprimentoEtapasPACDentroPrazo entity)
        {
            if (!await _aderenciaProgramacaoMensalRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Aderência Programação Mensal com ID {entity.Id} não encontrada.");
            }

            await _aderenciaProgramacaoMensalRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<CumprimentoEtapasPACDentroPrazo> DeleteAsync(long id)
        {
            var registro = await _aderenciaProgramacaoMensalRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Aderência Programação Mensal com ID {id} não encontrada.");
            }

            await _aderenciaProgramacaoMensalRepository.DeleteAsync(registro);
            
            return registro;
        }
     

        public async Task<CumprimentoEtapasPACDentroPrazo?> GetByIdAsync(long id)
        {
            var registro = await _aderenciaProgramacaoMensalRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Aderência Programação Mensal com ID {id} não encontrada.");
            }

            return registro;
        }

        public Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllAsync()
        {
            var registro = _aderenciaProgramacaoMensalRepository.GetAllAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return  registro;
        }

         public Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllUsarioLogadoAsync(long usuarioLogadoId)
        {
            var registro =  _aderenciaProgramacaoMensalRepository.GetAllUsarioLogadoAsync(usuarioLogadoId);

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return  registro;
        }

        public Task<List<CumprimentoEtapasPACDentroPrazo>> GetAllAtivosAsync()
        {
            var registro =  _aderenciaProgramacaoMensalRepository.GetAllAtivosAsync();

            if (registro == null)
            {
                throw new Exception($"Nenhum registro encontrado.");
            }

            return registro;
        }

        public void Dispose()
        {
            _aderenciaProgramacaoMensalRepository.Dispose();
        }

       
    }
}
