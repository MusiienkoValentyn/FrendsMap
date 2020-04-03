using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrendsMap.Migrations
{
    public partial class A_Few_field_Added2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Place",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeOfAdding",
                value: new DateTime(2020, 4, 2, 12, 45, 15, 139, DateTimeKind.Local).AddTicks(581));

            migrationBuilder.UpdateData(
                table: "Place",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTimeOfAdding",
                value: new DateTime(2020, 4, 2, 12, 45, 15, 139, DateTimeKind.Local).AddTicks(2942));
        }
    }
}
