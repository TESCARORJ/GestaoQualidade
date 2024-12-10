using Microsoft.EntityFrameworkCore;
using Nuclep.GestaoQualidade.Domain.Models;
using Nuclep.GestaoQualidade.SqlServer.Mappings;

namespace Nuclep.GestaoQualidade.SqlServer.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AderenciaProgramacaoMensalMap());
            modelBuilder.ApplyConfiguration(new AderenciaProgramacaoMensalMetaMap());      
            modelBuilder.ApplyConfiguration(new AcaoCorrecaoAvaliadaEficazMap());
            modelBuilder.ApplyConfiguration(new AcaoCorrecaoAvaliadaEficazMetaMap());           
            modelBuilder.ApplyConfiguration(new AutoavaliacaoGerencialSGQMap());
            modelBuilder.ApplyConfiguration(new AutoavaliacaoGerencialSGQMetaMap());
            modelBuilder.ApplyConfiguration(new CumprimentoEtapasPACDentroPrazoMap());
            modelBuilder.ApplyConfiguration(new CumprimentoEtapasPACDentroPrazoMetaMap());     
            modelBuilder.ApplyConfiguration(new FaturamentoRealizadoMap());
            modelBuilder.ApplyConfiguration(new FaturamentoRealizadoMetaMap());
            modelBuilder.ApplyConfiguration(new RejeicaoMateriaisMap());
            modelBuilder.ApplyConfiguration(new RejeicaoMateriaisMetaMap());
            modelBuilder.ApplyConfiguration(new RespostaAreasRiscosPrazoOriginalMap());
            modelBuilder.ApplyConfiguration(new RespostaAreasRiscosPrazoOriginalMetaMap());
            modelBuilder.ApplyConfiguration(new DuracaoProcessoLicitacaoMap());
            modelBuilder.ApplyConfiguration(new DuracaoProcessoLicitacaoMetaMap());     
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LocalidadeMap());
            modelBuilder.ApplyConfiguration(new LogCrudMap());
            modelBuilder.ApplyConfiguration(new LogTabelaMap());

            modelBuilder.ApplyConfiguration(new CumprimentoVerbaDestinadaPATMMEMap());
            modelBuilder.ApplyConfiguration(new CumprimentoVerbaDestinadaPATMMEMetaMap());

            modelBuilder.ApplyConfiguration(new EficaciaTreinamentoMap());
            modelBuilder.ApplyConfiguration(new EficaciaTreinamentoMetaMap());

            modelBuilder.ApplyConfiguration(new DefeitoSoldagemMap());
            modelBuilder.ApplyConfiguration(new DefeitoSoldagemMetaMap());
              
            modelBuilder.ApplyConfiguration(new OcupacaoMaoObraMap());
            modelBuilder.ApplyConfiguration(new OcupacaoMaoObraMetaMap());

            modelBuilder.ApplyConfiguration(new ProdutividadeMaoObraMap());
            modelBuilder.ApplyConfiguration(new ProdutividadeMaoObraMetaMap());
            
            modelBuilder.ApplyConfiguration(new SatisfacaoClientesMap());
            modelBuilder.ApplyConfiguration(new SatisfacaoClientesMetaMap());

            modelBuilder.ApplyConfiguration(new SatisfacaoUsuarioMap());
            modelBuilder.ApplyConfiguration(new SatisfacaoUsuarioMetaMap());
              
            modelBuilder.ApplyConfiguration(new TempoMedioSolucaoMap());
            modelBuilder.ApplyConfiguration(new TempoMedioSolucaoMetaMap());
              
            modelBuilder.ApplyConfiguration(new ServiceLevelAgreementMap());
            modelBuilder.ApplyConfiguration(new ServiceLevelAgreementMetaMap());
             
            modelBuilder.ApplyConfiguration(new ItensCadastradosMais15DiasMap());
            modelBuilder.ApplyConfiguration(new ItensCadastradosMais15DiasMetaMap());

            modelBuilder.ApplyConfiguration(new NaoConformidadeMap());
            modelBuilder.ApplyConfiguration(new NaoConformidadeMetaMap());

            modelBuilder.ApplyConfiguration(new TaxaConformidadeDocumentosQualidadeMap());
            modelBuilder.ApplyConfiguration(new TaxaConformidadeDocumentosQualidadeMetaMap());

            modelBuilder.ApplyConfiguration(new TempoMedioEmissaoOCItensCriticosMap());
            modelBuilder.ApplyConfiguration(new TempoMedioEmissaoOCItensCriticosMetaMap());

            modelBuilder.ApplyConfiguration(new TempoReparoEquipamentosProgramadosObrasMap());
            modelBuilder.ApplyConfiguration(new TempoReparoEquipamentosProgramadosObrasMetaMap());

        }
    }
}

