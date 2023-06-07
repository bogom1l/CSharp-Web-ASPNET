using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class probvamMigraciq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3cb5dbe-c13d-4d26-b901-123957efce7f");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "feb67350-9cb5-47d2-befb-25fa6395f360", 0, "ac84c742-739d-4e45-a251-0caf4712a805", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAENpkJfKCrQQv3ikqR9NjsOk6/uAiwLPKUE4bVmM8j4BMVDj1QsvXt9JxEoU1XBtZxw==", null, false, "d0a19b1c-5675-4aae-bece-e01a780acd01", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 11, 19, 18, 22, 58, 18, DateTimeKind.Local).AddTicks(2915), "feb67350-9cb5-47d2-befb-25fa6395f360" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 28, 18, 22, 58, 18, DateTimeKind.Local).AddTicks(2951), "feb67350-9cb5-47d2-befb-25fa6395f360" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 13, 18, 22, 58, 18, DateTimeKind.Local).AddTicks(2954), "feb67350-9cb5-47d2-befb-25fa6395f360" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 7, 18, 22, 58, 18, DateTimeKind.Local).AddTicks(2957), "feb67350-9cb5-47d2-befb-25fa6395f360" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "feb67350-9cb5-47d2-befb-25fa6395f360");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f3cb5dbe-c13d-4d26-b901-123957efce7f", 0, "63ebb45e-782c-4ba5-915c-0928e0ba82a3", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEFzRjWeeimGRuLJ+JJVgqcgbeWkg/WE6c2Q2J0NFBW5Rx7lbT5lwBkKrIV/XN3f3xg==", null, false, "dae7646e-9d16-49b4-a703-8512867cbf9c", false, "test@softuni.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2022, 11, 19, 16, 0, 13, 362, DateTimeKind.Local).AddTicks(4224), "f3cb5dbe-c13d-4d26-b901-123957efce7f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 28, 16, 0, 13, 362, DateTimeKind.Local).AddTicks(4255), "f3cb5dbe-c13d-4d26-b901-123957efce7f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 13, 16, 0, 13, 362, DateTimeKind.Local).AddTicks(4259), "f3cb5dbe-c13d-4d26-b901-123957efce7f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 5, 7, 16, 0, 13, 362, DateTimeKind.Local).AddTicks(4261), "f3cb5dbe-c13d-4d26-b901-123957efce7f" });
        }
    }
}
