using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f3cb5dbe-c13d-4d26-b901-123957efce7f", 0, "63ebb45e-782c-4ba5-915c-0928e0ba82a3", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEFzRjWeeimGRuLJ+JJVgqcgbeWkg/WE6c2Q2J0NFBW5Rx7lbT5lwBkKrIV/XN3f3xg==", null, false, "dae7646e-9d16-49b4-a703-8512867cbf9c", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 19, 16, 0, 13, 362, DateTimeKind.Local).AddTicks(4224), "Description1 aaaaaaaaaaaa", "f3cb5dbe-c13d-4d26-b901-123957efce7f", "Title1", null },
                    { 2, 1, new DateTime(2023, 5, 28, 16, 0, 13, 362, DateTimeKind.Local).AddTicks(4255), "Description2 bbbbbbbbbbb", "f3cb5dbe-c13d-4d26-b901-123957efce7f", "Title2", null },
                    { 3, 2, new DateTime(2023, 5, 13, 16, 0, 13, 362, DateTimeKind.Local).AddTicks(4259), "Description3 cccccccccccc", "f3cb5dbe-c13d-4d26-b901-123957efce7f", "Title3", null },
                    { 4, 3, new DateTime(2023, 5, 7, 16, 0, 13, 362, DateTimeKind.Local).AddTicks(4261), "Description4 zzzzzzzz", "f3cb5dbe-c13d-4d26-b901-123957efce7f", "Title4", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3cb5dbe-c13d-4d26-b901-123957efce7f");
        }
    }
}
