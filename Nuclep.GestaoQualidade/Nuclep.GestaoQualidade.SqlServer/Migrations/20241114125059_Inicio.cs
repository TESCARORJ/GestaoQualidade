using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class Inicio : Migration
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
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioCadastro = table.Column<long>(type: "bigint", nullable: true),
                    PerfilSistema = table.Column<int>(type: "int", nullable: false),
                    IsConfirmacaoNaoInformado = table.Column<bool>(type: "bit", nullable: false),
                    IsLocalidadeAramar = table.Column<bool>(type: "bit", nullable: false),
                    IsLocalidadeItaguai = table.Column<bool>(type: "bit", nullable: false),
                    IsCondensador = table.Column<bool>(type: "bit", nullable: false),
                    IsVPR = table.Column<bool>(type: "bit", nullable: false),
                    IsNivelServicoAtendimento = table.Column<bool>(type: "bit", nullable: false),
                    IsAderenciaProgramacaoMensal = table.Column<bool>(type: "bit", nullable: false),
                    IsSatisfacaoUsuario = table.Column<bool>(type: "bit", nullable: false),
                    IsTempoMedioSolucao = table.Column<bool>(type: "bit", nullable: false),
                    IsItensCadastradosMais15Dias = table.Column<bool>(type: "bit", nullable: false),
                    IsDuracaoProcessoLicitacao = table.Column<bool>(type: "bit", nullable: false),
                    IsEventosAtraso = table.Column<bool>(type: "bit", nullable: false),
                    IsFaturamentoRealizado = table.Column<bool>(type: "bit", nullable: false),
                    IsTempoManutencaoCorretivaEquipamentoProgramado = table.Column<bool>(type: "bit", nullable: false),
                    IsAcaoCorrecaoAvaliadaEficaz = table.Column<bool>(type: "bit", nullable: false),
                    IsAcaoDentroPrazo = table.Column<bool>(type: "bit", nullable: false),
                    IsAutoavaliacaoGerencialSGQ = table.Column<bool>(type: "bit", nullable: false),
                    IsCapacitacaoAreaContratos = table.Column<bool>(type: "bit", nullable: false),
                    IsOcupacaoMaoObra = table.Column<bool>(type: "bit", nullable: false),
                    IsProdutividadeMaoObra = table.Column<bool>(type: "bit", nullable: false),
                    IsGestaoProcessosPessoasPrevistoPAT = table.Column<bool>(type: "bit", nullable: false),
                    IsRespostaAreasPrazoOriginal = table.Column<bool>(type: "bit", nullable: false),
                    IsRetrabalhoDocumentos = table.Column<bool>(type: "bit", nullable: false),
                    IsSatisfacaoClientesAreaResponsavel = table.Column<bool>(type: "bit", nullable: false),
                    IsReducaoRNC = table.Column<bool>(type: "bit", nullable: false),
                    IsTaxaConformidadeDocumentosQualidade = table.Column<bool>(type: "bit", nullable: false),
                    IsTempoMedioInspecaoRecebimentoMateriais = table.Column<bool>(type: "bit", nullable: false),
                    IsTempoReparoEquipamentosProgramadosObras = table.Column<bool>(type: "bit", nullable: false),
                    IsRejeicaoMateriaisAntesTratamento = table.Column<bool>(type: "bit", nullable: false)
                  
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
                name: "Sys_LogCrud",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReferencia = table.Column<long>(type: "bigint", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    LogTabelaId = table.Column<long>(type: "bigint", nullable: false),
                    IdLogTabela = table.Column<long>(type: "bigint", nullable: false),
                    UsuarioId = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId1 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_LogCrud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sys_LogCrud_Sys_LogTabela_IdLogTabela",
                        column: x => x.IdLogTabela,
                        principalTable: "Sys_LogTabela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sys_LogCrud_Sys_Usuario_UsuarioCadastroId1",
                        column: x => x.UsuarioCadastroId1,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sys_LogCrud_Sys_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Sys_LogCrud_IdLogTabela",
                table: "Sys_LogCrud",
                column: "IdLogTabela");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_LogCrud_UsuarioCadastroId1",
                table: "Sys_LogCrud",
                column: "UsuarioCadastroId1");

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
                name: "Sys_LogCrud");

            migrationBuilder.DropTable(
                name: "Sys_LogTabela");

            migrationBuilder.DropTable(
                name: "Sys_Usuario");
        }
    }
}
