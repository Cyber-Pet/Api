using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class bowl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bowl_Pets_PetId",
                table: "Bowl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bowl",
                table: "Bowl");

            migrationBuilder.RenameTable(
                name: "Bowl",
                newName: "Bowls");

            migrationBuilder.RenameIndex(
                name: "IX_Bowl_PetId",
                table: "Bowls",
                newName: "IX_Bowls_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bowls",
                table: "Bowls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bowls_Pets_PetId",
                table: "Bowls",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bowls_Pets_PetId",
                table: "Bowls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bowls",
                table: "Bowls");

            migrationBuilder.RenameTable(
                name: "Bowls",
                newName: "Bowl");

            migrationBuilder.RenameIndex(
                name: "IX_Bowls_PetId",
                table: "Bowl",
                newName: "IX_Bowl_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bowl",
                table: "Bowl",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bowl_Pets_PetId",
                table: "Bowl",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
