using Infrastructure.Enumerations;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public static class DataSeed
    {
        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrivacyPolicy>()
                .HasData(
                    new PrivacyPolicy
                    {
                        PrivacyPolicyId = Guid.Parse("aae087b6-be6a-4631-9d49-4ff21220ecd8"),
                        PolicyMarkdownName = "aae087b6-be6a-4631-9d49-4ff21220ecd8_en.md",
                        ValidFrom = DateTime.Parse("2022-12-05 00:00:00"),
                        ValidUntil = null
                    }
                );

            modelBuilder.Entity<Bio>()
                .HasData(
                    new Bio
                    {
                        BioId = Guid.Parse("DC635535-81AF-4CB5-A873-869225A41016"),
                        Name = "John Kidd Jr",
                        PictureUrl = "me-small.jpg"
                    }
                );

            modelBuilder.Entity<BioSection>()
                .HasData(
                    new BioSection
                    {
                        BioSectionId = Guid.Parse("EFE97E6F-6A1C-4FC0-B53A-11EFE24C5F9C"),
                        Name = "General",
                        Order = 1
                    },
                    new BioSection
                    {
                        BioSectionId = Guid.Parse("491FE316-CDCB-4B68-915B-5D086DEC4970"),
                        Name = "Education",
                        Order = 2
                    },
                    new BioSection
                    {
                        BioSectionId = Guid.Parse("381488E3-3550-4DB1-A412-259A283CEE64"),
                        Name = "Experience",
                        Order = 3
                    },
                    new BioSection
                    {
                        BioSectionId = Guid.Parse("E852053A-A46E-4AE3-A26E-EF31A0386E3C"),
                        Name = "Hobbies",
                        Order = 4
                    }
                );

            modelBuilder.Entity<BioDetail>()
                .HasData(
                    new BioDetail
                    {
                        BioDetailId = Guid.Parse("878E58D9-F199-4B53-8574-F23A0A8146B5"),
                        BioId = Guid.Parse("DC635535-81AF-4CB5-A873-869225A41016"),
                        Description = "I was born August 3rd, 1987 in a small town in Michigan named Owosso (yes the one with a castle). I've lived " +
                        "all over since then. Including: Dallas Texas, Phoenix Arizona, and Grand Rapids Michigan. Eventually I settled (for now) in " +
                        "Lansing Michigan. Though, I'm always looking for another reason to move!",
                        PhotoUrl = "me-bio.jpg",
                        BioSectionId = Guid.Parse("EFE97E6F-6A1C-4FC0-B53A-11EFE24C5F9C"),
                    },
                    new BioDetail
                    {
                        BioDetailId = Guid.Parse("3533C312-319A-46D0-9FED-35C117301A6A"),
                        BioId = Guid.Parse("DC635535-81AF-4CB5-A873-869225A41016"),
                        Description = "I spent some time learning my first programming language at ITT Tech, but since found a better home for " +
                        "nurturing my talent at the University of Advancing Technology. I'm currently working toward a Bachelor's of Science there " +
                        "in Game Programming and expect to graduate in early 2024.",
                        BioSectionId = Guid.Parse("491FE316-CDCB-4B68-915B-5D086DEC4970")
                    },
                    new BioDetail
                    {
                        BioDetailId = Guid.Parse("6EBAFFB8-80CA-4E1F-9DFA-4BB61B26DE97"),
                        BioId = Guid.Parse("DC635535-81AF-4CB5-A873-869225A41016"),
                        Description = "Over the years I've spent some time at a few companies, until 2018 my job title never said \"Programmer\" or " +
                        "\"Developer\" but I've had my hand in developing software for most of those companies anyway. For more information on exactly " +
                        "what I've been up to, head to the contact page and download my resume.",
                        PhotoUrl = "programming.jpg",
                        BioSectionId = Guid.Parse("381488E3-3550-4DB1-A412-259A283CEE64")
                    },
                    new BioDetail
                    {
                        BioDetailId = Guid.Parse("EED8F756-2620-4997-85E3-EEE46BDE557D"),
                        BioId = Guid.Parse("DC635535-81AF-4CB5-A873-869225A41016"),
                        Description = "I have a few hobbies, most notably I like to repair/build old arcade machines. So far I've only completed 1 " +
                        "but I'm currently working on getting Ultimate Mortal Kombat 3 into an old Midway cabinet I found! I'm also known for " +
                        "working on and riding my motorcycles, playing video games, or going to the movies.",
                        PhotoUrl = "arcade-machine.jpg",
                        BioSectionId = Guid.Parse("E852053A-A46E-4AE3-A26E-EF31A0386E3C")
                    }
                );

            modelBuilder.Entity<Contact>()
                .HasData(
                    new Contact
                    {
                        EmailAddress = "johnkiddjr@outlook.com",
                        ContactId = Guid.Parse("39916318-B0B8-434B-B787-C8387D917EE6"),
                        HeaderText = "Want to get in touch with me? Use the information below to email me, view my resume, or connect with me on LinkedIn.",
                        Name = "John Kidd Jr",
                        ResumeId = Guid.Parse("7F5C1A59-2E32-4D85-841E-3BAFE737B39D")
                    }
                );

            modelBuilder.Entity<File>()
                .HasData(
                    new File
                    {
                        FileId = Guid.Parse("7F5C1A59-2E32-4D85-841E-3BAFE737B39D")
                    }
                );

            modelBuilder.Entity<LinkGroup>()
                .HasData(
                    new LinkGroup
                    {
                        LinkGroupId = Guid.Parse("1109491B-0626-4979-BC92-27B80D8DF14C"),
                        GroupName = "Code"
                    },
                    new LinkGroup
                    {
                        LinkGroupId = Guid.Parse("89E84892-E148-4A1E-97A6-2CB7A51DDE72"),
                        GroupName = "Articles"
                    }
                );

            modelBuilder.Entity<Objective>()
                .HasData(
                    new Objective
                    {
                        ObjectiveId = Guid.Parse("3B4BA5ED-7579-40BC-A825-04CC9845D7B3"),
                        Name = "Complete Games",
                        Description = "Implement multiple completed games, including 3D games, using common tools, languages, and software for web, console, PC, or mobile platforms"
                    },
                    new Objective
                    {
                        ObjectiveId = Guid.Parse("4BBB3E1D-A872-4AF7-A780-3EB07AF8EA11"),
                        Name = "Architecture and Infrastructure",
                        Description = "Design, develop, and implement the architecture and infrastructure needed to support a complete game project"
                    },
                    new Objective
                    {
                        ObjectiveId = Guid.Parse("3F307242-EDAD-4587-82D5-8535A22B94EE"),
                        Name = "Data Structures and Algorithms",
                        Description = "Implement and analyze fundamental data structures and algorithms associated with game applications supporting gameplay mechanics"
                    },
                    new Objective
                    {
                        ObjectiveId = Guid.Parse("992F4C45-BD19-4E7C-A254-BBC47CF5D2A3"),
                        Name = "Software for Problem Solving",
                        Description = "Use software development processes to analyze a project problem, and to design, build, and test a corresponding software solution"
                    },
                    new Objective
                    {
                        ObjectiveId = Guid.Parse("B48BFF71-69F1-4C78-960A-0FADDF1E4AB3"),
                        Name = "Language Master",
                        Description = "Demonstrate development skills using multiple programming languages, development environments, and platforms, including advanced and/or experimental topics in game programming"
                    },
                    new Objective
                    {
                        ObjectiveId = Guid.Parse("1EB52B1B-022E-4115-87D7-98468D65CA8A"),
                        Name = "Collaboration",
                        Description = "Establish collaboration, mentorship, and professional leadership skills by working with other disciplines to deliver highly polished and completed projects"
                    }
                );

            modelBuilder.Entity<Platform>()
                .HasData(
                    new Platform
                    {
                        PlatformId = Guid.Parse("4f279f13-bec0-45ea-965c-9dde847f03ca"),
                        Name = "Windows"
                    },
                    new Platform
                    {
                        PlatformId = Guid.Parse("f8cbbfaa-d89e-4cb1-a4b1-912aa0da1d4d"),
                        Name = "Physical"
                    }
                );

            modelBuilder.Entity<ObjectiveDetail>()
                .HasData(
                    new ObjectiveDetail
                    {
                        ObjectiveDetailId = Guid.Parse("7CCF2530-6EC0-48FF-93F3-D78F97093925"),
                        ObjectiveId = Guid.Parse("3B4BA5ED-7579-40BC-A825-04CC9845D7B3"),
                        Name = "Windows/Linux Console - TicTacToe",
                        LinkUrl = "https://source.kiddclan.com/johnkiddjr/console-tictactoe"
                    },
                    new ObjectiveDetail
                    {
                        ObjectiveDetailId = Guid.Parse("D74B75E4-34AE-4FFA-A7FF-7243C60307A9"),
                        ObjectiveId = Guid.Parse("992F4C45-BD19-4E7C-A254-BBC47CF5D2A3"),
                        Name = "My Portfolio Website",
                        LinkUrl = "https://source.kiddclan.com/johnkiddjr/johnkiddjr.com"
                    },
                    new ObjectiveDetail
                    {
                        ObjectiveDetailId = Guid.Parse("E7BEC651-F436-4244-8530-D9A5791E58FA"),
                        ObjectiveId = Guid.Parse("B48BFF71-69F1-4C78-960A-0FADDF1E4AB3"),
                        Name = "Tapper Clone (BizStream Tapper)"
                    },
                    new ObjectiveDetail
                    {
                        ObjectiveDetailId = Guid.Parse("BB0D162A-DCAB-467D-9569-974365D6C6A2"),
                        ObjectiveId = Guid.Parse("4BBB3E1D-A872-4AF7-A780-3EB07AF8EA11"),
                        Name = "Fantastic Frienemies"
                    }
                );

            modelBuilder.Entity<Overview>()
                .HasData(
                    new Overview
                    {
                        OverviewId = Guid.Parse("416C2518-4151-4241-8EDE-70D97EF8855C"),
                        HeaderText = "Software Engineer with years of experience with C++, C#, VB, and many others on multiple platforms",
                        BodyHtml = "Welcome to my portfolio! Use the navigation to look at what I have to offer. Feel free to contact me through email or LinkedIn if you want to talk about a job, a collaboration, or even if just to say \"Hi!\"",
                        CreatedDate = DateTime.Now
                    }
                );

            modelBuilder.Entity<PortfolioLink>()
                .HasData(
                    new PortfolioLink
                    {
                        PortfolioLinkId = Guid.Parse("4B62EFA1-77D1-4522-BDFE-38E4669D87CD"),
                        LinkGroupId = Guid.Parse("1109491B-0626-4979-BC92-27B80D8DF14C"),
                        Link = "https://github.com/johnkiddjr",
                        Text = "GitHub Repositories (Open Source Projects)"
                    },
                    new PortfolioLink
                    {
                        PortfolioLinkId = Guid.Parse("93FF7386-BD51-4267-9FC8-E389E9E65CD3"),
                        LinkGroupId = Guid.Parse("1109491B-0626-4979-BC92-27B80D8DF14C"),
                        Link = "https://source.kiddclan.com/johnkiddjr",
                        Text = "GibLab Repositories (Personal Projects)"
                    },
                    new PortfolioLink
                    {
                        PortfolioLinkId = Guid.Parse("34FA2058-A475-459D-9322-A4531D19093C"),
                        LinkGroupId = Guid.Parse("89E84892-E148-4A1E-97A6-2CB7A51DDE72"),
                        Link = "https://www.bizstream.com/blog/january-2022/windows-authentication-with-net-5",
                        Text = "Windows Authentication with .Net 5"
                    }
                );

            modelBuilder.Entity<ProjectImage>()
                .HasData(
                    new ProjectImage
                    {
                        AltText = "Fantasic Frienemies",
                        ProjectId = Guid.Parse("2590613C-6EED-4DAB-93F6-F687D52DC9FE"),
                        Url = "ff.jpg",
                        ProjectImageId = Guid.Parse("9694bc54-7f9a-40d4-9101-5059cacc6d41")
                    },
                    new ProjectImage
                    {
                        AltText = "Tapper Clone (BizStream Tapper)",
                        Url = "biztapper.jpg",
                        ProjectId = Guid.Parse("35DA0F22-1A01-4E36-8E67-986D2F194308"),
                        ProjectImageId = Guid.Parse("bc1c350d-6813-4a94-8148-285bc2b4966b")
                    },
                    new ProjectImage
                    {
                        Url = "simple-tictactoe.jpg",
                        AltText = "Tic Tac Toe",
                        ProjectId = Guid.Parse("0A46C060-D62C-4E12-B58C-BED903F98E0F"),
                        ProjectImageId = Guid.Parse("f477507f-186b-43af-a668-38a054098ca7")
                    },
                    new ProjectImage
                    {
                        Url = "portfolio-web.png",
                        AltText = "Portfolio Home Snippet",
                        ProjectId = Guid.Parse("5B4A154E-4C71-45E5-8DEE-D7BBDAE7ABE2"),
                        ProjectImageId = Guid.Parse("6d18f31c-beba-44a8-8ad2-494f0ae8089f")
                    },
                    new ProjectImage
                    {
                        Url = "f03912f92b3e4f96be8df8e6fc481986.png",
                        AltText = "Title Screen for Knockout Arcade",
                        ProjectId = Guid.Parse("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                        ProjectImageId = Guid.Parse("08db1e06-2e75-49ab-896f-9788075da899")
                    },
                    new ProjectImage
                    {
                        Url = "8a1635ea5b05404883bf8f0c488172eb.png",
                        AltText = "Fight!",
                        ProjectId = Guid.Parse("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                        ProjectImageId = Guid.Parse("08db1e06-2e76-4ee2-8768-aa567530f060")
                    },
                    new ProjectImage
                    {
                        Url = "4bf524eb3b584c66b822e8056c3ddee4.png",
                        AltText = "Character Select screen for Knockout Arcade",
                        ProjectId = Guid.Parse("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                        ProjectImageId = Guid.Parse("08db1e06-2e77-4ca4-8782-afb4b7d6d86e")
                    },
                    new ProjectImage
                    {
                        Url = "10ac07360ab749d0bbc3b8a63e09bb10.png",
                        AltText = "Stage Select screen for Knockout Arcade",
                        ProjectId = Guid.Parse("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                        ProjectImageId = Guid.Parse("08db1e06-2e78-47e6-8845-2a3ef9a1f023")
                    },
                    new ProjectImage
                    {
                        Url = "9f83759f89c14e979311acd4cb3c14ce.png",
                        AltText = "Close up of a kick happening in Knockout Arcade",
                        ProjectId = Guid.Parse("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                        ProjectImageId = Guid.Parse("08db1e06-2e79-42c5-8560-3997e920306d")
                    },
                    new ProjectImage
                    {
                        Url = "3e54a89bd2684eba95f68c838cd95ce3.png",
                        AltText = "Editor Project Selection Page",
                        ProjectId = Guid.Parse("08db1e07-c533-41a9-86e9-aafee37468dd"),
                        ProjectImageId = Guid.Parse("08db1e07-c53a-446b-81a2-82876521112f")
                    },
                    new ProjectImage
                    {
                        Url = "1af8b33b248e4fb985691b6cbe9f12f4.png",
                        AltText = "Editor Character Selection Page",
                        ProjectId = Guid.Parse("08db1e07-c533-41a9-86e9-aafee37468dd"),
                        ProjectImageId = Guid.Parse("08db1e07-c53a-4d9f-8777-04fdc4b93ae7")
                    },
                    new ProjectImage
                    {
                        Url = "2613367a2bdc4cbea5fbbf4a241a2f97.png",
                        AltText = "Default palette, move editor visible.",
                        ProjectId = Guid.Parse("08db1e07-c533-41a9-86e9-aafee37468dd"),
                        ProjectImageId = Guid.Parse("08db1e07-c53b-4b3f-854d-f3fc6f3c73b2")
                    },
                    new ProjectImage
                    {
                        Url = "4a29d56dd5124a2fb310ddb814334f1e.png",
                        AltText = "Yellow palette, palette editor visible.",
                        ProjectId = Guid.Parse("08db1e07-c533-41a9-86e9-aafee37468dd"),
                        ProjectImageId = Guid.Parse("08db1e07-c53c-4852-8185-7f60db2bbee2")
                    }
                );

            modelBuilder.Entity<ProjectLink>()
                .HasData(
                    new ProjectLink
                    {
                        ProjectId = Guid.Parse("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                        ProjectLinkId = Guid.Parse("08db1e06-2e79-4530-8bcd-de7c94012db5"),
                        Text = "Character Editor Tool",
                        Url = "/portfolio/KOArcadeTool"
                    },
                    new ProjectLink
                    {
                        ProjectId = Guid.Parse("08db1e07-c533-41a9-86e9-aafee37468dd"),
                        ProjectLinkId = Guid.Parse("08db1e07-c53c-4866-88a1-69d0f8e25d06"),
                        Text = "Knockout Arcade",
                        Url = "/portfolio/KOArcade"
                    }
                );

            modelBuilder.Entity<ProjectPlatform>()
                .HasData(
                    new ProjectPlatform
                    {
                        ProjectPlatformId = Guid.Parse("6cb3a514-03da-4602-a5ab-68a4e02be07c"),
                        ProjectId = Guid.Parse("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                        PlatformId = Guid.Parse("4f279f13-bec0-45ea-965c-9dde847f03ca")
                    },
                    new ProjectPlatform
                    {
                        ProjectPlatformId = Guid.Parse("42cf8fbc-d043-4ef2-8207-45ca92f29ec9"),
                        ProjectId = Guid.Parse("0A46C060-D62C-4E12-B58C-BED903F98E0F"),
                        PlatformId = Guid.Parse("4f279f13-bec0-45ea-965c-9dde847f03ca")
                    },
                    new ProjectPlatform
                    {
                        ProjectPlatformId = Guid.Parse("d5bf7480-2ee7-411d-a6ff-5f6ce4ce7ee1"),
                        ProjectId = Guid.Parse("5B4A154E-4C71-45E5-8DEE-D7BBDAE7ABE2"),
                        PlatformId = Guid.Parse("4f279f13-bec0-45ea-965c-9dde847f03ca")
                    },
                    new ProjectPlatform
                    {
                        ProjectPlatformId = Guid.Parse("78a504f8-671d-4fe6-a87b-4e0ef7957d4d"),
                        ProjectId = Guid.Parse("08db1e07-c533-41a9-86e9-aafee37468dd"),
                        PlatformId = Guid.Parse("4f279f13-bec0-45ea-965c-9dde847f03ca")
                    },
                    new ProjectPlatform
                    {
                        ProjectPlatformId = Guid.Parse("f8fbf0c6-a925-48a4-921e-3b1380f4a6c9"),
                        ProjectId = Guid.Parse("35DA0F22-1A01-4E36-8E67-986D2F194308"),
                        PlatformId = Guid.Parse("4f279f13-bec0-45ea-965c-9dde847f03ca")
                    },
                    new ProjectPlatform
                    {
                        ProjectPlatformId = Guid.Parse("54b3c3b5-0e70-4d0f-a163-a089027599b5"),
                        ProjectId = Guid.Parse("2590613C-6EED-4DAB-93F6-F687D52DC9FE"),
                        PlatformId = Guid.Parse("f8cbbfaa-d89e-4cb1-a4b1-912aa0da1d4d")
                    }
                );

            modelBuilder.Entity<Project>()
                .HasData(
                    new Project
                    {
                        ProjectId = Guid.Parse("2590613C-6EED-4DAB-93F6-F687D52DC9FE"),
                        Name = "Fantastic Frienemies",
                        ShortDescription = "This is a board game created as part of my GAM125 class, for this project I served as a content creator and organizer. It plays 2-6 players as they try to work their way through a dungeon together. Only one person gets the treasure though, so watch out for traps by your allies!",
                        Description = "This is a board game created as part of my GAM125 class, for this project I served as a content creator and organizer. It plays 2-6 players as they try to work their way through a dungeon together. Only one person gets the treasure though, so watch out for traps by your allies!",
                        RepositoryUrl = null,
                        DownloadUrl = null,
                        LanguageUsed = null,
                        LibrariesUsed = null,
                        NetVersion = null,
                        ProjectSlug = "FantasticFrienemies",
                        RepositoryType = RepositoryType.None,
                        ProjectType = ProjectType.Other,
                        DateAdded = DateTime.Now
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("35DA0F22-1A01-4E36-8E67-986D2F194308"),
                        Name = "Tapper Clone (BizStream Tapper)",
                        ShortDescription = "This is a clone of Tapper made by myself and several others at BizStream, written in C++ and using Lua for scripting. While I wrote most of the source code, it is property of BizStream and not linked here.",
                        Description = "This is a clone of Tapper made by myself and several others at BizStream, written in C++ and using Lua for scripting. While I wrote most of the source code, it is property of BizStream and not linked here.",
                        RepositoryUrl = null,
                        DownloadUrl = null,
                        LanguageUsed = "C++, Lua",
                        LibrariesUsed = "SDL, Lua, sol, glm, ImGui",
                        NetVersion = null,
                        ProjectSlug = "BizTapper",
                        RepositoryType = RepositoryType.None,
                        ProjectType = ProjectType.Programming,
                        DateAdded = DateTime.Now
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("5B4A154E-4C71-45E5-8DEE-D7BBDAE7ABE2"),
                        Name = "My Portfolio Website",
                        ShortDescription = "This is a website written with C# for backend, with Vue as the frontend. The Vue side utilizes Typescript. Database is MariaDb.",
                        Description = "This is a website written with C# for backend, with Vue as the frontend. The Vue side utilizes Typescript. Database is MariaDb.",
                        RepositoryUrl = "https://source.kiddclan.com/johnkiddjr/johnkiddjr.com",
                        DownloadUrl = null,
                        LanguageUsed = "C#",
                        NetVersion = "7.0",
                        LibrariesUsed = "Markdig, RestSharp",
                        ProjectSlug = "Portfolio",
                        RepositoryType = RepositoryType.GitLab,
                        ProjectType = ProjectType.Programming,
                        DateAdded = DateTime.Now
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("0A46C060-D62C-4E12-B58C-BED903F98E0F"),
                        Name = "Tic Tac Toe (Console)",
                        ShortDescription = "Just a simple game I wrote about a year ago to make sure my C++ skills weren't getting rusty. It's 2 player, with no AI, and very simple.",
                        RepositoryUrl = "https://source.kiddclan.com/johnkiddjr/console-tictactoe",
                        DownloadUrl = "https://source.kiddclan.com/johnkiddjr/console-tictactoe/-/releases",
                        LanguageUsed = "C++",
                        LibrariesUsed = null,
                        NetVersion = null,
                        ProjectSlug = "ConsoleTicTacToe",
                        RepositoryType = RepositoryType.GitLab,
                        ProjectType = ProjectType.Programming,
                        Description = "This implementation of Tic Tac Toe is written in C++ and outputs everything to the console. When the game starts, the console will display an empty 3x3 grid representing the Tic Tac Toe board. The two players will take turns placing their symbols on the board by entering the row and column numbers of the space they want to occupy. The game will then check if the move is valid and update the board accordingly. If a player achieves three in a row or all spaces on the board are filled, the game will end and display the result on the console.  This implementation does not include an AI player option, so it is intended for two human players to play against each other.",
                        DateAdded = DateTime.Now
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                        Name = "Knockout Arcade",
                        ShortDescription = "This is a 2D retro-inspired fighting game with easy-to-pick-up controls and stylish combos. The game takes place at a famous arcade, owned by a dangerous businessman.",
                        RepositoryUrl = "https://github.com/KnockoutArcade/KnockoutArcade",
                        DownloadUrl = "https://jazz-boy.itch.io/knock-out-arcade",
                        LanguageUsed = "GameMaker Language (GML)",
                        LibrariesUsed = null,
                        NetVersion = null,
                        ProjectSlug = "KOArcade",
                        RepositoryType = RepositoryType.GitHub,
                        ProjectType = ProjectType.Programming,
                        Description = "I served as Programming Lead on this project, supervising two other programmers while contributing to both this project and the Character Data Editor Tool.\r\n\r\nOfficial description of the game:\r\n\r\nWelcome to KNOCK-OUT ARCADE!\r\n\r\nThis is a 2D retro-inspired fighting game with easy-to-pick-up controls and stylish combos. The game takes place at a famous arcade, owned by a dangerous businessman.",
                        DateAdded = DateTime.Now
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("08db1e07-c533-41a9-86e9-aafee37468dd"),
                        Name = "Knockout Arcade Character Editor Tool",
                        ShortDescription = "This is an editor for creating and modifying the data for the characters in Knockout Arcade!",
                        RepositoryUrl = "https://github.com/KnockoutArcade/Character-Data-Editor",
                        DownloadUrl = "https://github.com/KnockoutArcade/Character-Data-Editor/releases",
                        LanguageUsed = "C#, GLSL",
                        LibrariesUsed = "ImGui.Net, Raylib-cs, Newtonsoft.Json, Serilog, System.Commandline, Hardware.Info",
                        NetVersion = "7.0",
                        ProjectSlug = "KOArcadeTool",
                        RepositoryType = RepositoryType.GitHub,
                        ProjectType = ProjectType.Programming,
                        Description = "For Knockout Arcade I served as the Lead Programmer. As part of my responsibilities, I created and maintained this Character Editor Tool.\r\n\r\nThis editor is used to create and modify the data for the characters in Knockout Arcade. The data is exported in JSON format to be imported and used by the game directly. This greatly improved the usability of the code and made it trivial to add new characters or make changes to the character's stats or moves.\r\n\r\nAdditionally, this tool allows designers to make palette changes in real-time. Greatly reducing the time it takes to try out new palettes for the characters.",
                        DateAdded = DateTime.Now
                    }
                );

            modelBuilder.Entity<AdminSection>()
                .HasData(
                    new AdminSection
                    {
                        AdminSectionId = Guid.Parse("860d2bd2-c8ac-4011-980b-a76830b32541"),
                        SectionTitle = "Article Management"
                    },
                    new AdminSection
                    {
                        AdminSectionId = Guid.Parse("08db1dc5-3dd3-425c-820c-4268e219dadd"),
                        SectionTitle = "Project Management"
                    },
                    new AdminSection
                    {
                        AdminSectionId = Guid.Parse("08db1dc5-1ebc-4334-81b4-22ff3c75b527"),
                        SectionTitle = "Admin Management"
                    }
                );

            modelBuilder.Entity<AdminSectionItem>()
                .HasData(
                    new AdminSectionItem
                    {
                        AdminSectionItemId = Guid.Parse("fd4afcdb-14b4-40b7-a490-75d92168bee6"),
                        AdminSectionId = Guid.Parse("860d2bd2-c8ac-4011-980b-a76830b32541"),
                        LinkText = "Upload New Article",
                        LinkUrl = "/Article/Upload"
                    },
                    new AdminSectionItem
                    {
                        AdminSectionId = Guid.Parse("08db1dc5-1ebc-4334-81b4-22ff3c75b527"),
                        AdminSectionItemId = Guid.Parse("08db1dd1-dc20-4aac-8d68-94390a576ec9"),
                        LinkText = "Add Section",
                        LinkUrl = "/Admin/AddSection"
                    },
                    new AdminSectionItem
                    {
                        AdminSectionId = Guid.Parse("08db1dc5-1ebc-4334-81b4-22ff3c75b527"),
                        AdminSectionItemId = Guid.Parse("08db1dd1-ec7e-4daf-8d3d-859391d415cf"),
                        LinkText = "Add Section Item",
                        LinkUrl = "/Admin/AddSectionItem"
                    },
                    new AdminSectionItem
                    {
                        AdminSectionId = Guid.Parse("08db1dc5-3dd3-425c-820c-4268e219dadd"),
                        AdminSectionItemId = Guid.Parse("f410c76b-e8d5-4315-ac94-a739b98f7a0c"),
                        LinkText = "Add Project",
                        LinkUrl = "/Project/AddProject"
                    }
                );

            return modelBuilder;
        }
    }
}
