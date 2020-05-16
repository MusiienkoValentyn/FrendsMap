using Microsoft.EntityFrameworkCore.Migrations;

namespace FrendsMap.Migrations
{
    public partial class IsInGoogle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsInGoogle",
                table: "Place",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsInGoogle",
                table: "Place");
        }
    }
}
