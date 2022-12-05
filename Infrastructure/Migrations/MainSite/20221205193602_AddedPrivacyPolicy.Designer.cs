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
    [Migration("20221205193602_AddedPrivacyPolicy")]
    partial class AddedPrivacyPolicy
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
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

                    b.HasData(
                        new
                        {
                            BioId = new Guid("dc635535-81af-4cb5-a873-869225a41016"),
                            Name = "John Kidd Jr",
                            PictureUrl = "/images/me-small.jpg"
                        });
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

                    b.HasData(
                        new
                        {
                            BioDetailId = new Guid("878e58d9-f199-4b53-8574-f23a0a8146b5"),
                            BioId = new Guid("dc635535-81af-4cb5-a873-869225a41016"),
                            BioSectionId = new Guid("efe97e6f-6a1c-4fc0-b53a-11efe24c5f9c"),
                            Description = "I was born August 3rd, 1987 in a small town in Michigan named Owosso (yes the one with a castle). I've lived all over since then. Including: Dallas Texas, Phoenix Arizona, and Grand Rapids Michigan. Eventually I settled (for now) in Lansing Michigan. Though, I'm always looking for another reason to move!",
                            PhotoUrl = "/images/me-bio.jpg"
                        },
                        new
                        {
                            BioDetailId = new Guid("3533c312-319a-46d0-9fed-35c117301a6a"),
                            BioId = new Guid("dc635535-81af-4cb5-a873-869225a41016"),
                            BioSectionId = new Guid("491fe316-cdcb-4b68-915b-5d086dec4970"),
                            Description = "I spent some time learning my first programming language at ITT Tech, but since found a better home for nurturing my talent at the University of Advancing Technology. I'm currently working toward a Bachelor's of Science there in Game Programming and expect to graduate in early 2024."
                        },
                        new
                        {
                            BioDetailId = new Guid("6ebaffb8-80ca-4e1f-9dfa-4bb61b26de97"),
                            BioId = new Guid("dc635535-81af-4cb5-a873-869225a41016"),
                            BioSectionId = new Guid("381488e3-3550-4db1-a412-259a283cee64"),
                            Description = "Over the years I've spent some time at a few companies, until 2018 my job title never said \"Programmer\" or \"Developer\" but I've had my hand in developing software for most of those companies anyway. For more information on exactly what I've been up to, head to the contact page and download my resume.",
                            PhotoUrl = "/images/programming.jpg"
                        },
                        new
                        {
                            BioDetailId = new Guid("eed8f756-2620-4997-85e3-eee46bde557d"),
                            BioId = new Guid("dc635535-81af-4cb5-a873-869225a41016"),
                            BioSectionId = new Guid("e852053a-a46e-4ae3-a26e-ef31a0386e3c"),
                            Description = "I have a few hobbies, most notably I like to repair/build old arcade machines. So far I've only completed 1 but I'm currently working on getting Ultimate Mortal Kombat 3 into an old Midway cabinet I found! I'm also known for working on and riding my motorcycles, playing video games, or going to the movies.",
                            PhotoUrl = "/images/arcade-machine.jpg"
                        });
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

                    b.HasData(
                        new
                        {
                            BioSectionId = new Guid("efe97e6f-6a1c-4fc0-b53a-11efe24c5f9c"),
                            Name = "General",
                            Order = 1
                        },
                        new
                        {
                            BioSectionId = new Guid("491fe316-cdcb-4b68-915b-5d086dec4970"),
                            Name = "Education",
                            Order = 2
                        },
                        new
                        {
                            BioSectionId = new Guid("381488e3-3550-4db1-a412-259a283cee64"),
                            Name = "Experience",
                            Order = 3
                        },
                        new
                        {
                            BioSectionId = new Guid("e852053a-a46e-4ae3-a26e-ef31a0386e3c"),
                            Name = "Hobbies",
                            Order = 4
                        });
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

                    b.HasData(
                        new
                        {
                            ContactId = new Guid("39916318-b0b8-434b-b787-c8387d917ee6"),
                            EmailAddress = "johnkiddjr@outlook.com",
                            HeaderText = "Want to get in touch with me? Use the information below to email me, view my resume, or connect with me on LinkedIn.",
                            Name = "John Kidd Jr",
                            ResumeId = new Guid("7f5c1a59-2e32-4d85-841e-3bafe737b39d")
                        });
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

                    b.HasData(
                        new
                        {
                            FileId = new Guid("7f5c1a59-2e32-4d85-841e-3bafe737b39d")
                        });
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

                    b.HasData(
                        new
                        {
                            LinkGroupId = new Guid("1109491b-0626-4979-bc92-27b80d8df14c"),
                            GroupName = "Code"
                        },
                        new
                        {
                            LinkGroupId = new Guid("89e84892-e148-4a1e-97a6-2cb7a51dde72"),
                            GroupName = "Articles"
                        });
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

                    b.HasData(
                        new
                        {
                            ObjectiveId = new Guid("3b4ba5ed-7579-40bc-a825-04cc9845d7b3"),
                            Description = "Implement multiple completed games, including 3D games, using common tools, languages, and software for web, console, PC, or mobile platforms",
                            Name = "Complete Games"
                        },
                        new
                        {
                            ObjectiveId = new Guid("4bbb3e1d-a872-4af7-a780-3eb07af8ea11"),
                            Description = "Design, develop, and implement the architecture and infrastructure needed to support a complete game project",
                            Name = "Architecture and Infrastructure"
                        },
                        new
                        {
                            ObjectiveId = new Guid("3f307242-edad-4587-82d5-8535a22b94ee"),
                            Description = "Implement and analyze fundamental data structures and algorithms associated with game applications supporting gameplay mechanics",
                            Name = "Data Structures and Algorithms"
                        },
                        new
                        {
                            ObjectiveId = new Guid("992f4c45-bd19-4e7c-a254-bbc47cf5d2a3"),
                            Description = "Use software development processes to analyze a project problem, and to design, build, and test a corresponding software solution",
                            Name = "Software for Problem Solving"
                        },
                        new
                        {
                            ObjectiveId = new Guid("b48bff71-69f1-4c78-960a-0faddf1e4ab3"),
                            Description = "Demonstrate development skills using multiple programming languages, development environments, and platforms, including advanced and/or experimental topics in game programming",
                            Name = "Language Master"
                        },
                        new
                        {
                            ObjectiveId = new Guid("1eb52b1b-022e-4115-87d7-98468d65ca8a"),
                            Description = "Establish collaboration, mentorship, and professional leadership skills by working with other disciplines to deliver highly polished and completed projects",
                            Name = "Collaboration"
                        });
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

                    b.HasData(
                        new
                        {
                            ObjectiveDetailId = new Guid("7ccf2530-6ec0-48ff-93f3-d78f97093925"),
                            LinkUrl = "https://source.kiddclan.com/johnkiddjr/console-tictactoe",
                            Name = "Windows/Linux Console - TicTacToe",
                            ObjectiveId = new Guid("3b4ba5ed-7579-40bc-a825-04cc9845d7b3")
                        },
                        new
                        {
                            ObjectiveDetailId = new Guid("d74b75e4-34ae-4ffa-a7ff-7243c60307a9"),
                            LinkUrl = "https://source.kiddclan.com/johnkiddjr/johnkiddjr.com",
                            Name = "My Portfolio Website",
                            ObjectiveId = new Guid("992f4c45-bd19-4e7c-a254-bbc47cf5d2a3")
                        },
                        new
                        {
                            ObjectiveDetailId = new Guid("e7bec651-f436-4244-8530-d9a5791e58fa"),
                            Name = "Tapper Clone (BizStream Tapper)",
                            ObjectiveId = new Guid("b48bff71-69f1-4c78-960a-0faddf1e4ab3")
                        },
                        new
                        {
                            ObjectiveDetailId = new Guid("bb0d162a-dcab-467d-9569-974365d6c6a2"),
                            Name = "Fantastic Frienemies",
                            ObjectiveId = new Guid("4bbb3e1d-a872-4af7-a780-3eb07af8ea11")
                        });
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

                    b.HasData(
                        new
                        {
                            OverviewId = new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                            BodyHtml = "Welcome to my portfolio! Use the navigation to look at what I have to offer. Feel free to contact me through email or LinkedIn if you want to talk about a job, a collaboration, or even if just to say \"Hi!\"",
                            CreatedDate = new DateTime(2022, 12, 5, 14, 36, 1, 854, DateTimeKind.Local).AddTicks(6006),
                            HeaderText = "Software Engineer with years of experience with C++, C#, VB, and many others on multiple platforms"
                        });
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

                    b.HasData(
                        new
                        {
                            PortfolioLinkId = new Guid("4b62efa1-77d1-4522-bdfe-38e4669d87cd"),
                            Link = "https://github.com/johnkiddjr",
                            LinkGroupId = new Guid("1109491b-0626-4979-bc92-27b80d8df14c"),
                            Text = "GitHub Repositories (Open Source Projects)"
                        },
                        new
                        {
                            PortfolioLinkId = new Guid("93ff7386-bd51-4267-9fc8-e389e9e65cd3"),
                            Link = "https://source.kiddclan.com/johnkiddjr",
                            LinkGroupId = new Guid("1109491b-0626-4979-bc92-27b80d8df14c"),
                            Text = "GibLab Repositories (Personal Projects)"
                        },
                        new
                        {
                            PortfolioLinkId = new Guid("34fa2058-a475-459d-9322-a4531d19093c"),
                            Link = "https://www.bizstream.com/blog/january-2022/windows-authentication-with-net-5",
                            LinkGroupId = new Guid("89e84892-e148-4a1e-97a6-2cb7a51dde72"),
                            Text = "Windows Authentication with .Net 5"
                        });
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

                    b.HasData(
                        new
                        {
                            PrivacyPolicyId = new Guid("aae087b6-be6a-4631-9d49-4ff21220ecd8"),
                            PolicyMarkdownName = "aae087b6-be6a-4631-9d49-4ff21220ecd8_en.md",
                            ValidFrom = new DateTime(2022, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
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

                    b.HasData(
                        new
                        {
                            ProjectId = new Guid("2590613c-6eed-4dab-93f6-f687d52dc9fe"),
                            Description = "This is a board game created as part of my GAM125 class, for this project I served as a content creator and organizer. It plays 2-6 players as they try to work their way through a dungeon together. Only one person gets the treasure though, so watch out for traps by your allies!",
                            Name = "Fantastic Frienemies",
                            PictureUrl = "/images/ff.jpg"
                        },
                        new
                        {
                            ProjectId = new Guid("35da0f22-1a01-4e36-8e67-986d2f194308"),
                            Description = "This is a clone of Tapper made by myself and several others at BizStream, written in C++ and using Lua for scripting. While I wrote most of the source code, it is property of BizStream and not linked here.",
                            Name = "Tapper Clone (BizStream Tapper)",
                            PictureUrl = "/images/biztapper.jpg"
                        },
                        new
                        {
                            ProjectId = new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"),
                            Description = "This is a website written with C# for backend, with Vue as the frontend. The Vue side utilizes Typescript. Database is MariaDb.",
                            DirectUrl = "https://source.kiddclan.com/johnkiddjr/johnkiddjr.com",
                            Name = "My Portfolio Website"
                        },
                        new
                        {
                            ProjectId = new Guid("0a46c060-d62c-4e12-b58c-bed903f98e0f"),
                            Description = "Just a simple game I wrote about a year ago to make sure my C++ skills weren't getting rusty. It's 2 player, with no AI, and very simple.",
                            DirectUrl = "https://source.kiddclan.com/johnkiddjr/console-tictactoe",
                            Name = "Windows/Linux Console - TicTacToe",
                            PictureUrl = "/images/simple-tictactoe.jpg"
                        });
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
#pragma warning restore 612, 618
        }
    }
}
