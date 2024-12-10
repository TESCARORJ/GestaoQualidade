using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class SatisfacaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ind_SatisfacaoUsuario",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Atividade1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Atividade2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_SatisfacaoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_SatisfacaoUsuario_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_SatisfacaoUsuarioMeta",
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
                    table.PrimaryKey("PK_Ind_SatisfacaoUsuarioMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_SatisfacaoUsuarioMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ind_SatisfacaoUsuario_UsuarioCadastroId",
                table: "Ind_SatisfacaoUsuario",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_SatisfacaoUsuarioMeta_UsuarioCadastroId",
                table: "Ind_SatisfacaoUsuarioMeta",
                column: "UsuarioCadastroId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ind_SatisfacaoUsuario");

            migrationBuilder.DropTable(
                name: "Ind_SatisfacaoUsuarioMeta");
        }
    }
}
