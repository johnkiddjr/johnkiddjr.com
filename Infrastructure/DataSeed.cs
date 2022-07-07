using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public static class DataSeed
    {
        public static ModelBuilder SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bio>()
                .HasData(
                    new Bio
                    {
                        BioId = Guid.Parse("DC635535-81AF-4CB5-A873-869225A41016"),
                        Name = "John Kidd Jr",
                        PictureUrl = "/images/me-small.jpg"
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
                        PhotoUrl = "/images/me-bio.jpg",
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
                        PhotoUrl = "/images/programming.jpg",
                        BioSectionId = Guid.Parse("381488E3-3550-4DB1-A412-259A283CEE64")
                    },
                    new BioDetail
                    {
                        BioDetailId = Guid.Parse("EED8F756-2620-4997-85E3-EEE46BDE557D"),
                        BioId = Guid.Parse("DC635535-81AF-4CB5-A873-869225A41016"),
                        Description = "I have a few hobbies, most notably I like to repair/build old arcade machines. So far I've only completed 1 " +
                        "but I'm currently working on getting Ultimate Mortal Kombat 3 into an old Midway cabinet I found! I'm also known for " +
                        "working on and riding my motorcycles, playing video games, or going to the movies.",
                        PhotoUrl = "/images/arcade-machine.jpg",
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

            modelBuilder.Entity<Project>()
                .HasData(
                    new Project
                    {
                        ProjectId = Guid.Parse("2590613C-6EED-4DAB-93F6-F687D52DC9FE"),
                        Name = "Fantastic Frienemies",
                        Description = "This is a board game created as part of my GAM125 class, for this project I served as a content creator and organizer. It plays 2-6 players as they try to work their way through a dungeon together. Only one person gets the treasure though, so watch out for traps by your allies!",
                        PictureUrl = "/images/ff.jpg"
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("35DA0F22-1A01-4E36-8E67-986D2F194308"),
                        Name = "Tapper Clone (BizStream Tapper)",
                        Description = "This is a clone of Tapper made by myself and several others at BizStream, written in C++ and using Lua for scripting. While I wrote most of the source code, it is property of BizStream and not linked here.",
                        PictureUrl = "/images/biztapper.jpg"
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("5B4A154E-4C71-45E5-8DEE-D7BBDAE7ABE2"),
                        Name = "My Portfolio Website",
                        Description = "This is a website written with C# for backend, with Vue as the frontend. The Vue side utilizes Typescript. Database is MariaDb.",
                        DirectUrl = "https://source.kiddclan.com/johnkiddjr/johnkiddjr.com"
                    },
                    new Project
                    {
                        ProjectId = Guid.Parse("0A46C060-D62C-4E12-B58C-BED903F98E0F"),
                        Name = "Windows/Linux Console - TicTacToe",
                        DirectUrl = "https://source.kiddclan.com/johnkiddjr/console-tictactoe",
                        Description = "Just a simple game I wrote about a year ago to make sure my C++ skills weren't getting rusty. It's 2 player, with no AI, and very simple.",
                        PictureUrl = "/images/simple-tictactoe.jpg"
                    }
                );

            return modelBuilder;
        }
    }
}
