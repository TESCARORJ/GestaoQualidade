using Microsoft.Extensions.DependencyInjection;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories;
using Nuclep.GestaoQualidade.Domain.Interfaces.Repositories.Sistema;
using Nuclep.GestaoQualidade.Infra.Data.Repositories;

namespace Nuclep.GestaoQualidade.Infra.Data.Extensions
{
    public static class InfraServicesExtension
    {
        public static IServiceCollection  AddInfraServicesExtension(this IServiceCollection services)
        {

            //REGISTRANDO INTERFACES/CLASSE DE REPOSITÓRIO

            services.AddScoped<IAderenciaProgramacaoMensalRepository, AderenciaProgramacaoMensalRepository>();
            services.AddScoped<IAderenciaProgramacaoMensalMetaRepository, AderenciaProgramacaoMensalMetaRepository>();
            //services.AddScoped<IAnoIndiceRepository, AnoIndiceRepository>();
            //services.AddScoped<ILocalidadeRepository, LocalidadeRepository>();
            //services.AddScoped<IDefeitoSoldagemRepository, DefeitoSoldagemRepository>();
            //services.AddScoped<IDefeitoSoldagemMetaRepository, DefeitoSoldagemMetaRepository>();
            services.AddScoped<ILogCrudRepository, LogCrudRepository>();
            services.AddScoped<ILogTabelaRepository, LogTabelaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<IFormularioRepository, FormularioRepository>();
            //services.AddScoped<IQuestionarioHomologacaoRepository, QuestionarioHomologacaoRepository>();
            //services.AddScoped<INivelServicoAtendimentoRepository, NivelServicoAtendimentoRepository>();
            //services.AddScoped<INivelServicoAtendimentoMetaRepository, NivelServicoAtendimentoMetaRepository>();
            //services.AddScoped<ISatisfacaoUsuarioRepository, SatisfacaoUsuarioRepository>();
            //services.AddScoped<ISatisfacaoUsuarioMetaRepository, SatisfacaoUsuarioMetaRepository>();
            //services.AddScoped<ITempoMedioSolucaoRepository, TempoMedioSolucaoRepository>();
            //services.AddScoped<ITempoMedioSolucaoMetaRepository, TempoMedioSolucaoMetaRepository>();
            //services.AddScoped<IItensCadastradosMais15DiasRepository, ItensCadastradosMais15DiasRepository>();
            //services.AddScoped<IItensCadastradosMais15DiasMetaRepository, ItensCadastradosMais15DiasMetaRepository>();
            //services.AddScoped<IIndicadorDuracaoProcessoLicitacaoRepository, IndicadorDuracaoProcessoLicitacaoRepository>();
            //services.AddScoped<IIndicadorDuracaoProcessoLicitacaoMetaRepository, IndicadorDuracaoProcessoLicitacaoMetaRepository>();
            //services.AddScoped<IIndicadorEventosAtrasoRepository, IndicadorEventosAtrasoRepository>();
            //services.AddScoped<IIndicadorEventosAtrasoMetaRepository, IndicadorEventosAtrasoMetaRepository>();
            //services.AddScoped<IIndicadorFaturamentoRealizadoRepository, IndicadorFaturamentoRealizadoRepository>();
            //services.AddScoped<IIndicadorFaturamentoRealizadoMetaRepository, IndicadorFaturamentoRealizadoMetaRepository>();
            //services.AddScoped<IIndicadorTempoManutencaoCorretivaEquipamentoProgramadoRepository, IndicadorTempoManutencaoCorretivaEquipamentoProgramadoRepository>();
            //services.AddScoped<IIndicadorTempoManutencaoCorretivaEquipamentoProgramadoMetaRepository, IndicadorTempoManutencaoCorretivaEquipamentoProgramadoMetaRepository>();
            //services.AddScoped<IIndicadorAcaoCorrecaoAvaliadaEficazRepository, IndicadorAcaoCorrecaoAvaliadaEficazRepository>();
            //services.AddScoped<IIndicadorAcaoCorrecaoAvaliadaEficazMetaRepository, IndicadorAcaoCorrecaoAvaliadaEficazMetaRepository>();
            //services.AddScoped<IIndicadorAcaoDentroPrazoRepository, IndicadorAcaoDentroPrazoRepository>();
            //services.AddScoped<IIndicadorAcaoDentroPrazoMetaRepository, IndicadorAcaoDentroPrazoMetaRepository>();
            //services.AddScoped<ISatisfacaoUsuarioMetaRepository, SatisfacaoUsuarioMetaRepository>();
            //services.AddScoped<IIndicadorAutoavaliacaoGerencialSGQRepository, IndicadorAutoavaliacaoGerencialSGQRepository>();
            //services.AddScoped<IIndicadorAutoavaliacaoGerencialSGQMetaRepository, IndicadorAutoavaliacaoGerencialSGQMetaRepository>();
            //services.AddScoped<IIndicadorCapacitacaoAreaContratosRepository, IndicadorCapacitacaoAreaContratosRepository>();
            //services.AddScoped<IIndicadorCapacitacaoAreaContratosMetaRepository, IndicadorCapacitacaoAreaContratosMetaRepository>();
            //services.AddScoped<IIndicadorOcupacaoMaoObraRepository, IndicadorOcupacaoMaoObraRepository>();
            //services.AddScoped<IIndicadorOcupacaoMaoObraMetaRepository, IndicadorOcupacaoMaoObraMetaRepository>();
            //services.AddScoped<IIndicadorProdutividadeMaoObraRepository, IndicadorProdutividadeMaoObraRepository>();
            //services.AddScoped<IIndicadorProdutividadeMaoObraMetaRepository, IndicadorProdutividadeMaoObraMetaRepository>();
            //services.AddScoped<IIndicadorGestaoProcessosPessoasPrevistoPATRepository, IndicadorGestaoProcessosPessoasPrevistoPATRepository>();
            //services.AddScoped<IIndicadorGestaoProcessosPessoasPrevistoPATMetaRepository, IndicadorGestaoProcessosPessoasPrevistoPATMetaRepository>();
            //services.AddScoped<IIndicadorRespostaAreasPrazoOriginalRepository, IndicadorRespostaAreasPrazoOriginalRepository>();
            //services.AddScoped<IIndicadorRespostaAreasPrazoOriginalMetaRepository, IndicadorRespostaAreasPrazoOriginalMetaRepository>();
            //services.AddScoped<IIndicadorRetrabalhoDocumentosRepository, IndicadorRetrabalhoDocumentosRepository>();
            //services.AddScoped<IIndicadorRetrabalhoDocumentosMetaRepository, IndicadorRetrabalhoDocumentosMetaRepository>();
            //services.AddScoped<IIndicadorSatisfacaoClientesAreaResponsavelRepository, IndicadorSatisfacaoClientesAreaResponsavelRepository>();
            //services.AddScoped<IIndicadorSatisfacaoClientesAreaResponsavelMetaRepository, IndicadorSatisfacaoClientesAreaResponsavelMetaRepository>();
            //services.AddScoped<IIndicadorReducaoRNCRepository, IndicadorReducaoRNCRepository>();
            //services.AddScoped<IIndicadorReducaoRNCMetaRepository, IndicadorReducaoRNCMetaRepository>();
            //services.AddScoped<IAnoCicloRepository, AnoCicloRepository>();
            //services.AddScoped<ITaxaConformidadeDocumentosQualidadeRepository, TaxaConformidadeDocumentosQualidadeRepository>();
            //services.AddScoped<ITaxaConformidadeDocumentosQualidadeMetaRepository, TaxaConformidadeDocumentosQualidadeMetaRepository>();
            //services.AddScoped<ITempoMedioInspecaoRecebimentoMateriaisRepository, TempoMedioInspecaoRecebimentoMateriaisRepository>();
            //services.AddScoped<ITempoMedioInspecaoRecebimentoMateriaisMetaRepository, TempoMedioInspecaoRecebimentoMateriaisMetaRepository>();
            //services.AddScoped<ITempoReparoEquipamentosProgramadosObrasRepository, TempoReparoEquipamentosProgramadosObrasRepository>();
            //services.AddScoped<ITempoReparoEquipamentosProgramadosObrasMetaRepository, TempoReparoEquipamentosProgramadosObrasMetaRepository>();

            return services;
        }
    }
}
