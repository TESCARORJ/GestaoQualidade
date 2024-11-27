using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class DefeitoSoldagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ind_DefeitoSoldagem");

            migrationBuilder.DropTable(
                name: "Ind_DefeitoSoldagemMeta");
        }
    }
}
