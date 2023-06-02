using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumApp.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("6a9f3dae-eff4-4ced-b163-64cdf479bfc1"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("8ca45619-a167-4832-9294-58742ff915ec"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("90772b51-5cb0-4444-b539-4db2a6e81a77"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("13bc53d4-8328-482f-9b77-24216d66caf4"), "Second Content - evala mujki", "My second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("428578e1-6f72-4e66-9b52-d10bc50116a1"), "Third Content, mn sum gotin btw", "My third post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("48c216c5-bf52-4a4c-9eaf-20ff923d50e7"), "First Content: wagmi", "My first post" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("13bc53d4-8328-482f-9b77-24216d66caf4"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("428578e1-6f72-4e66-9b52-d10bc50116a1"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("48c216c5-bf52-4a4c-9eaf-20ff923d50e7"));

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("6a9f3dae-eff4-4ced-b163-64cdf479bfc1"), "First Content: wagmi", "My first post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("8ca45619-a167-4832-9294-58742ff915ec"), "Second Content - evala mujki", "My second post" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { new Guid("90772b51-5cb0-4444-b539-4db2a6e81a77"), "Third Content, mn sum gotin btw", "My third post" });
        }
    }
}
