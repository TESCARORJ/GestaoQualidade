using Microsoft.Extensions.DependencyInjection;
using Nuclep.GestaoQualidade.Domain.Interfaces.Services;
using Nuclep.GestaoQualidade.Domain.Services;

namespace Nuclep.GestaoQualidade.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {

            services.AddTransient<IAderenciaProgramacaoMensalDomainService, AderenciaProgramacaoMensalDomainService>();
            services.AddTransient<IAderenciaProgramacaoMensalMetaDomainService, AderenciaProgramacaoMensalMetaDomainService>();

            services.AddTransient<IAcaoCorrecaoAvaliadaEficazDomainService, AcaoCorrecaoAvaliadaEficazDomainService>();
            services.AddTransient<IAcaoCorrecaoAvaliadaEficazMetaDomainService, AcaoCorrecaoAvaliadaEficazMetaDomainService>();

            services.AddTransient<IFaturamentoRealizadoDomainService, FaturamentoRealizadoDomainService>();
            services.AddTransient<IFaturamentoRealizadoMetaDomainService, FaturamentoRealizadoMetaDomainService>();

            services.AddTransient<IRejeicaoMateriaisDomainService, RejeicaoMateriaisDomainService>();
            services.AddTransient<IRejeicaoMateriaisMetaDomainService, RejeicaoMateriaisMetaDomainService>();

            services.AddTransient<IRespostaAreasRiscosPrazoOriginalDomainService, RespostaAreasRiscosPrazoOriginalDomainService>();
            services.AddTransient<IRespostaAreasRiscosPrazoOriginalMetaDomainService, RespostaAreasRiscosPrazoOriginalMetaDomainService>();

            services.AddTransient<IDuracaoProcessoLicitacaoDomainService, DuracaoProcessoLicitacaoDomainService>();
            services.AddTransient<IDuracaoProcessoLicitacaoMetaDomainService, DuracaoProcessoLicitacaoMetaDomainService>();

            services.AddTransient<IAutoavaliacaoGerencialSGQDomainService, AutoavaliacaoGerencialSGQDomainService>();
            services.AddTransient<IAutoavaliacaoGerencialSGQMetaDomainService, AutoavaliacaoGerencialSGQMetaDomainService>();

            services.AddTransient<ICumprimentoEtapasPACDentroPrazoDomainService, CumprimentoEtapasPACDentroPrazoDomainService>();
            services.AddTransient<ICumprimentoEtapasPACDentroPrazoMetaDomainService, CumprimentoEtapasPACDentroPrazoMetaDomainService>();

            services.AddTransient<ICumprimentoVerbaDestinadaPATMMEDomainService, CumprimentoVerbaDestinadaPATMMEDomainService>();
            services.AddTransient<ICumprimentoVerbaDestinadaPATMMEMetaDomainService, CumprimentoVerbaDestinadaPATMMEMetaDomainService>();

            services.AddTransient<IEficaciaTreinamentoDomainService, EficaciaTreinamentoDomainService>();
            services.AddTransient<IEficaciaTreinamentoMetaDomainService, EficaciaTreinamentoMetaDomainService>();

            services.AddTransient<IDefeitoSoldagemDomainService, DefeitoSoldagemDomainService>();
            services.AddTransient<IDefeitoSoldagemMetaDomainService, DefeitoSoldagemMetaDomainService>();

            services.AddTransient<IOcupacaoMaoObraDomainService, OcupacaoMaoObraDomainService>();
            services.AddTransient<IOcupacaoMaoObraMetaDomainService, OcupacaoMaoObraMetaDomainService>();

            services.AddTransient<IProdutividadeMaoObraDomainService, ProdutividadeMaoObraDomainService>();
            services.AddTransient<IProdutividadeMaoObraMetaDomainService, ProdutividadeMaoObraMetaDomainService>();

            services.AddTransient<ISatisfacaoClientesDomainService, SatisfacaoClientesDomainService>();
            services.AddTransient<ISatisfacaoClientesMetaDomainService, SatisfacaoClientesMetaDomainService>();

            services.AddTransient<ITempoMedioEmissaoOCItensCriticosDomainService, TempoMedioEmissaoOCItensCriticosDomainService>();
            services.AddTransient<ITempoMedioEmissaoOCItensCriticosMetaDomainService, TempoMedioEmissaoOCItensCriticosMetaDomainService>();

            services.AddTransient<ISatisfacaoUsuarioDomainService, SatisfacaoUsuarioDomainService>();
            services.AddTransient<ISatisfacaoUsuarioMetaDomainService, SatisfacaoUsuarioMetaDomainService>();

            services.AddTransient<ITaxaConformidadeDocumentosQualidadeDomainService, TaxaConformidadeDocumentosQualidadeDomainService>();
            services.AddTransient<ITaxaConformidadeDocumentosQualidadeMetaDomainService, TaxaConformidadeDocumentosQualidadeMetaDomainService>();

            services.AddTransient<ITempoMedioSolucaoDomainService, TempoMedioSolucaoDomainService>();
            services.AddTransient<ITempoMedioSolucaoMetaDomainService, TempoMedioSolucaoMetaDomainService>();
            
            services.AddTransient<ITempoReparoEquipamentosProgramadosObrasDomainService, TempoReparoEquipamentosProgramadosObrasDomainService>();
            services.AddTransient<ITempoReparoEquipamentosProgramadosObrasMetaDomainService, TempoReparoEquipamentosProgramadosObrasMetaDomainService>();
            
            services.AddTransient<IServiceLevelAgreementDomainService, ServiceLevelAgreementDomainService>();
            services.AddTransient<IServiceLevelAgreementMetaDomainService, ServiceLevelAgreementMetaDomainService>();
            
            services.AddTransient<IItensCadastradosMais15DiasDomainService, ItensCadastradosMais15DiasDomainService>();
            services.AddTransient<IItensCadastradosMais15DiasMetaDomainService, ItensCadastradosMais15DiasMetaDomainService>();

            services.AddTransient<INaoConformidadeDomainService, NaoConformidadeDomainService>();
            services.AddTransient<INaoConformidadeMetaDomainService, NaoConformidadeMetaDomainService>();


            services.AddTransient<ILogCrudDomainService, LogCrudDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<ILocalidadeDomainService, LocalidadeDomainService>();

            return services;
        }
    }
}
