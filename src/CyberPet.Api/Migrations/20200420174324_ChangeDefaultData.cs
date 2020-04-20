using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class ChangeDefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 20, 14, 42, 17, 444, DateTimeKind.Local), new DateTime(2020, 4, 20, 14, 42, 17, 444, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 4, 20, 14, 42, 17, 443, DateTimeKind.Local).AddTicks(2820), new DateTime(2020, 4, 20, 14, 42, 17, 444, DateTimeKind.Local).AddTicks(135) });
        }
    }
}
