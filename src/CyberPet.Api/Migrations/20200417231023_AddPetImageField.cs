using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class AddPetImageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PetImage",
                table: "Pets",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 17, 20, 10, 23, 118, DateTimeKind.Local).AddTicks(8270), new DateTime(2020, 4, 17, 20, 10, 23, 118, DateTimeKind.Local).AddTicks(8295) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local).AddTicks(9283), new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local).AddTicks(9285) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local).AddTicks(9239), new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local).AddTicks(9252) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 17, 20, 10, 23, 113, DateTimeKind.Local).AddTicks(512), new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local).AddTicks(7249) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PetImage",
                table: "Pets");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 26, 18, 16, 50, 435, DateTimeKind.Local).AddTicks(1536), new DateTime(2020, 3, 26, 18, 16, 50, 435, DateTimeKind.Local).AddTicks(1543) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 26, 18, 16, 50, 433, DateTimeKind.Local).AddTicks(9210), new DateTime(2020, 3, 26, 18, 16, 50, 433, DateTimeKind.Local).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 26, 18, 16, 50, 433, DateTimeKind.Local).AddTicks(9121), new DateTime(2020, 3, 26, 18, 16, 50, 433, DateTimeKind.Local).AddTicks(9131) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 26, 18, 16, 50, 433, DateTimeKind.Local).AddTicks(446), new DateTime(2020, 3, 26, 18, 16, 50, 433, DateTimeKind.Local).AddTicks(8442) });
        }
    }
}
