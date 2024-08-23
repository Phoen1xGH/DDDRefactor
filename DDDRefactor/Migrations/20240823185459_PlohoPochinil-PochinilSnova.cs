using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDRefactor.Migrations
{
    /// <inheritdoc />
    public partial class PlohoPochinilPochinilSnova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Notifications_CustomNotificationId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_CustomNotificationId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "CustomNotificationId",
                table: "Contact");

            migrationBuilder.CreateTable(
                name: "ContactCustomNotification",
                columns: table => new
                {
                    CustomNotificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmailsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCustomNotification", x => new { x.CustomNotificationId, x.EmailsId });
                    table.ForeignKey(
                        name: "FK_ContactCustomNotification_Contact_EmailsId",
                        column: x => x.EmailsId,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactCustomNotification_Notifications_CustomNotificationId",
                        column: x => x.CustomNotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactCustomNotification_EmailsId",
                table: "ContactCustomNotification",
                column: "EmailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCustomNotification");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomNotificationId",
                table: "Contact",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CustomNotificationId",
                table: "Contact",
                column: "CustomNotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Notifications_CustomNotificationId",
                table: "Contact",
                column: "CustomNotificationId",
                principalTable: "Notifications",
                principalColumn: "Id");
        }
    }
}
