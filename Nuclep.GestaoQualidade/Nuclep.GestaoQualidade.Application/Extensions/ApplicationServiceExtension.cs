using Microsoft.Extensions.DependencyInjection;
using Nuclep.GestaoQualidade.Application.Interfaces.Applications;
using Nuclep.GestaoQualidade.Application.Interfaces.Sistema;
using Nuclep.GestaoQualidade.Application.Mappings;
using Nuclep.GestaoQualidade.Application.Services;

namespace Nuclep.GestaoQualidade.Application.Extensions
{

    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //injeção de dependência para o AutoMapper
            services.AddAutoMapper(typeof(ApplicationProfileMap));


            //injeção de dependência para os serviços de aplicação
            services.AddTransient<IAderenciaProgramacaoMensalAppService, AderenciaProgramacaoMensalAppService>();
            services.AddTransient<IAderenciaProgramacaoMensalMetaAppService, AderenciaProgramacaoMensalMetaAppService>(); 
             
            services.AddTransient<IAcaoCorrecaoAvaliadaEficazAppService, AcaoCorrecaoAvaliadaEficazAppService>();
            services.AddTransient<IAcaoCorrecaoAvaliadaEficazMetaAppService, AcaoCorrecaoAvaliadaEficazMetaAppService>();
             
            services.AddTransient<IFaturamentoRealizadoAppService, FaturamentoRealizadoAppService>();
            services.AddTransient<IFaturamentoRealizadoMetaAppService, FaturamentoRealizadoMetaAppService>();
             
            services.AddTransient<IRejeicaoMateriaisAppService, RejeicaoMateriaisAppService>();
            services.AddTransient<IRejeicaoMateriaisMetaAppService, RejeicaoMateriaisMetaAppService>();
             
            services.AddTransient<IRespostaAreasRiscosPrazoOriginalAppService, RespostaAreasRiscosPrazoOriginalAppService>();
            services.AddTransient<IRespostaAreasRiscosPrazoOriginalMetaAppService, RespostaAreasRiscosPrazoOriginalMetaAppService>();

            services.AddTransient<IDuracaoProcessoLicitacaoAppService, DuracaoProcessoLicitacaoAppService>();
            services.AddTransient<IDuracaoProcessoLicitacaoMetaAppService, DuracaoProcessoLicitacaoMetaAppService>();
            
            services.AddTransient<IAutoavaliacaoGerencialSGQAppService, AutoavaliacaoGerencialSGQAppService>();
            services.AddTransient<IAutoavaliacaoGerencialSGQMetaAppService, AutoavaliacaoGerencialSGQMetaAppService>();
            
            services.AddTransient<ICumprimentoEtapasPACDentroPrazoAppService, CumprimentoEtapasPACDentroPrazoAppService>();
            services.AddTransient<ICumprimentoEtapasPACDentroPrazoMetaAppService, CumprimentoEtapasPACDentroPrazoMetaAppService>();

            services.AddTransient<ICumprimentoVerbaDestinadaPATMMEAppService, CumprimentoVerbaDestinadaPATMMEAppService>();
            services.AddTransient<ICumprimentoVerbaDestinadaPATMMEMetaAppService, CumprimentoVerbaDestinadaPATMMEMetaAppService>();

            services.AddTransient<IEficaciaTreinamentoAppService, EficaciaTreinamentoAppService>();
            services.AddTransient<IEficaciaTreinamentoMetaAppService, EficaciaTreinamentoMetaAppService>();

            services.AddTransient<IDefeitoSoldagemAppService, DefeitoSoldagemAppService>();
            services.AddTransient<IDefeitoSoldagemMetaAppService, DefeitoSoldagemMetaAppService>();
               
            services.AddTransient<IOcupacaoMaoObraAppService, OcupacaoMaoObraAppService>();
            services.AddTransient<IOcupacaoMaoObraMetaAppService, OcupacaoMaoObraMetaAppService>();

            services.AddTransient<IProdutividadeMaoObraAppService, ProdutividadeMaoObraAppService>();
            services.AddTransient<IProdutividadeMaoObraMetaAppService, ProdutividadeMaoObraMetaAppService>(); 
            
            services.AddTransient<ISatisfacaoClientesAppService, SatisfacaoClientesAppService>();
            services.AddTransient<ISatisfacaoClientesMetaAppService, SatisfacaoClientesMetaAppService>();
                
            services.AddTransient<ITempoMedioEmissaoOCItensCriticosAppService, TempoMedioEmissaoOCItensCriticosAppService>();
            services.AddTransient<ITempoMedioEmissaoOCItensCriticosMetaAppService, TempoMedioEmissaoOCItensCriticosMetaAppService>();
               
            services.AddTransient<ISatisfacaoUsuarioAppService, SatisfacaoUsuarioAppService>();
            services.AddTransient<ISatisfacaoUsuarioMetaAppService, SatisfacaoUsuarioMetaAppService>();

            services.AddTransient<ITaxaConformidadeDocumentosQualidadeAppService, TaxaConformidadeDocumentosQualidadeAppService>();
            services.AddTransient<ITaxaConformidadeDocumentosQualidadeMetaAppService, TaxaConformidadeDocumentosQualidadeMetaAppService>();

            services.AddTransient<ITempoMedioSolucaoAppService, TempoMedioSolucaoAppService>();
            services.AddTransient<ITempoMedioSolucaoMetaAppService, TempoMedioSolucaoMetaAppService>();
                    
            services.AddTransient<ITempoReparoEquipamentosProgramadosObrasAppService, TempoReparoEquipamentosProgramadosObrasAppService>();
            services.AddTransient<ITempoReparoEquipamentosProgramadosObrasMetaAppService, TempoReparoEquipamentosProgramadosObrasMetaAppService>();
                  
            services.AddTransient<IServiceLevelAgreementAppService, ServiceLevelAgreementAppService>();
            services.AddTransient<IServiceLevelAgreementMetaAppService, ServiceLevelAgreementMetaAppService>();
                
            services.AddTransient<IItensCadastradosMais15DiasAppService, ItensCadastradosMais15DiasAppService>();
            services.AddTransient<IItensCadastradosMais15DiasMetaAppService, ItensCadastradosMais15DiasMetaAppService>();
               
            services.AddTransient<INaoConformidadeAppService, NaoConformidadeAppService>();
            services.AddTransient<INaoConformidadeMetaAppService, NaoConformidadeMetaAppService>();

            services.AddTransient<ILogCrudAppService, LogCrudAppService>();
                        
            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IUsuarioSession, UsuarioSession>();

             services.AddTransient<ILocalidadeAppService, LocalidadeAppService>();



            return services;
        }
    }

}
