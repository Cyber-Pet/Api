using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class ChangeDefaultPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                column: "Password",
                value: "590a70c919b118d0dbd2e9eb8dd2e76b1bf43fcd41018f02c119f79d22a6d5f3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                column: "Password",
                value: "590a70c919b118d0dbd2e9eb8dd2e76b1bf43fcd41018f02c119f79d22a6d5f3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                column: "Password",
                value: "590a70c919b118d0dbd2e9eb8dd2e76b1bf43fcd41018f02c119f79d22a6d5f3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                column: "Password",
                value: "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                column: "Password",
                value: "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                column: "Password",
                value: "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600");
        }
    }
}
