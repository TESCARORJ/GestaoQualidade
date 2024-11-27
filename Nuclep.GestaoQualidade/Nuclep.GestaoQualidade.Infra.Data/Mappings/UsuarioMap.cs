using FluentNHibernate.Mapping;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.Infra.Data.Mappings
{
    public class UsuarioMap:ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuario");

            Id(x => x.Id);

            Map(x => x.Nome);
            Map(x => x.NomeAD);
            Map(x => x.IsAtivo);
            Map(x => x.PerfilSistema).Column("PerfilSistema").CustomType("int");
            Map(x => x.DataHoraCadastro);

            References(x => x.UsuarioCadastro).Column("IdUsuarioCadastro");
            Map(x => x.IsLocalidadeAramar).Column("IsLocalidadeAramar");
            Map(x => x.IsLocalidadeItaguai).Column("IsLocalidadeItaguai");
            Map(x => x.IsCondensador).Column("IsCondensador");
            Map(x => x.IsVPR).Column("IsVPR");

            Map(x => x.IsNivelServicoAtendimento).Column("IsNivelServicoAtendimento");
            Map(x => x.IsAderenciaProgramacaoMensal).Column("IsAderenciaProgramacaoMensal");
            Map(x => x.IsSatisfacaoUsuario).Column("IsSatisfacaoUsuario");
            Map(x => x.IsTempoMedioSolucao).Column("IsTempoMedioSolucao");
            Map(x => x.IsItensCadastradosMais15Dias).Column("IsItensCadastradosMais15Dias");
            //Map(x => x.IsIndicadorDuracaoProcessoLicitacao).Column("IsIndicadorDuracaoProcessoLicitacao");
            //Map(x => x.IsIndicadorEventosAtraso).Column("IsIndicadorEventosAtraso");
            //Map(x => x.IsIndicadorFaturamentoRealizado).Column("IsIndicadorFaturamentoRealizado");
            //Map(x => x.IsIndicadorTempoManutencaoCorretivaEquipamentoProgramado).Column("IsIndicadorTempoManutencaoCorretivaEquipamentoProgramado");
            //Map(x => x.IsIndicadorAcaoCorrecaoAvaliadaEficaz).Column("IsIndicadorAcaoCorrecaoAvaliadaEficaz");
            //Map(x => x.IsIndicadorAcaoDentroPrazo).Column("IsIndicadorAcaoDentroPrazo");
            //Map(x => x.IsIndicadorAutoavaliacaoGerencialSGQ).Column("IsIndicadorAutoavaliacaoGerencialSGQ");
            //Map(x => x.IsIndicadorCapacitacaoAreaContratos).Column("IsIndicadorCapacitacaoAreaContratos");
            //Map(x => x.IsIndicadorOcupacaoMaoObra).Column("IsIndicadorOcupacaoMaoObra");
            //Map(x => x.IsIndicadorProdutividadeMaoObra).Column("IsIndicadorProdutividadeMaoObra");
            //Map(x => x.IsIndicadorGestaoProcessosPessoasPrevistoPAT).Column("IsIndicadorGestaoProcessosPessoasPrevistoPAT");
            //Map(x => x.IsIndicadorRespostaAreasPrazoOriginal).Column("IsIndicadorRespostaAreasPrazoOriginal");
            //Map(x => x.IsIndicadorRetrabalhoDocumentos).Column("IsIndicadorRetrabalhoDocumentos");
            //Map(x => x.IsIndicadorSatisfacaoClientesAreaResponsavel).Column("IsIndicadorSatisfacaoClientesAreaResponsavel");
            //Map(x => x.IsIndicadorReducaoRNC).Column("IsIndicadorReducaoRNC");
            Map(x => x.IsTaxaConformidadeDocumentosQualidade).Column("IsTaxaConformidadeDocumentosQualidade");
            Map(x => x.IsTempoMedioInspecaoRecebimentoMateriais).Column("IsTempoMedioInspecaoRecebimentoMateriais");
            Map(x => x.IsTempoReparoEquipamentosProgramadosObras).Column("IsTempoReparoEquipamentosProgramadosObras");
        }
    }
}
