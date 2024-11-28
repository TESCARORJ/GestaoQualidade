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


            services.AddTransient<ILogCrudDomainService, LogCrudDomainService>();
            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<ILocalidadeDomainService, LocalidadeDomainService>();

            return services;
        }
    }
}
