using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class LogCrud2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sys_LogCrud_Sys_Usuario_UsuarioCadastroId1",
                table: "Sys_LogCrud");

            migrationBuilder.DropIndex(
                name: "IX_Sys_LogCrud_UsuarioCadastroId1",
                table: "Sys_LogCrud");

            migrationBuilder.DropColumn(
                name: "UsuarioCadastroId1",
                table: "Sys_LogCrud");

           

            migrationBuilder.AddColumn<string>(
                name: "UsuarioNome",
                table: "Sys_LogCrud",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioNome",
                table: "Sys_LogCrud");
           

            migrationBuilder.AddColumn<long>(
                name: "UsuarioCadastroId1",
                table: "Sys_LogCrud",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sys_LogCrud_UsuarioCadastroId1",
                table: "Sys_LogCrud",
                column: "UsuarioCadastroId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_LogCrud_Sys_Usuario_UsuarioCadastroId1",
                table: "Sys_LogCrud",
                column: "UsuarioCadastroId1",
                principalTable: "Sys_Usuario",
                principalColumn: "Id");
        }
    }
}
