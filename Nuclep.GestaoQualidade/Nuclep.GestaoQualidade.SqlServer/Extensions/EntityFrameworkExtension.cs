using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.SqlServer.Contexts;
using Nuclep.GestaoQualidade.SqlServer.Repositories;

namespace Nuclep.GestaoQualidade.SqlServer.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos as injeções de dependência
    /// do projeto Infra.Data e do EntityFramework
    /// </summary>
    public static class EntityFrameworkExtension
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("GestaoQualidadeCS");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IAderenciaProgramacaoMensalRepository, AderenciaProgramacaoMensalRepository>();
            services.AddTransient<IAderenciaProgramacaoMensalMetaRepository, AderenciaProgramacaoMensalMetaRepository>(); 
            services.AddTransient<IAcaoCorrecaoAvaliadaEficazRepository, AcaoCorrecaoAvaliadaEficazRepository>();
            services.AddTransient<IAcaoCorrecaoAvaliadaEficazMetaRepository, AcaoCorrecaoAvaliadaEficazMetaRepository>();
            services.AddTransient<ICumprimentoEtapasPACDentroPrazoRepository, CumprimentoEtapasPACDentroPrazoRepository>();
            services.AddTransient<ICumprimentoEtapasPACDentroPrazoMetaRepository, CumprimentoEtapasPACDentroPrazoMetaRepository>();
            services.AddTransient<IFaturamentoRealizadoRepository, FaturamentoRealizadoRepository>();
            services.AddTransient<IFaturamentoRealizadoMetaRepository, FaturamentoRealizadoMetaRepository>();
            services.AddTransient<IRejeicaoMateriaisRepository, RejeicaoMateriaisRepository>();
            services.AddTransient<IRejeicaoMateriaisMetaRepository, RejeicaoMateriaisMetaRepository>();
            services.AddTransient<IRespostaAreasRiscosPrazoOriginalRepository, RespostaAreasRiscosPrazoOriginalRepository>();
            services.AddTransient<IRespostaAreasRiscosPrazoOriginalMetaRepository, RespostaAreasRiscosPrazoOriginalMetaRepository>();
            services.AddTransient<IDuracaoProcessoLicitacaoRepository, DuracaoProcessoLicitacaoRepository>();
            services.AddTransient<IDuracaoProcessoLicitacaoMetaRepository, DuracaoProcessoLicitacaoMetaRepository>();
            services.AddTransient<IAutoavaliacaoGerencialSGQRepository, AutoavaliacaoGerencialSGQRepository>();
            services.AddTransient<IAutoavaliacaoGerencialSGQMetaRepository, AutoavaliacaoGerencialSGQMetaRepository>();
            services.AddTransient<ICumprimentoVerbaDestinadaPATMMERepository, CumprimentoVerbaDestinadaPATMMERepository>();
            services.AddTransient<ICumprimentoVerbaDestinadaPATMMEMetaRepository, CumprimentoVerbaDestinadaPATMMEMetaRepository>();
            services.AddTransient<IDefeitoSoldagemRepository, DefeitoSoldagemRepository>();
            services.AddTransient<IDefeitoSoldagemMetaRepository, DefeitoSoldagemMetaRepository>();
            services.AddTransient<IOcupacaoMaoObraRepository, OcupacaoMaoObraRepository>();
            services.AddTransient<IOcupacaoMaoObraMetaRepository, OcupacaoMaoObraMetaRepository>();
            services.AddTransient<IEficaciaTreinamentoRepository, EficaciaTreinamentoRepository>();
            services.AddTransient<IEficaciaTreinamentoMetaRepository, EficaciaTreinamentoMetaRepository>();
            services.AddTransient<IProdutividadeMaoObraRepository, ProdutividadeMaoObraRepository>();
            services.AddTransient<IProdutividadeMaoObraMetaRepository, ProdutividadeMaoObraMetaRepository>();
            services.AddTransient<ISatisfacaoClientesRepository, SatisfacaoClientesRepository>();
            services.AddTransient<ISatisfacaoClientesMetaRepository, SatisfacaoClientesMetaRepository>();
            
            services.AddTransient<ISatisfacaoUsuarioRepository, SatisfacaoUsuarioRepository>();
            services.AddTransient<ISatisfacaoUsuarioMetaRepository, SatisfacaoUsuarioMetaRepository>();
               
            services.AddTransient<ITempoMedioSolucaoRepository, TempoMedioSolucaoRepository>();
            services.AddTransient<ITempoMedioSolucaoMetaRepository, TempoMedioSolucaoMetaRepository>();
              
            services.AddTransient<ITempoReparoEquipamentosProgramadosObrasRepository, TempoReparoEquipamentosProgramadosObrasRepository>();
            services.AddTransient<ITempoReparoEquipamentosProgramadosObrasMetaRepository, TempoReparoEquipamentosProgramadosObrasMetaRepository>();
             
            services.AddTransient<IServiceLevelAgreementRepository, ServiceLevelAgreementRepository>();
            services.AddTransient<IServiceLevelAgreementMetaRepository, ServiceLevelAgreementMetaRepository>();
             
            services.AddTransient<IItensCadastradosMais15DiasRepository, ItensCadastradosMais15DiasRepository>();
            services.AddTransient<IItensCadastradosMais15DiasMetaRepository, ItensCadastradosMais15DiasMetaRepository>();
              
            services.AddTransient<INaoConformidadeRepository, NaoConformidadeRepository>();
            services.AddTransient<INaoConformidadeMetaRepository, NaoConformidadeMetaRepository>();

            services.AddTransient<ITaxaConformidadeDocumentosQualidadeRepository, TaxaConformidadeDocumentosQualidadeRepository>();
            services.AddTransient<ITaxaConformidadeDocumentosQualidadeMetaRepository, TaxaConformidadeDocumentosQualidadeMetaRepository>();

            services.AddTransient<ITempoMedioEmissaoOCItensCriticosRepository, TempoMedioEmissaoOCItensCriticosRepository>();
            services.AddTransient<ITempoMedioEmissaoOCItensCriticosMetaRepository, TempoMedioEmissaoOCItensCriticosMetaRepository>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ILocalidadeRepository, LocalidadeRepository>();
            services.AddTransient<ILogCrudRepository, LogCrudRepository>();
            services.AddTransient<ILogTabelaRepository, LogTabelaRepository>();

            return services;
        }
    }
}
