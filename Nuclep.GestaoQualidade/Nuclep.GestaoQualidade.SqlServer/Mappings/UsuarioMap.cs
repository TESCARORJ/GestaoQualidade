using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nuclep.GestaoQualidade.Domain.Models;

namespace Nuclep.GestaoQualidade.SqlServer.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Sys_Usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome);
            builder.Property(x => x.NomeAD);
            builder.Property(x => x.IsAtivo);
            builder.Property(x => x.PerfilSistema).HasColumnName("PerfilSistema").HasColumnType("int");
            builder.Property(x => x.DataHoraCadastro);

            builder.HasOne(x => x.UsuarioCadastro).WithMany().HasForeignKey("IdUsuarioCadastro");
            builder.Property(x => x.IsLocalidadeAramar).HasColumnName("IsLocalidadeAramar");
            builder.Property(x => x.IsLocalidadeItaguai).HasColumnName("IsLocalidadeItaguai");
            builder.Property(x => x.IsCondensador).HasColumnName("IsCondensador");
            builder.Property(x => x.IsVPR).HasColumnName("IsVPR");

            builder.Property(x => x.IsNivelServicoAtendimento).HasColumnName("IsNivelServicoAtendimento");
            builder.Property(x => x.IsAderenciaProgramacaoMensal).HasColumnName("IsAderenciaProgramacaoMensal");
            builder.Property(x => x.IsCumprimentoEtapasPACDentroPrazo).HasColumnName("IsCumprimentoEtapasPACDentroPrazo");
            builder.Property(x => x.IsSatisfacaoUsuario).HasColumnName("IsSatisfacaoUsuario");
            builder.Property(x => x.IsTempoMedioSolucao).HasColumnName("IsTempoMedioSolucao");
            builder.Property(x => x.IsServiceLevelAgreement).HasColumnName("IsServiceLevelAgreement");
            builder.Property(x => x.IsNaoConformidade).HasColumnName("IsNaoConformidade");
            builder.Property(x => x.IsItensCadastradosMais15Dias).HasColumnName("IsItensCadastradosMais15Dias");
            builder.Property(x => x.IsDuracaoProcessoLicitacao).HasColumnName("IsDuracaoProcessoLicitacao");
            builder.Property(x => x.IsEventosAtraso).HasColumnName("IsEventosAtraso");
            builder.Property(x => x.IsFaturamentoRealizado).HasColumnName("IsFaturamentoRealizado");
            builder.Property(x => x.IsRejeicaoMateriais).HasColumnName("IsRejeicaoMateriais");
            builder.Property(x => x.IsRespostaAreasRiscosPrazoOriginal).HasColumnName("IsRespostaAreasRiscosPrazoOriginal");
            builder.Property(x => x.IsTempoManutencaoCorretivaEquipamentoProgramado).HasColumnName("IsTempoManutencaoCorretivaEquipamentoProgramado");
            builder.Property(x => x.IsAcaoCorrecaoAvaliadaEficaz).HasColumnName("IsAcaoCorrecaoAvaliadaEficaz");
            builder.Property(x => x.IsCumprimentoVerbaDestinadaPATMME).HasColumnName("IsCumprimentoVerbaDestinadaPATMME");
            builder.Property(x => x.IsEficaciaTreinamento).HasColumnName("IsEficaciaTreinamento");
            builder.Property(x => x.IsAcaoDentroPrazo).HasColumnName("IsAcaoDentroPrazo");
            builder.Property(x => x.IsAutoavaliacaoGerencialSGQ).HasColumnName("IsAutoavaliacaoGerencialSGQ");
            builder.Property(x => x.IsCapacitacaoAreaContratos).HasColumnName("IsCapacitacaoAreaContratos");
            builder.Property(x => x.IsOcupacaoMaoObra).HasColumnName("IsOcupacaoMaoObra");
            builder.Property(x => x.IsProdutividadeMaoObra).HasColumnName("IsProdutividadeMaoObra");
            builder.Property(x => x.IsSatisfacaoClientes).HasColumnName("IsSatisfacaoClientes");
            builder.Property(x => x.IsTempoMedioEmissaoOCItensCriticos).HasColumnName("IsTempoMedioEmissaoOCItensCriticos");
            builder.Property(x => x.IsGestaoProcessosPessoasPrevistoPAT).HasColumnName("IsGestaoProcessosPessoasPrevistoPAT");
            builder.Property(x => x.IsRespostaAreasPrazoOriginal).HasColumnName("IsRespostaAreasPrazoOriginal");
            builder.Property(x => x.IsRetrabalhoDocumentos).HasColumnName("IsRetrabalhoDocumentos");
            builder.Property(x => x.IsSatisfacaoClientesAreaResponsavel).HasColumnName("IsSatisfacaoClientesAreaResponsavel");
            builder.Property(x => x.IsReducaoRNC).HasColumnName("IsReducaoRNC");
            builder.Property(x => x.IsTaxaConformidadeDocumentosQualidade).HasColumnName("IsTaxaConformidadeDocumentosQualidade");
            builder.Property(x => x.IsTempoMedioInspecaoRecebimentoMateriais).HasColumnName("IsTempoMedioInspecaoRecebimentoMateriais");
            builder.Property(x => x.IsTempoReparoEquipamentosProgramadosObras).HasColumnName("IsTempoReparoEquipamentosProgramadosObras");
        }
    }
}
