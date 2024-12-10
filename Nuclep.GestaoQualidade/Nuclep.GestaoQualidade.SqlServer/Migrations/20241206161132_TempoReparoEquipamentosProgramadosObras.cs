using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class TempoReparoEquipamentosProgramadosObras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ind_TempoReparoEquipamentosProgramadosObras",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    TotalHoraManutencaoEquipamentoRealizadas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalHorasTrabalhadas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Meta = table.Column<int>(type: "int", nullable: false),
                    NomeAD = table.Column<string>(type: "varchar(255)", nullable: true),
                    IsAtivo = table.Column<bool>(type: "bit", nullable: false),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCadastroId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ind_TempoReparoEquipamentosProgramadosObras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_TempoReparoEquipamentosProgramadosObras_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ind_TempoReparoEquipamentosProgramadosObrasMeta",
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
                    table.PrimaryKey("PK_Ind_TempoReparoEquipamentosProgramadosObrasMeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ind_TempoReparoEquipamentosProgramadosObrasMeta_Sys_Usuario_UsuarioCadastroId",
                        column: x => x.UsuarioCadastroId,
                        principalTable: "Sys_Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ind_TempoReparoEquipamentosProgramadosObras_UsuarioCadastroId",
                table: "Ind_TempoReparoEquipamentosProgramadosObras",
                column: "UsuarioCadastroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ind_TempoReparoEquipamentosProgramadosObrasMeta_UsuarioCadastroId",
                table: "Ind_TempoReparoEquipamentosProgramadosObrasMeta",
                column: "UsuarioCadastroId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ind_TempoReparoEquipamentosProgramadosObras");

            migrationBuilder.DropTable(
                name: "Ind_TempoReparoEquipamentosProgramadosObrasMeta");
        }
    }
}
