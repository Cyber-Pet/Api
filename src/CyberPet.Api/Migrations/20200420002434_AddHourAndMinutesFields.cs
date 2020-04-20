using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class AddHourAndMinutesFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "Schedules");

            migrationBuilder.AddColumn<int>(
                name: "Hour",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Minutes",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hour",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Minutes",
                table: "Schedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "Schedules",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
