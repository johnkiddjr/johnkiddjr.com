﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations.MainSite
{
    [DbContext(typeof(MainSiteContext))]
    [Migration("20230305171944_AddedAdditionalProjectData")]
    partial class AddedAdditionalProjectData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Infrastructure.Models.Article", b =>
                {
                    b.Property<Guid>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("AvailableDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext");

                    b.Property<string>("PreviewText")
                        .HasColumnType("longtext");

                    b.Property<string>("Slug")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Visible")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("ArticleId");

                    b.HasIndex("Slug")
                        .IsUnique();

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Infrastructure.Models.ArticleTag", b =>
                {
                    b.Property<Guid>("ArticleTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TagId")
                        .HasColumnType("char(36)");

                    b.HasKey("ArticleTagId");

                    b.ToTable("ArticleTagRelations");
                });

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

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.HasKey("BioSectionId");

                    b.ToTable("BioSections");
                });

            modelBuilder.Entity("Infrastructure.Models.CardBackground", b =>
                {
                    b.Property<Guid>("CardBackgroundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("DescriptionFontColor")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageFilename")
                        .HasColumnType("longtext");

                    b.Property<Guid>("TagId")
                        .HasColumnType("char(36)");

                    b.Property<string>("TitleFontColor")
                        .HasColumnType("longtext");

                    b.HasKey("CardBackgroundId");

                    b.ToTable("CardBackgrounds");
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

            modelBuilder.Entity("Infrastructure.Models.HighScore", b =>
                {
                    b.Property<Guid>("HighScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("HighScoreId");

                    b.ToTable("HighScores");
                });

            modelBuilder.Entity("Infrastructure.Models.Identity.ApplicationRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<Guid>("BioId")
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
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

                    b.Property<DateTime>("CreatedDate")
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

            modelBuilder.Entity("Infrastructure.Models.PrivacyPolicy", b =>
                {
                    b.Property<Guid>("PrivacyPolicyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("PolicyMarkdownName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ValidUntil")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PrivacyPolicyId");

                    b.ToTable("PrivacyPolicies");
                });

            modelBuilder.Entity("Infrastructure.Models.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("DownloadUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("LanguageUsed")
                        .HasColumnType("longtext");

                    b.Property<string>("LibrariesUsed")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NetVersion")
                        .HasColumnType("longtext");

                    b.Property<string>("ProjectSlug")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RepositoryType")
                        .HasColumnType("int");

                    b.Property<string>("RepositoryUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("longtext");

                    b.HasKey("ProjectId");

                    b.HasIndex("ProjectSlug")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Infrastructure.Models.ProjectImage", b =>
                {
                    b.Property<Guid>("ProjectImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AltText")
                        .HasColumnType("longtext");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("ProjectImageId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectImages");
                });

            modelBuilder.Entity("Infrastructure.Models.ProjectLink", b =>
                {
                    b.Property<Guid>("ProjectLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("ProjectLinkId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectLink");
                });

            modelBuilder.Entity("Infrastructure.Models.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.ProjectImage", b =>
                {
                    b.HasOne("Infrastructure.Models.Project", null)
                        .WithMany("Images")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.ProjectLink", b =>
                {
                    b.HasOne("Infrastructure.Models.Project", null)
                        .WithMany("Links")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Infrastructure.Models.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Infrastructure.Models.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Infrastructure.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.Project", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Links");
                });
#pragma warning restore 612, 618
        }
    }
}
