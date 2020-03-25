using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class MigrationInicial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PetName",
                table: "Pets",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 24, 22, 13, 55, 251, DateTimeKind.Local).AddTicks(6056), new DateTime(2020, 3, 24, 22, 13, 55, 251, DateTimeKind.Local).AddTicks(6065) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 24, 22, 13, 55, 250, DateTimeKind.Local).AddTicks(1540), new DateTime(2020, 3, 24, 22, 13, 55, 250, DateTimeKind.Local).AddTicks(1541) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 24, 22, 13, 55, 250, DateTimeKind.Local).AddTicks(1514), new DateTime(2020, 3, 24, 22, 13, 55, 250, DateTimeKind.Local).AddTicks(1522) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 24, 22, 13, 55, 249, DateTimeKind.Local).AddTicks(1077), new DateTime(2020, 3, 24, 22, 13, 55, 250, DateTimeKind.Local).AddTicks(767) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "PetName",
                table: "Pets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 24, 21, 5, 3, 784, DateTimeKind.Local).AddTicks(2434), new DateTime(2020, 3, 24, 21, 5, 3, 784, DateTimeKind.Local).AddTicks(2442) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8948), new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8949) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8921), new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8929) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 24, 21, 5, 3, 781, DateTimeKind.Local).AddTicks(8732), new DateTime(2020, 3, 24, 21, 5, 3, 782, DateTimeKind.Local).AddTicks(8254) });
        }
    }
}
