using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 20, 14, 42, 17, 443, DateTimeKind.Local).AddTicks(2820), new DateTime(2020, 4, 20, 14, 42, 17, 444, DateTimeKind.Local).AddTicks(135) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "Role", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), "user", new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "Role", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), "user", new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "Role", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), "admin", new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 19, 21, 24, 34, 82, DateTimeKind.Local).AddTicks(1117), new DateTime(2020, 4, 19, 21, 24, 34, 82, DateTimeKind.Local).AddTicks(1124) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(6674), new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(6675) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(6641), new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(6654) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 19, 21, 24, 34, 79, DateTimeKind.Local).AddTicks(7699), new DateTime(2020, 4, 19, 21, 24, 34, 80, DateTimeKind.Local).AddTicks(5971) });
        }
    }
}
