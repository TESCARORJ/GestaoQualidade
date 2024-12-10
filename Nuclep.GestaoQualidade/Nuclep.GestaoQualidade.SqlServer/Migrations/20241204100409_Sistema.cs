using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class Sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sys_LogTabela",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_LogTabela", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Usuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PerfilSistema = table.Column<int>(type: "int", nullable: false),
                    IsConfirmacaoNaoInformado = table.Column<bool>(type: "bit", nullable: false),
                    IsLocalidadeAramar = table.Column<bool>(type: "bit", nullable: false),
                    IsLocalidadeItaguai = table.Column<bool>(type: "bit", nullable: false),
                    IsCondensador = table.Column<bool>(type: "bit", nullable: false),
                    IsVPR = table.Column<bool>(type: "bit", nullable: false),
                    IsNivelServicoAtendimento = table.Column<bool>(type: "bit", nullable: false),
                    IsAderenciaProgramacaoMensal = table.Column<bool>(type: "bit", nullable: false),
                    IsCumprimentoEtapasPACDentroPrazo = table.Column<bool>(type: "bit", nullable: false),
                    IsSatisfacaoUsuario = table.Column<bool>(type: "bit", nullable: false),
                    IsTempoMedioSolucao = table.Column<bool>(type: "bit", nullable: false),
                    IsItensCadastradosMais15Dias = table.Column<bool>(type: "bit", nullable: false),
                    IsDuracaoProcessoLicitacao = table.Column<bool>(type: "bit", nullable: false),
                    IsEventosAtraso = table.Column<bool>(type: "bit", nullable: false),
                    IsFaturamentoRealizado = table.Column<bool>(type: "bit", nullable: false),
                    IsRejeicaoMateriais = table.Column<bool>(type: "bit", nullable: false),
                    IsRespostaAreasRiscosPrazoOriginal = table.Column<bool>(type: "bit", nullable: false),
                    IsTempoManutencaoCorretivaEquipamentoProgramado = table.Column<bool>(type: "bit", nullable: false),
                    IsAcaoCorrecaoAvaliadaEficaz = table.Column<bool>(type: "bit", nullable: false),
                    IsCumprimentoVerbaDestinadaPATMME = table.Column<bool>(type: "bit", nullable: false),
                    IsEficaciaTreinamento = table.Column<bool>(type: "bit", nullable: false),
                    IsAcaoDentroPrazo = table.Column<bool>(type: "bit", nullable: false),
                    IsAutoavaliacaoGerencialSGQ = table.Column<bool>(type: "bit", nullable: false),
                    IsCapacitacaoAreaContratos = table.Column<bool>(type: "bit", nullable: false),
                    IsOcupacaoMaoObra = table.Column<bool>(type: "bit", nullable: false),
                    IsProdutividadeMaoObra = table.Column<bool>(type: "bit", nullable: false),
                    IsSatisfacaoClientes = table.Column<bool>(type: "bit", nullable: false),
                    IsGestaoProcessosPessoasPrevistoPAT = table.Column<bool>(type: "bit", nullable: false),
                    IsRespostaAreasPrazoOriginal = table.Column<bool>(type: "bit", nullable: false),
                    IsRetrabalhoDocumentos = table.Column<bool>(type: "bit", nullable: false),
                    IsSatisfacaoClientesAreaResponsavel = table.Column<bool>(type: "bit", nullable: false),
                    IsReducaoRNC = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxaConformidadeDocumentosQualidade = table.Column<bool>(type: "bit", nullable: false),
                    IsTempoMedioInspecaoRecebimentoMateriais = table.Column<bool>(type: "bit", nullable: false),
                    IsTempoReparoEquipamentosProgramadosObras = table.Column<bool>(type: "bit", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCadastro = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_Usuario_Sys_Usuario_IdUsuarioCadastro",
                        column: x => x.IdUsuarioCadastro,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ind_AcaoCorrecaoAvaliadaEficaz",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Trimestre = table.Column<int>(type: "int", nullable: false),
                    TotalAbertura = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalFechamento = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalTratamentoEficaz = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_AcaoCorrecaoAvaliadaEficaz", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_AcaoCorrecaoAvaliadaEficaz_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_AcaoCorrecaoAvaliadaEficazMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_AcaoCorrecaoAvaliadaEficazMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_AcaoCorrecaoAvaliadaEficazMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_AderenciaProgramacaoMensal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    TotalAtividadesProgramadas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AtividadesRealizadas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AtividadesCanceladas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_AderenciaProgramacaoMensal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_AderenciaProgramacaoMensal_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_AderenciaProgramacaoMensalMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_AderenciaProgramacaoMensalMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_AderenciaProgramacaoMensalMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_AutoavaliacaoGerencialSGQ",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Realizado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_AutoavaliacaoGerencialSGQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_AutoavaliacaoGerencialSGQ_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_AutoavaliacaoGerencialSGQMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_AutoavaliacaoGerencialSGQMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_AutoavaliacaoGerencialSGQMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_CumprimentoEtapasPACDentroPrazo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    PACPrazo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPACAberto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_CumprimentoEtapasPACDentroPrazo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_CumprimentoEtapasPACDentroPrazo_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_CumprimentoEtapasPACDentroPrazoMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_CumprimentoEtapasPACDentroPrazoMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_CumprimentoEtapasPACDentroPrazoMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_CumprimentoVerbaDestinadaPATMME",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Realizado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_CumprimentoVerbaDestinadaPATMME", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_CumprimentoVerbaDestinadaPATMME_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_CumprimentoVerbaDestinadaPATMMEMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_CumprimentoVerbaDestinadaPATMMEMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_CumprimentoVerbaDestinadaPATMMEMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_DefeitoSoldagemMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_DefeitoSoldagemMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_DefeitoSoldagemMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_DuracaoProcessoLicitacao",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Trimestre = table.Column<int>(type: "int", nullable: false),
                    DiasCorridos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_DuracaoProcessoLicitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_DuracaoProcessoLicitacao_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_DuracaoProcessoLicitacaoMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_DuracaoProcessoLicitacaoMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_DuracaoProcessoLicitacaoMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_EficaciaTreinamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Realizado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_EficaciaTreinamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_EficaciaTreinamento_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_EficaciaTreinamentoMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_EficaciaTreinamentoMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_EficaciaTreinamentoMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_FaturamentoRealizado",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Trimestre = table.Column<int>(type: "int", nullable: false),
                    SomatorioFaturamentoRealizadoTrimestre = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrevistoJaneiroAnoCorrente = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_FaturamentoRealizado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_FaturamentoRealizado_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_FaturamentoRealizadoMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_FaturamentoRealizadoMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_FaturamentoRealizadoMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_OcupacaoMaoObra",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    TempoEfetivoFabril = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TempoDisponivelFabril = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_OcupacaoMaoObra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_OcupacaoMaoObra_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_OcupacaoMaoObraMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_OcupacaoMaoObraMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_OcupacaoMaoObraMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_ProdutividadeMaoObra",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    TempoTotalFaturavel = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TempoDisponivelTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_ProdutividadeMaoObra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_ProdutividadeMaoObra_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_ProdutividadeMaoObraMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_ProdutividadeMaoObraMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_ProdutividadeMaoObraMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_RejeicaoMateriais",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Trimestre = table.Column<int>(type: "int", nullable: false),
                    TotalCTIsRejeitados = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCTIsFinalizados = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_RejeicaoMateriais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_RejeicaoMateriais_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_RejeicaoMateriaisMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_RejeicaoMateriaisMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_RejeicaoMateriaisMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_RespostaAreasRiscosPrazoOriginal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Trimestre = table.Column<int>(type: "int", nullable: false),
                    Realizado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_RespostaAreasRiscosPrazoOriginal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_RespostaAreasRiscosPrazoOriginal_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_RespostaAreasRiscosPrazoOriginalMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_RespostaAreasRiscosPrazoOriginalMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_RespostaAreasRiscosPrazoOriginalMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ind_SatisfacaoClientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Realizado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_SatisfacaoClientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_SatisfacaoClientes_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_SatisfacaoClientesMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_SatisfacaoClientesMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_SatisfacaoClientesMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sys_Localidade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_Localidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_Localidade_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sys_LogCrud",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReferencia = table.Column<long>(type: "bigint", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    IdLogTabela = table.Column<long>(type: "bigint", nullable: false),
                    IdLogTabela1 = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_LogCrud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_LogCrud_Sys_LogTabela_IdLogTabela1",
                        column: x => x.IdLogTabela1,
                        principalTable: "Sys_LogTabela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Sys_LogCrud_Sys_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_DefeitoSoldagem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    TotalDefeitosSoldaEncontradosEnsaiadosVolumetricos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalComprimentoSoldadoInspecionado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LocalidadeId = table.Column<long>(type: "bigint", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_DefeitoSoldagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_DefeitoSoldagem_Sys_Localidade_LocalidadeId",
                        column: x => x.LocalidadeId,
                        principalTable: "Sys_Localidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ind_DefeitoSoldagem_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ind_AcaoCorrecaoAvaliadaEficaz_UsuarioCadastroId",
                table: "Ind_AcaoCorrecaoAvaliadaEficaz",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_AcaoCorrecaoAvaliadaEficazMeta_UsuarioCadastroId",
                table: "Ind_AcaoCorrecaoAvaliadaEficazMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_AderenciaProgramacaoMensal_UsuarioCadastroId",
                table: "Ind_AderenciaProgramacaoMensal",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_AderenciaProgramacaoMensalMeta_UsuarioCadastroId",
                table: "Ind_AderenciaProgramacaoMensalMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_AutoavaliacaoGerencialSGQ_UsuarioCadastroId",
                table: "Ind_AutoavaliacaoGerencialSGQ",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_AutoavaliacaoGerencialSGQMeta_UsuarioCadastroId",
                table: "Ind_AutoavaliacaoGerencialSGQMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_CumprimentoEtapasPACDentroPrazo_UsuarioCadastroId",
                table: "Ind_CumprimentoEtapasPACDentroPrazo",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_CumprimentoEtapasPACDentroPrazoMeta_UsuarioCadastroId",
                table: "Ind_CumprimentoEtapasPACDentroPrazoMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_CumprimentoVerbaDestinadaPATMME_UsuarioCadastroId",
                table: "Ind_CumprimentoVerbaDestinadaPATMME",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_CumprimentoVerbaDestinadaPATMMEMeta_UsuarioCadastroId",
                table: "Ind_CumprimentoVerbaDestinadaPATMMEMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_DefeitoSoldagem_LocalidadeId",
                table: "Ind_DefeitoSoldagem",
                column: "LocalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_DefeitoSoldagem_UsuarioCadastroId",
                table: "Ind_DefeitoSoldagem",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_DefeitoSoldagemMeta_UsuarioCadastroId",
                table: "Ind_DefeitoSoldagemMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_DuracaoProcessoLicitacao_UsuarioCadastroId",
                table: "Ind_DuracaoProcessoLicitacao",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_DuracaoProcessoLicitacaoMeta_UsuarioCadastroId",
                table: "Ind_DuracaoProcessoLicitacaoMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_EficaciaTreinamento_UsuarioCadastroId",
                table: "Ind_EficaciaTreinamento",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_EficaciaTreinamentoMeta_UsuarioCadastroId",
                table: "Ind_EficaciaTreinamentoMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_FaturamentoRealizado_UsuarioCadastroId",
                table: "Ind_FaturamentoRealizado",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_FaturamentoRealizadoMeta_UsuarioCadastroId",
                table: "Ind_FaturamentoRealizadoMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_OcupacaoMaoObra_UsuarioCadastroId",
                table: "Ind_OcupacaoMaoObra",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_OcupacaoMaoObraMeta_UsuarioCadastroId",
                table: "Ind_OcupacaoMaoObraMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_ProdutividadeMaoObra_UsuarioCadastroId",
                table: "Ind_ProdutividadeMaoObra",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_ProdutividadeMaoObraMeta_UsuarioCadastroId",
                table: "Ind_ProdutividadeMaoObraMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_RejeicaoMateriais_UsuarioCadastroId",
                table: "Ind_RejeicaoMateriais",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_RejeicaoMateriaisMeta_UsuarioCadastroId",
                table: "Ind_RejeicaoMateriaisMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_RespostaAreasRiscosPrazoOriginal_UsuarioCadastroId",
                table: "Ind_RespostaAreasRiscosPrazoOriginal",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_RespostaAreasRiscosPrazoOriginalMeta_UsuarioCadastroId",
                table: "Ind_RespostaAreasRiscosPrazoOriginalMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ind_SatisfacaoClientes_UsuarioCadastroId",
                table: "Ind_SatisfacaoClientes",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_SatisfacaoClientesMeta_UsuarioCadastroId",
                table: "Ind_SatisfacaoClientesMeta",
                column: "UsuarioCadastroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Localidade_UsuarioCadastroId",
                table: "Sys_Localidade",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_LogCrud_IdLogTabela1",
                table: "Sys_LogCrud",
                column: "IdLogTabela1");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_LogCrud_UsuarioId",
                table: "Sys_LogCrud",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Usuario_IdUsuarioCadastro",
                table: "Sys_Usuario",
                column: "IdUsuarioCadastro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ind_AcaoCorrecaoAvaliadaEficaz");

            migrationBuilder.DropTable(
                name: "Ind_AcaoCorrecaoAvaliadaEficazMeta");

            migrationBuilder.DropTable(
                name: "Ind_AderenciaProgramacaoMensal");

            migrationBuilder.DropTable(
                name: "Ind_AderenciaProgramacaoMensalMeta");

            migrationBuilder.DropTable(
                name: "Ind_AutoavaliacaoGerencialSGQ");

            migrationBuilder.DropTable(
                name: "Ind_AutoavaliacaoGerencialSGQMeta");

            migrationBuilder.DropTable(
                name: "Ind_CumprimentoEtapasPACDentroPrazo");

            migrationBuilder.DropTable(
                name: "Ind_CumprimentoEtapasPACDentroPrazoMeta");

            migrationBuilder.DropTable(
                name: "Ind_CumprimentoVerbaDestinadaPATMME");

            migrationBuilder.DropTable(
                name: "Ind_CumprimentoVerbaDestinadaPATMMEMeta");

            migrationBuilder.DropTable(
                name: "Ind_DefeitoSoldagem");

            migrationBuilder.DropTable(
                name: "Ind_DefeitoSoldagemMeta");

            migrationBuilder.DropTable(
                name: "Ind_DuracaoProcessoLicitacao");

            migrationBuilder.DropTable(
                name: "Ind_DuracaoProcessoLicitacaoMeta");

            migrationBuilder.DropTable(
                name: "Ind_EficaciaTreinamento");

            migrationBuilder.DropTable(
                name: "Ind_EficaciaTreinamentoMeta");

            migrationBuilder.DropTable(
                name: "Ind_FaturamentoRealizado");

            migrationBuilder.DropTable(
                name: "Ind_FaturamentoRealizadoMeta");

            migrationBuilder.DropTable(
                name: "Ind_OcupacaoMaoObra");

            migrationBuilder.DropTable(
                name: "Ind_OcupacaoMaoObraMeta");

            migrationBuilder.DropTable(
                name: "Ind_ProdutividadeMaoObra");

            migrationBuilder.DropTable(
                name: "Ind_ProdutividadeMaoObraMeta");

            migrationBuilder.DropTable(
                name: "Ind_RejeicaoMateriais");

            migrationBuilder.DropTable(
                name: "Ind_RejeicaoMateriaisMeta");

            migrationBuilder.DropTable(
                name: "Ind_RespostaAreasRiscosPrazoOriginal");

            migrationBuilder.DropTable(
                name: "Ind_RespostaAreasRiscosPrazoOriginalMeta");

            migrationBuilder.DropTable(
                name: "Ind_SatisfacaoClientes");

            migrationBuilder.DropTable(
                name: "Ind_SatisfacaoClientesMeta");

            migrationBuilder.DropTable(
                name: "Sys_LogCrud");

            migrationBuilder.DropTable(
                name: "Sys_Localidade");

            migrationBuilder.DropTable(
                name: "Sys_LogTabela");

            migrationBuilder.DropTable(
                name: "Sys_Usuario");
        }
    }
}
