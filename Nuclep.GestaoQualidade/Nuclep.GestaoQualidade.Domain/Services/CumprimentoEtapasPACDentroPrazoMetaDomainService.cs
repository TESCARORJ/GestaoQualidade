using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Models.Indicadores;

namespace Nuclep.GestaoQualidade.Domain.Services
{
    public class CumprimentoEtapasPACDentroPrazoMetaDomainService : ICumprimentoEtapasPACDentroPrazoMetaDomainService
    {
        private readonly ICumprimentoEtapasPACDentroPrazoMetaRepository _aderenciaProgramacaoMensalMetaRepository;

        public CumprimentoEtapasPACDentroPrazoMetaDomainService(
            ICumprimentoEtapasPACDentroPrazoMetaRepository aderenciaProgramacaoMensalMetaRepository)
        {
            _aderenciaProgramacaoMensalMetaRepository = aderenciaProgramacaoMensalMetaRepository;
        }

        public async Task<CumprimentoEtapasPACDentroPrazoMeta> AddAsync(CumprimentoEtapasPACDentroPrazoMeta entity)
        {
            await _aderenciaProgramacaoMensalMetaRepository.AddAsync(entity);
            return entity;
        }

        public async Task<CumprimentoEtapasPACDentroPrazoMeta> UpdateAsync(CumprimentoEtapasPACDentroPrazoMeta entity)
        {
            if(!await _aderenciaProgramacaoMensalMetaRepository.VerifyExistsAsync(x => x.Id == entity.Id))
            {
                throw new Exception($"Meta de Aderência Programação Mensal com ID {entity.Id} não encontrada.");
            }

            var model = GetByIdAsync(entity.Id).Result; 

            entity.DataHoraCadastro = model.DataHoraCadastro;
            entity.UsuarioCadastroId = model.UsuarioCadastroId;
            entity.IsAtivo = model.IsAtivo; 

            await _aderenciaProgramacaoMensalMetaRepository.UpdateAsync(entity);
            return entity;

        }

        public async Task<CumprimentoEtapasPACDentroPrazoMeta> DeleteAsync(long id)
        {
            var registro = await _aderenciaProgramacaoMensalMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Aderência Programação Mensal com ID {id} não encontrada.");
            }

            await _aderenciaProgramacaoMensalMetaRepository.DeleteAsync(registro);
            
            return registro;
        }
      

        public async Task<CumprimentoEtapasPACDentroPrazoMeta?> GetByIdAsync(long id)
        {
            var registro = await _aderenciaProgramacaoMensalMetaRepository.GetByIdAsync(id);

            if (registro == null)
            {
                throw new Exception($"Meta de Aderência Programação Mensal com ID {id} não encontrada.");
            }

            return registro;
        }

     
        public async Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllAsync()
        {
            var registros = await _aderenciaProgramacaoMensalMetaRepository.GetAllAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }                      

            return registros;
        }

        public async Task<List<CumprimentoEtapasPACDentroPrazoMeta>> GetAllAtivosAsync()
        {
            var registros = await _aderenciaProgramacaoMensalMetaRepository.GetAllAtivosAsync();

            if (registros == null)
            {
                throw new Exception("Nenhum registro encontrado");
            }

            return registros;
        }
        public void Dispose()
        {
            _aderenciaProgramacaoMensalMetaRepository.Dispose();
        }

    }
}
