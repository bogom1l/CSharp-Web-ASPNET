using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Data.Migrations
{
    public partial class qwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_Contacts_ContactId",
                table: "ApplicationUserContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserContact",
                table: "ApplicationUserContact");

            migrationBuilder.RenameTable(
                name: "ApplicationUserContact",
                newName: "ApplicationUserContacts");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserContact_ContactId",
                table: "ApplicationUserContacts",
                newName: "IX_ApplicationUserContacts_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserContacts",
                table: "ApplicationUserContacts",
                columns: new[] { "ApplicationUserId", "ContactId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContacts_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContacts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContacts_Contacts_ContactId",
                table: "ApplicationUserContacts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContacts_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContacts_Contacts_ContactId",
                table: "ApplicationUserContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserContacts",
                table: "ApplicationUserContacts");

            migrationBuilder.RenameTable(
                name: "ApplicationUserContacts",
                newName: "ApplicationUserContact");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserContacts_ContactId",
                table: "ApplicationUserContact",
                newName: "IX_ApplicationUserContact_ContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserContact",
                table: "ApplicationUserContact",
                columns: new[] { "ApplicationUserId", "ContactId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContact",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_Contacts_ContactId",
                table: "ApplicationUserContact",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
