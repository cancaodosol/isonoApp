﻿// <auto-generated />
using System;
using IssWebRazorApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IssWebRazorApp.Migrations
{
    [DbContext(typeof(IssWebRazorAppContext))]
    [Migration("20200408124333_add20200408")]
    partial class add20200408
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("IssWebRazorApp.Data.CategoryData", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Session")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("IssWebRazorApp.Data.PlaybookData", b =>
                {
                    b.Property<int>("PlaybookSystemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<string>("Context")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefenceFormationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IntroduceStatus")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LastUpdateUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OffenseFormationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PlayCallName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayDesignUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayFullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PlayShortName")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlaybookId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlaybookSystemId");

                    b.ToTable("Playbooks");
                });

            modelBuilder.Entity("IssWebRazorApp.Data.PositionData", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FullName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PositionType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ShortName")
                        .HasColumnType("TEXT");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("IssWebRazorApp.Data.ScheduleData", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Context")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Place")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ScheduleId");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("IssWebRazorApp.Data.UserData", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Education")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstNameKanji")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstNameRoman")
                        .HasColumnType("TEXT");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<string>("LastNameKanji")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastNameRoman")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginPassword")
                        .HasColumnType("TEXT");

                    b.Property<int>("PositionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SystemRole")
                        .HasColumnType("TEXT");

                    b.Property<int>("UniformNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserType")
                        .HasColumnType("TEXT");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("UserId");

                    b.HasIndex("PositionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IssWebRazorApp.Data.UserData", b =>
                {
                    b.HasOne("IssWebRazorApp.Data.PositionData", "PositionData")
                        .WithMany("UserDatas")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
