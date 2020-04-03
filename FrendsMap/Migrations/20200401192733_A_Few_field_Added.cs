using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FrendsMap.Migrations
{
    public partial class A_Few_field_Added : Migration
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
                    Photo = table.Column<string>(nullable: true),
                    Gmail = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
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
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false),
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<int>(nullable: false),
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false),
                    TypeOfPlaceId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    FriendId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankingOfFriend", x => x.Id);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(nullable: false),
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false),
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
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false),
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
                    DateTimeOfAdding = table.Column<DateTime>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Gmail", "NickName", "Photo", "Rating" },
                values: new object[,]
                {
                    { 1, null, "Pogrib", null, 0 },
                    { 2, null, "Meska", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "TypeOfPlace",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Park" },
                    { 2, "Stadion" }
                });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "DateTimeOfAdding", "Geolocation", "Name", "PersonId", "TypeOfPlaceId" },
                values: new object[] { 2, new DateTime(2020, 4, 1, 22, 27, 33, 163, DateTimeKind.Local).AddTicks(3944), "124/24.13", "Hata", 2, 1 });

            migrationBuilder.InsertData(
                table: "Place",
                columns: new[] { "Id", "DateTimeOfAdding", "Geolocation", "Name", "PersonId", "TypeOfPlaceId" },
                values: new object[] { 1, new DateTime(2020, 4, 1, 22, 27, 33, 163, DateTimeKind.Local).AddTicks(3102), "124/24.12", "Gurtogitok 7", 1, 2 });

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

            migrationBuilder.CreateIndex(
                name: "IX_RankingOfFriend_TypeOfPlaceId",
                table: "RankingOfFriend",
                column: "TypeOfPlaceId");
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
