using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class RemovidoEnul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaysOfWeek",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 18, 15, 32, 98, DateTimeKind.Local).AddTicks(4637), new DateTime(2020, 3, 25, 18, 15, 32, 98, DateTimeKind.Local).AddTicks(4645) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 18, 15, 32, 96, DateTimeKind.Local).AddTicks(7424), new DateTime(2020, 3, 25, 18, 15, 32, 96, DateTimeKind.Local).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 18, 15, 32, 96, DateTimeKind.Local).AddTicks(7371), new DateTime(2020, 3, 25, 18, 15, 32, 96, DateTimeKind.Local).AddTicks(7393) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 18, 15, 32, 95, DateTimeKind.Local).AddTicks(591), new DateTime(2020, 3, 25, 18, 15, 32, 96, DateTimeKind.Local).AddTicks(6186) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int[]>(
                name: "DaysOfWeek",
                table: "Schedules",
                type: "integer[]",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 18, 3, 56, 218, DateTimeKind.Local).AddTicks(8437), new DateTime(2020, 3, 25, 18, 3, 56, 218, DateTimeKind.Local).AddTicks(8444) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 18, 3, 56, 217, DateTimeKind.Local).AddTicks(5828), new DateTime(2020, 3, 25, 18, 3, 56, 217, DateTimeKind.Local).AddTicks(5829) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 18, 3, 56, 217, DateTimeKind.Local).AddTicks(5795), new DateTime(2020, 3, 25, 18, 3, 56, 217, DateTimeKind.Local).AddTicks(5805) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 18, 3, 56, 216, DateTimeKind.Local).AddTicks(7351), new DateTime(2020, 3, 25, 18, 3, 56, 217, DateTimeKind.Local).AddTicks(5060) });
        }
    }
}
