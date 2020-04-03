using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrendsMap.Migrations
{
    public partial class A_Few_field_Added3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Place",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeOfAdding",
                value: new DateTime(2020, 4, 2, 23, 45, 23, 663, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "Place",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeOfAdding",
                value: new DateTime(2020, 4, 2, 23, 45, 23, 663, DateTimeKind.Local).AddTicks(6693));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Place",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeOfAdding",
                value: new DateTime(2020, 4, 2, 12, 47, 37, 807, DateTimeKind.Local).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "Place",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeOfAdding",
                value: new DateTime(2020, 4, 2, 12, 47, 37, 807, DateTimeKind.Local).AddTicks(6691));
        }
    }
}
