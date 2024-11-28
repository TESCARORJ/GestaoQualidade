using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nuclep.GestaoQualidade.SqlServer.Migrations
{
    public partial class LogCrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sys_LogCrud_Sys_LogTabela_IdLogTabela",
                table: "Sys_LogCrud");

            migrationBuilder.DropIndex(
                name: "IX_Sys_LogCrud_IdLogTabela",
                table: "Sys_LogCrud");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.CreateIndex(
                name: "IX_Sys_LogCrud_IdLogTabela",
                table: "Sys_LogCrud",
                column: "IdLogTabela");

            migrationBuilder.AddForeignKey(
                name: "FK_Sys_LogCrud_Sys_LogTabela_IdLogTabela",
                table: "Sys_LogCrud",
                column: "IdLogTabela",
                principalTable: "Sys_LogTabela",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
