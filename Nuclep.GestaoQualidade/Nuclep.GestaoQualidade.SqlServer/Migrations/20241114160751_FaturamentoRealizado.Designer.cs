﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nuclep.GestaoQualidade.SqlServer.Contexts;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241114160751_FaturamentoRealizado")]
    partial class FaturamentoRealizado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AcaoCorrecaoAvaliadaEficaz", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("Meta")
                        .HasColumnType("int");

                    b.Property<string>("NomeAD")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("TotalAbertura")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalFechamento")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("TotalTratamentoEficaz")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Trimestre")
                        .HasColumnType("int")
                        .HasColumnName("Trimestre");

                    b.Property<long>("UsuarioCadastroId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("Ind_AcaoCorrecaoAvaliadaEficaz", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AcaoCorrecaoAvaliadaEficazMeta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("Meta")
                        .HasColumnType("int");

                    b.Property<string>("NomeAD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioCadastroId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCadastroId")
                        .IsUnique();

                    b.ToTable("Ind_AcaoCorrecaoAvaliadaEficazMeta", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AderenciaProgramacaoMensal", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<decimal?>("AtividadesCanceladas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AtividadesRealizadas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("Mes")
                        .HasColumnType("int")
                        .HasColumnName("Mes");

                    b.Property<int>("Meta")
                        .HasColumnType("int");

                    b.Property<string>("NomeAD")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("TotalAtividadesProgramadas")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("UsuarioCadastroId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("Ind_AderenciaProgramacaoMensal", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AderenciaProgramacaoMensalMeta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<decimal>("Meta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NomeAD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioCadastroId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCadastroId")
                        .IsUnique();

                    b.ToTable("Ind_AderenciaProgramacaoMensalMeta", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.FaturamentoRealizado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("Meta")
                        .HasColumnType("int");

                    b.Property<string>("NomeAD")
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("PrevistoJaneiroAnoCorrente")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SomatorioFaturamentoRealizadoTrimestre")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Trimestre")
                        .HasColumnType("int")
                        .HasColumnName("Trimestre");

                    b.Property<long>("UsuarioCadastroId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCadastroId");

                    b.ToTable("Ind_FaturamentoRealizado", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.FaturamentoRealizadoMeta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int>("Ano")
                        .HasColumnType("int")
                        .HasColumnName("Ano");

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<int>("Meta")
                        .HasColumnType("int");

                    b.Property<string>("NomeAD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UsuarioCadastroId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioCadastroId")
                        .IsUnique();

                    b.ToTable("Ind_FaturamentoRealizadoMeta", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.LogCrud", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataHoraCadastro");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdLogTabela")
                        .HasColumnType("bigint");

                    b.Property<long>("IdReferencia")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<long>("LogTabelaId")
                        .HasColumnType("bigint");

                    b.Property<int>("LogTipo")
                        .HasColumnType("int")
                        .HasColumnName("Tipo");

                    b.Property<string>("NomeAD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UsuarioCadastroId1")
                        .HasColumnType("bigint");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("IdLogTabela");

                    b.HasIndex("UsuarioCadastroId1");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Sys_LogCrud", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.LogTabela", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sys_LogTabela", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("DataHoraCadastro")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdUsuarioCadastro")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsAcaoCorrecaoAvaliadaEficaz")
                        .HasColumnType("bit")
                        .HasColumnName("IsAcaoCorrecaoAvaliadaEficaz");

                    b.Property<bool>("IsAcaoDentroPrazo")
                        .HasColumnType("bit")
                        .HasColumnName("IsAcaoDentroPrazo");

                    b.Property<bool>("IsAderenciaProgramacaoMensal")
                        .HasColumnType("bit")
                        .HasColumnName("IsAderenciaProgramacaoMensal");

                    b.Property<bool>("IsAtivo")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAutoavaliacaoGerencialSGQ")
                        .HasColumnType("bit")
                        .HasColumnName("IsAutoavaliacaoGerencialSGQ");

                    b.Property<bool>("IsCapacitacaoAreaContratos")
                        .HasColumnType("bit")
                        .HasColumnName("IsCapacitacaoAreaContratos");

                    b.Property<bool>("IsCondensador")
                        .HasColumnType("bit")
                        .HasColumnName("IsCondensador");

                    b.Property<bool>("IsConfirmacaoNaoInformado")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDuracaoProcessoLicitacao")
                        .HasColumnType("bit")
                        .HasColumnName("IsDuracaoProcessoLicitacao");

                    b.Property<bool>("IsEventosAtraso")
                        .HasColumnType("bit")
                        .HasColumnName("IsEventosAtraso");

                    b.Property<bool>("IsFaturamentoRealizado")
                        .HasColumnType("bit")
                        .HasColumnName("IsFaturamentoRealizado");

                    b.Property<bool>("IsGestaoProcessosPessoasPrevistoPAT")
                        .HasColumnType("bit")
                        .HasColumnName("IsGestaoProcessosPessoasPrevistoPAT");

                    b.Property<bool>("IsItensCadastradosMais15Dias")
                        .HasColumnType("bit")
                        .HasColumnName("IsItensCadastradosMais15Dias");

                    b.Property<bool>("IsLocalidadeAramar")
                        .HasColumnType("bit")
                        .HasColumnName("IsLocalidadeAramar");

                    b.Property<bool>("IsLocalidadeItaguai")
                        .HasColumnType("bit")
                        .HasColumnName("IsLocalidadeItaguai");

                    b.Property<bool>("IsNivelServicoAtendimento")
                        .HasColumnType("bit")
                        .HasColumnName("IsNivelServicoAtendimento");

                    b.Property<bool>("IsOcupacaoMaoObra")
                        .HasColumnType("bit")
                        .HasColumnName("IsOcupacaoMaoObra");

                    b.Property<bool>("IsProdutividadeMaoObra")
                        .HasColumnType("bit")
                        .HasColumnName("IsProdutividadeMaoObra");

                    b.Property<bool>("IsReducaoRNC")
                        .HasColumnType("bit")
                        .HasColumnName("IsReducaoRNC");

                    b.Property<bool>("IsRejeicaoMateriaisAntesTratamento")
                        .HasColumnType("bit")
                        .HasColumnName("IsRejeicaoMateriaisAntesTratamento");

                    b.Property<bool>("IsRespostaAreasPrazoOriginal")
                        .HasColumnType("bit")
                        .HasColumnName("IsRespostaAreasPrazoOriginal");

                    b.Property<bool>("IsRetrabalhoDocumentos")
                        .HasColumnType("bit")
                        .HasColumnName("IsRetrabalhoDocumentos");

                    b.Property<bool>("IsSatisfacaoClientesAreaResponsavel")
                        .HasColumnType("bit")
                        .HasColumnName("IsSatisfacaoClientesAreaResponsavel");

                    b.Property<bool>("IsSatisfacaoUsuario")
                        .HasColumnType("bit")
                        .HasColumnName("IsSatisfacaoUsuario");

                    b.Property<bool>("IsTaxaConformidadeDocumentosQualidade")
                        .HasColumnType("bit")
                        .HasColumnName("IsTaxaConformidadeDocumentosQualidade");

                    b.Property<bool>("IsTempoManutencaoCorretivaEquipamentoProgramado")
                        .HasColumnType("bit")
                        .HasColumnName("IsTempoManutencaoCorretivaEquipamentoProgramado");

                    b.Property<bool>("IsTempoMedioInspecaoRecebimentoMateriais")
                        .HasColumnType("bit")
                        .HasColumnName("IsTempoMedioInspecaoRecebimentoMateriais");

                    b.Property<bool>("IsTempoMedioSolucao")
                        .HasColumnType("bit")
                        .HasColumnName("IsTempoMedioSolucao");

                    b.Property<bool>("IsTempoReparoEquipamentosProgramadosObras")
                        .HasColumnType("bit")
                        .HasColumnName("IsTempoReparoEquipamentosProgramadosObras");

                    b.Property<bool>("IsVPR")
                        .HasColumnType("bit")
                        .HasColumnName("IsVPR");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeAD")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PerfilSistema")
                        .HasColumnType("int")
                        .HasColumnName("PerfilSistema");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioCadastro");

                    b.ToTable("Sys_Usuario", (string)null);
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AcaoCorrecaoAvaliadaEficaz", b =>
                {
                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AcaoCorrecaoAvaliadaEficazMeta", b =>
                {
                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "UsuarioCadastro")
                        .WithOne()
                        .HasForeignKey("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AcaoCorrecaoAvaliadaEficazMeta", "UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AderenciaProgramacaoMensal", b =>
                {
                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AderenciaProgramacaoMensalMeta", b =>
                {
                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "UsuarioCadastro")
                        .WithOne()
                        .HasForeignKey("Nuclep.GestaoQualidade.Domain.Models.Indicadores.AderenciaProgramacaoMensalMeta", "UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.FaturamentoRealizado", b =>
                {
                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Indicadores.FaturamentoRealizadoMeta", b =>
                {
                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "UsuarioCadastro")
                        .WithOne()
                        .HasForeignKey("Nuclep.GestaoQualidade.Domain.Models.Indicadores.FaturamentoRealizadoMeta", "UsuarioCadastroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.LogCrud", b =>
                {
                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.LogTabela", "LogTabela")
                        .WithMany()
                        .HasForeignKey("IdLogTabela")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("UsuarioCadastroId1");

                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LogTabela");

                    b.Navigation("Usuario");

                    b.Navigation("UsuarioCadastro");
                });

            modelBuilder.Entity("Nuclep.GestaoQualidade.Domain.Models.Usuario", b =>
                {
                    b.HasOne("Nuclep.GestaoQualidade.Domain.Models.Usuario", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCadastro");

                    b.Navigation("UsuarioCadastro");
                });
#pragma warning restore 612, 618
        }
    }
}
