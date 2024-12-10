using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class LogCrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sys_LogCrud_Sys_LogTabela_IdLogTabela1",
                table: "Sys_LogCrud");

            migrationBuilder.DropIndex(
                name: "IX_Sys_LogCrud_IdLogTabela1",
                table: "Sys_LogCrud");

            migrationBuilder.DropColumn(
                name: "IdLogTabela1",
                table: "Sys_LogCrud");

            migrationBuilder.RenameColumn(
                name: "IdLogTabela",
                table: "Sys_LogCrud",
                newName: "LogTabelaId");

            migrationBuilder.AddColumn<bool>(
                name: "IsAtivo",
                table: "Sys_LogCrud",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LogTabelaNome",
                table: "Sys_LogCrud",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeAD",
                table: "Sys_LogCrud",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Sys_LogCrud",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAtivo",
                table: "Sys_LogCrud");

            migrationBuilder.DropColumn(
                name: "LogTabelaNome",
                table: "Sys_LogCrud");

            migrationBuilder.DropColumn(
                name: "NomeAD",
                table: "Sys_LogCrud");

            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Sys_LogCrud");

            migrationBuilder.RenameColumn(
                name: "LogTabelaId",
                table: "Sys_LogCrud",
                newName: "IdLogTabela");

            migrationBuilder.AddColumn<long>(
                name: "IdLogTabela1",
                table: "Sys_LogCrud",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_LogCrud_IdLogTabela1",
                table: "Sys_LogCrud",
                column: "IdLogTabela1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_LogCrud_Sys_LogTabela_IdLogTabela1",
                table: "Sys_LogCrud",
                column: "IdLogTabela1",
                principalTable: "Sys_LogTabela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
