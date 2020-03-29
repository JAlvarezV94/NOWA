using Microsoft.EntityFrameworkCore.Migrations;

namespace NOWA.Migrations
{
    public partial class CorrectTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nowaset_Userset_UserId",
                table: "Nowaset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Userset",
                table: "Userset");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nowaset",
                table: "Nowaset");

            migrationBuilder.RenameTable(
                name: "Userset",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Nowaset",
                newName: "Nowa");

            migrationBuilder.RenameIndex(
                name: "IX_Nowaset_UserId",
                table: "Nowa",
                newName: "IX_Nowa_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nowa",
                table: "Nowa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nowa_User_UserId",
                table: "Nowa",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nowa_User_UserId",
                table: "Nowa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nowa",
                table: "Nowa");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Userset");

            migrationBuilder.RenameTable(
                name: "Nowa",
                newName: "Nowaset");

            migrationBuilder.RenameIndex(
                name: "IX_Nowa_UserId",
                table: "Nowaset",
                newName: "IX_Nowaset_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userset",
                table: "Userset",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nowaset",
                table: "Nowaset",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nowaset_Userset_UserId",
                table: "Nowaset",
                column: "UserId",
                principalTable: "Userset",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
