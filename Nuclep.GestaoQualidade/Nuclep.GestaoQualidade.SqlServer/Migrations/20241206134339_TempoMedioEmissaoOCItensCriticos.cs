using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class TempoMedioEmissaoOCItensCriticos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsTempoMedioEmissaoOCItensCriticos",
                table: "Sys_Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Ind_TempoMedioEmissaoOCItensCriticos",
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
                    table.PrimaryKey("PK_Ind_TempoMedioEmissaoOCItensCriticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_TempoMedioEmissaoOCItensCriticos_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_TempoMedioEmissaoOCItensCriticosMeta",
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
                    table.PrimaryKey("PK_Ind_TempoMedioEmissaoOCItensCriticosMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_TempoMedioEmissaoOCItensCriticosMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ind_TempoMedioEmissaoOCItensCriticos_UsuarioCadastroId",
                table: "Ind_TempoMedioEmissaoOCItensCriticos",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_TempoMedioEmissaoOCItensCriticosMeta_UsuarioCadastroId",
                table: "Ind_TempoMedioEmissaoOCItensCriticosMeta",
                column: "UsuarioCadastroId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ind_TempoMedioEmissaoOCItensCriticos");

            migrationBuilder.DropTable(
                name: "Ind_TempoMedioEmissaoOCItensCriticosMeta");

            migrationBuilder.DropColumn(
                name: "IsTempoMedioEmissaoOCItensCriticos",
                table: "Sys_Usuario");
        }
    }
}
