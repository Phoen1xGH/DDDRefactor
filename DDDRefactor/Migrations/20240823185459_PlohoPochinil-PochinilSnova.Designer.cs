﻿// <auto-generated />
using System;
using System.Collections.Generic;
using DDDRefactor.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DDDRefactor.Migrations
{
    [DbContext(typeof(SIZADBContext))]
    [Migration("20240823185459_PlohoPochinil-PochinilSnova")]
    partial class PlohoPochinilPochinilSnova
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ContactCustomNotification", b =>
                {
                    b.Property<Guid>("CustomNotificationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("EmailsId")
                        .HasColumnType("uuid");

                    b.HasKey("CustomNotificationId", "EmailsId");

                    b.HasIndex("EmailsId");

                    b.ToTable("ContactCustomNotification");
                });

            modelBuilder.Entity("DDDRefactor.Models.Agreement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AgreementDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("AgreementNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RequestMemberId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RequestMemberId")
                        .IsUnique();

                    b.ToTable("Agreement");
                });

            modelBuilder.Entity("DDDRefactor.Models.Attachment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RequestMemberId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("RequestMemberId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("DDDRefactor.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsNotify")
                        .HasColumnType("boolean");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("Email", "DDDRefactor.Models.Contact.Email#Email", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("EmailAddress");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "DDDRefactor.Models.Contact.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");
                        });

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("DDDRefactor.Models.CustomNotification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<int>("Periodicity")
                        .HasColumnType("integer");

                    b.Property<Guid>("RequestMemberId")
                        .HasColumnType("uuid");

                    b.Property<TimeOnly>("SendingTime")
                        .HasColumnType("time without time zone");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RequestMemberId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("DDDRefactor.Models.LegalPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MailingAddress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("TIN")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("LegalPeople");
                });

            modelBuilder.Entity("DDDRefactor.Models.NotesMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("NotesMessage");
                });

            modelBuilder.Entity("DDDRefactor.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndProduction")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FactOfDeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FullPaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<byte>("Prepayment")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("PrepaymentaDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("ProductInfo")
                        .HasColumnType("text");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProductSheme")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("SendingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("StartProduction")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("СurrencyType")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DDDRefactor.Models.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateAnswering")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateMailing")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateReceiving")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateSending")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Info")
                        .HasColumnType("text");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer");

                    b.Property<int>("RequestNumber")
                        .HasColumnType("integer");

                    b.Property<int>("RequestType")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("DDDRefactor.Models.RequestMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AgreementId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateSend")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsNotify")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsParticipate")
                        .HasColumnType("boolean");

                    b.Property<Guid>("LegalPersonId")
                        .HasColumnType("uuid");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RequestId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpecificationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("LegalPersonId");

                    b.HasIndex("RequestId");

                    b.ToTable("RequestMembers");
                });

            modelBuilder.Entity("DDDRefactor.Models.Specification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RequestMemberId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("SpecificationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("SpecificationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("RequestMemberId")
                        .IsUnique();

                    b.ToTable("Specification");
                });

            modelBuilder.Entity("DDDRefactor.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("OnDelete")
                        .HasColumnType("boolean");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ComplexProperty<Dictionary<string, object>>("AccessRights", "DDDRefactor.Models.User.AccessRights#UserPermissions", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Rights")
                                .HasColumnType("integer")
                                .HasColumnName("Rights");
                        });

                    b.ComplexProperty<Dictionary<string, object>>("PhoneNumber", "DDDRefactor.Models.User.PhoneNumber#PhoneNumber", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("PhoneNumber");
                        });

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProductRequestMember", b =>
                {
                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RequestMembersId")
                        .HasColumnType("uuid");

                    b.HasKey("ProductsId", "RequestMembersId");

                    b.HasIndex("RequestMembersId");

                    b.ToTable("ProductRequestMember");
                });

            modelBuilder.Entity("ContactCustomNotification", b =>
                {
                    b.HasOne("DDDRefactor.Models.CustomNotification", null)
                        .WithMany()
                        .HasForeignKey("CustomNotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDDRefactor.Models.Contact", null)
                        .WithMany()
                        .HasForeignKey("EmailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DDDRefactor.Models.Agreement", b =>
                {
                    b.HasOne("DDDRefactor.Models.RequestMember", "RequestMember")
                        .WithOne("Agreement")
                        .HasForeignKey("DDDRefactor.Models.Agreement", "RequestMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestMember");
                });

            modelBuilder.Entity("DDDRefactor.Models.Attachment", b =>
                {
                    b.HasOne("DDDRefactor.Models.Request", "Request")
                        .WithMany("Attachments")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDDRefactor.Models.RequestMember", null)
                        .WithMany("Attachments")
                        .HasForeignKey("RequestMemberId");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("DDDRefactor.Models.Contact", b =>
                {
                    b.HasOne("DDDRefactor.Models.LegalPerson", "Person")
                        .WithMany("Contacts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DDDRefactor.Models.CustomNotification", b =>
                {
                    b.HasOne("DDDRefactor.Models.RequestMember", "RequestMember")
                        .WithMany()
                        .HasForeignKey("RequestMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestMember");
                });

            modelBuilder.Entity("DDDRefactor.Models.NotesMessage", b =>
                {
                    b.HasOne("DDDRefactor.Models.Request", null)
                        .WithMany("NotesMessage")
                        .HasForeignKey("RequestId");

                    b.HasOne("DDDRefactor.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DDDRefactor.Models.RequestMember", b =>
                {
                    b.HasOne("DDDRefactor.Models.LegalPerson", "LegalPerson")
                        .WithMany()
                        .HasForeignKey("LegalPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDDRefactor.Models.Request", "Request")
                        .WithMany("RequestMembers")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LegalPerson");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("DDDRefactor.Models.Specification", b =>
                {
                    b.HasOne("DDDRefactor.Models.RequestMember", "RequestMember")
                        .WithOne("Specification")
                        .HasForeignKey("DDDRefactor.Models.Specification", "RequestMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestMember");
                });

            modelBuilder.Entity("ProductRequestMember", b =>
                {
                    b.HasOne("DDDRefactor.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDDRefactor.Models.RequestMember", null)
                        .WithMany()
                        .HasForeignKey("RequestMembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DDDRefactor.Models.LegalPerson", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("DDDRefactor.Models.Request", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("NotesMessage");

                    b.Navigation("RequestMembers");
                });

            modelBuilder.Entity("DDDRefactor.Models.RequestMember", b =>
                {
                    b.Navigation("Agreement")
                        .IsRequired();

                    b.Navigation("Attachments");

                    b.Navigation("Specification")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
