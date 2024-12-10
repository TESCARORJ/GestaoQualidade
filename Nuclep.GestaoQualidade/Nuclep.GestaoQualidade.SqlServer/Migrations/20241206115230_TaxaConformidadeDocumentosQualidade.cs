using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class TaxaConformidadeDocumentosQualidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ind_TaxaConformidadeDocumentosQualidade",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano1 = table.Column<int>(type: "int", nullable: false),
                    Ano2 = table.Column<int>(type: "int", nullable: false),
                    TotalDocumentos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalDentroPrazo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_TaxaConformidadeDocumentosQualidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_TaxaConformidadeDocumentosQualidade_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_TaxaConformidadeDocumentosQualidadeMeta",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano1 = table.Column<int>(type: "int", nullable: false),
                    Ano2 = table.Column<int>(type: "int", nullable: false),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_TaxaConformidadeDocumentosQualidadeMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_TaxaConformidadeDocumentosQualidadeMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ind_TaxaConformidadeDocumentosQualidade_UsuarioCadastroId",
                table: "Ind_TaxaConformidadeDocumentosQualidade",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_TaxaConformidadeDocumentosQualidadeMeta_UsuarioCadastroId",
                table: "Ind_TaxaConformidadeDocumentosQualidadeMeta",
                column: "UsuarioCadastroId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ind_TaxaConformidadeDocumentosQualidade");

            migrationBuilder.DropTable(
                name: "Ind_TaxaConformidadeDocumentosQualidadeMeta");
        }
    }
}
