using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrendsMap.Migrations
{
    public partial class A_Few_field_Added4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Place",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeOfAdding",
                value: new DateTime(2020, 4, 2, 23, 48, 52, 825, DateTimeKind.Local).AddTicks(3895));

            migrationBuilder.UpdateData(
                table: "Place",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeOfAdding",
                value: new DateTime(2020, 4, 2, 23, 48, 52, 825, DateTimeKind.Local).AddTicks(5005));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
