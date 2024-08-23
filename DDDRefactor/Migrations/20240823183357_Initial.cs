using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDDRefactor.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agreement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agreement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LegalPeople",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TIN = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    MailingAddress = table.Column<string>(type: "text", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalPeople", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestNumber = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OrderStatus = table.Column<int>(type: "integer", nullable: false),
                    RequestType = table.Column<int>(type: "integer", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    DateReceiving = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateMailing = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateAnswering = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateSending = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Rights = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotesMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotesMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotesMessage_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RequestMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: false),
                    LegalPersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsNotify = table.Column<bool>(type: "boolean", nullable: false),
                    IsParticipate = table.Column<bool>(type: "boolean", nullable: false),
                    DateSend = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AgreementId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecificationId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestMembers_Agreement_AgreementId",
                        column: x => x.AgreementId,
                        principalTable: "Agreement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestMembers_LegalPeople_LegalPersonId",
                        column: x => x.LegalPersonId,
                        principalTable: "LegalPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestMembers_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestId = table.Column<Guid>(type: "uuid", nullable: true),
                    RequestMemberId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_RequestMembers_RequestMemberId",
                        column: x => x.RequestMemberId,
                        principalTable: "RequestMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attachment_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Periodicity = table.Column<int>(type: "integer", nullable: false),
                    SendingTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    RequestMemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_RequestMembers_RequestMemberId",
                        column: x => x.RequestMemberId,
                        principalTable: "RequestMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRequestMember",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestMembersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRequestMember", x => new { x.ProductsId, x.RequestMembersId });
                    table.ForeignKey(
                        name: "FK_ProductRequestMember_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductRequestMember_RequestMembers_RequestMembersId",
                        column: x => x.RequestMembersId,
                        principalTable: "RequestMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecificationNumber = table.Column<string>(type: "text", nullable: false),
                    SpecificationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RequestMemberId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specification_RequestMembers_RequestMemberId",
                        column: x => x.RequestMemberId,
                        principalTable: "RequestMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsNotify = table.Column<bool>(type: "boolean", nullable: false),
                    CustomNotificationId = table.Column<Guid>(type: "uuid", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OnDelete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_LegalPeople_PersonId",
                        column: x => x.PersonId,
                        principalTable: "LegalPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_Notifications_CustomNotificationId",
                        column: x => x.CustomNotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_RequestId",
                table: "Attachment",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_RequestMemberId",
                table: "Attachment",
                column: "RequestMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CustomNotificationId",
                table: "Contact",
                column: "CustomNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_PersonId",
                table: "Contact",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_NotesMessage_RequestId",
                table: "NotesMessage",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RequestMemberId",
                table: "Notifications",
                column: "RequestMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRequestMember_RequestMembersId",
                table: "ProductRequestMember",
                column: "RequestMembersId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMembers_AgreementId",
                table: "RequestMembers",
                column: "AgreementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RequestMembers_LegalPersonId",
                table: "RequestMembers",
                column: "LegalPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestMembers_RequestId",
                table: "RequestMembers",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Specification_RequestMemberId",
                table: "Specification",
                column: "RequestMemberId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "NotesMessage");

            migrationBuilder.DropTable(
                name: "ProductRequestMember");

            migrationBuilder.DropTable(
                name: "Specification");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RequestMembers");

            migrationBuilder.DropTable(
                name: "Agreement");

            migrationBuilder.DropTable(
                name: "LegalPeople");

            migrationBuilder.DropTable(
                name: "Requests");
        }
    }
}
