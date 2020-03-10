using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace CyberPet.Api.Migrations
{
    public partial class AddUserDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password", "PetId" },
                values: new object[,]
                {
                    { new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), "ghmeyer0@gmail.com", "Gabriel Helko Meyer", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", null },
                    { new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"), "gustavoreinertbsi@gmail.com", "Gustavo Reinert", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", null },
                    { new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"), "rrschiavo@gmail.com", "Renato Schiavo", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"));
        }
    }
}
