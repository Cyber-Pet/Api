using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class MigrationInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    PetName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), new DateTime(2020, 3, 24, 21, 5, 3, 781, DateTimeKind.Local).AddTicks(8732), "ghmeyer0@gmail.com", "Gabriel Helko Meyer", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8254) },
                    { new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"), new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8921), "gustavoreinertbsi@gmail.com", "Gustavo Reinert", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8929) },
                    { new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"), new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8948), "rrschiavo@gmail.com", "Renato Schiavo", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8949) }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "CreateAt", "PetName", "UpdateAt", "UserId" },
                values: new object[] { new Guid("56714b09-8040-4af5-a984-c21e69fadb42"), new DateTime(2020, 3, 24, 21, 5, 3, 784, DateTimeKind.Local).AddTicks(2434), "Woody", new DateTime(2020, 3, 24, 21, 5, 3, 784, DateTimeKind.Local).AddTicks(2442), new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c") });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
