using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class novosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pets_PetId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PetId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Pets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_Users_UserId",
                table: "Pets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_Users_UserId",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_UserId",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Pets");

            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "Users",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PetId",
                table: "Users",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pets_PetId",
                table: "Users",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
