﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(MainSiteContext))]
    [Migration("20220706035248_AddedDateToOverview")]
    partial class AddedDateToOverview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infrastructure.Models.Bio", b =>
                {
                    b.Property<Guid>("BioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("longtext");

                    b.HasKey("BioId");

                    b.ToTable("Bios");
                });

            modelBuilder.Entity("Infrastructure.Models.BioDetail", b =>
                {
                    b.Property<Guid>("BioDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BioId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BioSectionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoUrl")
                        .HasColumnType("longtext");

                    b.HasKey("BioDetailId");

                    b.ToTable("BioDetails");
                });

            modelBuilder.Entity("Infrastructure.Models.BioSection", b =>
                {
                    b.Property<Guid>("BioSectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("BioSectionId");

                    b.ToTable("BioSections");
                });

            modelBuilder.Entity("Infrastructure.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("HeaderText")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid>("ResumeId")
                        .HasColumnType("char(36)");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Infrastructure.Models.File", b =>
                {
                    b.Property<Guid>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<byte[]>("FileData")
                        .HasColumnType("longblob");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext");

                    b.HasKey("FileId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Infrastructure.Models.LinkGroup", b =>
                {
                    b.Property<Guid>("LinkGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("GroupName")
                        .HasColumnType("longtext");

                    b.HasKey("LinkGroupId");

                    b.ToTable("LinkGroups");
                });

            modelBuilder.Entity("Infrastructure.Models.Objective", b =>
                {
                    b.Property<Guid>("ObjectiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("ObjectiveId");

                    b.ToTable("Objectives");
                });

            modelBuilder.Entity("Infrastructure.Models.ObjectiveDetail", b =>
                {
                    b.Property<Guid>("ObjectiveDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("LinkUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<Guid>("ObjectiveId")
                        .HasColumnType("char(36)");

                    b.HasKey("ObjectiveDetailId");

                    b.ToTable("ObjectivesDetails");
                });

            modelBuilder.Entity("Infrastructure.Models.Overview", b =>
                {
                    b.Property<Guid>("OverviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("BodyHtml")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("HeaderText")
                        .HasColumnType("longtext");

                    b.HasKey("OverviewId");

                    b.ToTable("Overviews");
                });

            modelBuilder.Entity("Infrastructure.Models.PortfolioLink", b =>
                {
                    b.Property<Guid>("PortfolioLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Link")
                        .HasColumnType("longtext");

                    b.Property<Guid>("LinkGroupId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("PortfolioLinkId");

                    b.ToTable("PortfolioLinks");
                });

            modelBuilder.Entity("Infrastructure.Models.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("DirectUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("longtext");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
