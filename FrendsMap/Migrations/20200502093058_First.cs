using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrendsMap.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NickName = table.Column<string>(nullable: false),
                    Gmail = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    IDUserOfGoogle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfPlace",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfPlace", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Geolocation = table.Column<string>(nullable: false),
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsAccepted = table.Column<bool>(nullable: false, defaultValue: true),
                    TypeOfPlaceId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Place_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Place_TypeOfPlace_TypeOfPlaceId",
                        column: x => x.TypeOfPlaceId,
                        principalTable: "TypeOfPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RankingOfFriend",
                columns: table => new
                {
                    TypeOfPlaceId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false),
                    Mark = table.Column<int>(nullable: false),
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankingOfFriend", x => new { x.TypeOfPlaceId, x.PersonId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_RankingOfFriend_Person_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RankingOfFriend_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RankingOfFriend_TypeOfPlace_TypeOfPlaceId",
                        column: x => x.TypeOfPlaceId,
                        principalTable: "TypeOfPlace",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: false),
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsAccepted = table.Column<bool>(nullable: false, defaultValue: true),
                    PlaceId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(nullable: false),
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IsAccepted = table.Column<bool>(nullable: false, defaultValue: true),
                    PlaceId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photo_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ranking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(nullable: false),
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false, defaultValueSql: "GETUTCDATE()"),
                    PlaceId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranking_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranking_Place_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Place",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PersonId",
                table: "Comment",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PlaceId",
                table: "Comment",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PersonId",
                table: "Photo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_PlaceId",
                table: "Photo",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_PersonId",
                table: "Place",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Place_TypeOfPlaceId",
                table: "Place",
                column: "TypeOfPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_PersonId",
                table: "Ranking",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranking_PlaceId",
                table: "Ranking",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_RankingOfFriend_FriendId",
                table: "RankingOfFriend",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_RankingOfFriend_PersonId",
                table: "RankingOfFriend",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Ranking");

            migrationBuilder.DropTable(
                name: "RankingOfFriend");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "TypeOfPlace");
        }
    }
}
