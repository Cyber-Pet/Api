using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CyberPet.Api.Migrations
{
    public partial class AddEnul : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:day_of_week", "sunday,monday,tuesday,wednesday,thursday,friday,saturday");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:day_of_week", "sunday,monday,tuesday,wednesday,thursday,friday,saturday");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("56714b09-8040-4af5-a984-c21e69fadb42"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 3, 2, 17, 892, DateTimeKind.Local).AddTicks(7254), new DateTime(2020, 3, 25, 3, 2, 17, 892, DateTimeKind.Local).AddTicks(7264) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3e3a3c48-3939-49d3-8ada-81936239a609"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 3, 2, 17, 891, DateTimeKind.Local).AddTicks(626), new DateTime(2020, 3, 25, 3, 2, 17, 891, DateTimeKind.Local).AddTicks(627) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("62d41afc-2e81-4b5f-9efe-be14c26d8958"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 3, 2, 17, 891, DateTimeKind.Local).AddTicks(587), new DateTime(2020, 3, 25, 3, 2, 17, 891, DateTimeKind.Local).AddTicks(601) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"),
                columns: new[] { "CreateAt", "UpdateAt" },
                values: new object[] { new DateTime(2020, 3, 25, 3, 2, 17, 889, DateTimeKind.Local).AddTicks(7850), new DateTime(2020, 3, 25, 3, 2, 17, 890, DateTimeKind.Local).AddTicks(9624) });
        }
    }
}
