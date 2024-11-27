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
            modelBuilder.ApplyConfiguration(new DuracaoProcessoLicitacaoMap());
            modelBuilder.ApplyConfiguration(new DuracaoProcessoLicitacaoMetaMap());     
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LocalidadeMap());
            modelBuilder.ApplyConfiguration(new LogCrudMap());
            modelBuilder.ApplyConfiguration(new LogTabelaMap());

            modelBuilder.ApplyConfiguration(new CumprimentoVerbaDestinadaPATMMEMap());
            modelBuilder.ApplyConfiguration(new CumprimentoVerbaDestinadaPATMMEMetaMap());

            modelBuilder.ApplyConfiguration(new DefeitoSoldagemMap());
            modelBuilder.ApplyConfiguration(new DefeitoSoldagemMetaMap());

        }
    }
}

