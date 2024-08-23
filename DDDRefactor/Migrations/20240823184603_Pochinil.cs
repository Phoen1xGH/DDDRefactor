using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDRefactor.Migrations
{
    /// <inheritdoc />
    public partial class Pochinil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Requests_RequestId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestMembers_Agreement_AgreementId",
                table: "RequestMembers");

            migrationBuilder.DropIndex(
                name: "IX_RequestMembers_AgreementId",
                table: "RequestMembers");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndProduction",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FactOfDeliveryDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FullPaymentDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "Prepayment",
                table: "Products",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PrepaymentaDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProductInfo",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductSheme",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SendingDate",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartProduction",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "СurrencyType",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "NotesMessage",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "MessageDate",
                table: "NotesMessage",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "NotesMessage",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestId",
                table: "Attachment",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Attachment",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Attachment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AgreementDate",
                table: "Agreement",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AgreementNumber",
                table: "Agreement",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "RequestMemberId",
                table: "Agreement",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_NotesMessage_UserId",
                table: "NotesMessage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Agreement_RequestMemberId",
                table: "Agreement",
                column: "RequestMemberId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agreement_RequestMembers_RequestMemberId",
                table: "Agreement",
                column: "RequestMemberId",
                principalTable: "RequestMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Requests_RequestId",
                table: "Attachment",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NotesMessage_Users_UserId",
                table: "NotesMessage",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agreement_RequestMembers_RequestMemberId",
                table: "Agreement");

            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Requests_RequestId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_NotesMessage_Users_UserId",
                table: "NotesMessage");

            migrationBuilder.DropIndex(
                name: "IX_NotesMessage_UserId",
                table: "NotesMessage");

            migrationBuilder.DropIndex(
                name: "IX_Agreement_RequestMemberId",
                table: "Agreement");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EndProduction",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FactOfDeliveryDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FullPaymentDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Prepayment",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PrepaymentaDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductInfo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductSheme",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SendingDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StartProduction",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "СurrencyType",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "NotesMessage");

            migrationBuilder.DropColumn(
                name: "MessageDate",
                table: "NotesMessage");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NotesMessage");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "AgreementDate",
                table: "Agreement");

            migrationBuilder.DropColumn(
                name: "AgreementNumber",
                table: "Agreement");

            migrationBuilder.DropColumn(
                name: "RequestMemberId",
                table: "Agreement");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestId",
                table: "Attachment",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMembers_AgreementId",
                table: "RequestMembers",
                column: "AgreementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Requests_RequestId",
                table: "Attachment",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestMembers_Agreement_AgreementId",
                table: "RequestMembers",
                column: "AgreementId",
                principalTable: "Agreement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
