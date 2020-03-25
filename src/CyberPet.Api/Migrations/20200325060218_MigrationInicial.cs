using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

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
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Email = table.Column<string>(maxLength: 128, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false)
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
                    PetName = table.Column<string>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Bowl",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    PetId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bowl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bowl_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    PetId = table.Column<Guid>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    DaysOfWeek = table.Column<List<DayOfWeek>>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "Password", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), new DateTime(2020, 3, 25, 3, 2, 17, 889, DateTimeKind.Local).AddTicks(7850), "ghmeyer0@gmail.com", "Gabriel Helko Meyer", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", new DateTime(2020, 3, 25, 3, 2, 17, 890, DateTimeKind.Local).AddTicks(9624) },
                    { new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"), new DateTime(2020, 3, 25, 3, 2, 17, 891, DateTimeKind.Local).AddTicks(587), "gustavoreinertbsi@gmail.com", "Gustavo Reinert", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", new DateTime(2020, 3, 25, 3, 2, 17, 891, DateTimeKind.Local).AddTicks(601) },
                    { new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"), new DateTime(2020, 3, 25, 3, 2, 17, 891, DateTimeKind.Local).AddTicks(626), "rrschiavo@gmail.com", "Renato Schiavo", "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", new DateTime(2020, 3, 25, 3, 2, 17, 891, DateTimeKind.Local).AddTicks(627) }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "CreateAt", "PetName", "UpdateAt", "UserId" },
                values: new object[] { new Guid("56714b09-8040-4af5-a984-c21e69fadb42"), new DateTime(2020, 3, 25, 3, 2, 17, 892, DateTimeKind.Local).AddTicks(7254), "Woody", new DateTime(2020, 3, 25, 3, 2, 17, 892, DateTimeKind.Local).AddTicks(7264), new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c") });

            migrationBuilder.CreateIndex(
                name: "IX_Bowl_PetId",
                table: "Bowl",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_PetId",
                table: "Schedules",
                column: "PetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bowl");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
