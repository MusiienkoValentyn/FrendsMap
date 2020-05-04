using Microsoft.EntityFrameworkCore.Migrations;

namespace FrendsMap.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Place",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Person",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IDUserOfGoogle",
                table: "Person",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Person_IDUserOfGoogle",
                table: "Person",
                column: "IDUserOfGoogle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_NickName",
                table: "Person",
                column: "NickName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Person_IDUserOfGoogle",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_NickName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Place");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "Person",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "NickName",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "IDUserOfGoogle",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
