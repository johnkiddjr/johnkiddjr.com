using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BioDetails",
                columns: new[] { "BioDetailId", "BioId", "BioSectionId", "Description", "PhotoUrl" },
                values: new object[,]
                {
                    { new Guid("3533c312-319a-46d0-9fed-35c117301a6a"), new Guid("dc635535-81af-4cb5-a873-869225a41016"), new Guid("491fe316-cdcb-4b68-915b-5d086dec4970"), "I spent some time learning my first programming language at ITT Tech, but since found a better home for nurturing my talent at the University of Advancing Technology. I'm currently working toward a Bachelor's of Science there in Game Programming and expect to graduate in early 2024.", null },
                    { new Guid("6ebaffb8-80ca-4e1f-9dfa-4bb61b26de97"), new Guid("dc635535-81af-4cb5-a873-869225a41016"), new Guid("381488e3-3550-4db1-a412-259a283cee64"), "Over the years I've spent some time at a few companies, until 2018 my job title never said \"Programmer\" or \"Developer\" but I've had my hand in developing software for most of those companies anyway. For more information on exactly what I've been up to, head to the contact page and download my resume.", "/images/programming.jpg" },
                    { new Guid("878e58d9-f199-4b53-8574-f23a0a8146b5"), new Guid("dc635535-81af-4cb5-a873-869225a41016"), new Guid("efe97e6f-6a1c-4fc0-b53a-11efe24c5f9c"), "I was born August 3rd, 1987 in a small town in Michigan named Owosso (yes the one with a castle). I've lived all over since then. Including: Dallas Texas, Phoenix Arizona, and Grand Rapids Michigan. Eventually I settled (for now) in Lansing Michigan. Though, I'm always looking for another reason to move!", "/images/me-bio.jpg" },
                    { new Guid("eed8f756-2620-4997-85e3-eee46bde557d"), new Guid("dc635535-81af-4cb5-a873-869225a41016"), new Guid("e852053a-a46e-4ae3-a26e-ef31a0386e3c"), "I have a few hobbies, most notably I like to repair/build old arcade machines. So far I've only completed 1 but I'm currently working on getting Ultimate Mortal Kombat 3 into an old Midway cabinet I found! I'm also known for working on and riding my motorcycles, playing video games, or going to the movies.", "/images/arcade-machine.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BioSections",
                columns: new[] { "BioSectionId", "Name" },
                values: new object[,]
                {
                    { new Guid("381488e3-3550-4db1-a412-259a283cee64"), "Experience" },
                    { new Guid("491fe316-cdcb-4b68-915b-5d086dec4970"), "Education" },
                    { new Guid("e852053a-a46e-4ae3-a26e-ef31a0386e3c"), "Hobbies" },
                    { new Guid("efe97e6f-6a1c-4fc0-b53a-11efe24c5f9c"), "General" }
                });

            migrationBuilder.InsertData(
                table: "Bios",
                columns: new[] { "BioId", "Name", "PictureUrl" },
                values: new object[] { new Guid("dc635535-81af-4cb5-a873-869225a41016"), "John Kidd Jr", "/images/me-small.jpg" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "EmailAddress", "HeaderText", "Name", "ResumeId" },
                values: new object[] { new Guid("39916318-b0b8-434b-b787-c8387d917ee6"), "johnkiddjr@outlook.com", "Want to get in touch with me? Use the information below to email me, view my resume, or connect with me on LinkedIn.", "John Kidd Jr", new Guid("7f5c1a59-2e32-4d85-841e-3bafe737b39d") });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FileId", "FileData", "FileName" },
                values: new object[] { new Guid("7f5c1a59-2e32-4d85-841e-3bafe737b39d"), null, null });

            migrationBuilder.InsertData(
                table: "LinkGroups",
                columns: new[] { "LinkGroupId", "GroupName" },
                values: new object[,]
                {
                    { new Guid("1109491b-0626-4979-bc92-27b80d8df14c"), "Code" },
                    { new Guid("89e84892-e148-4a1e-97a6-2cb7a51dde72"), "Articles" }
                });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "ObjectiveId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1eb52b1b-022e-4115-87d7-98468d65ca8a"), "Establish collaboration, mentorship, and professional leadership skills by working with other disciplines to deliver highly polished and completed projects", "Collaboration" },
                    { new Guid("3b4ba5ed-7579-40bc-a825-04cc9845d7b3"), "Implement multiple completed games, including 3D games, using common tools, languages, and software for web, console, PC, or mobile platforms", "Complete Games" },
                    { new Guid("3f307242-edad-4587-82d5-8535a22b94ee"), "Implement and analyze fundamental data structures and algorithms associated with game applications supporting gameplay mechanics", "Data Structures and Algorithms" },
                    { new Guid("4bbb3e1d-a872-4af7-a780-3eb07af8ea11"), "Design, develop, and implement the architecture and infrastructure needed to support a complete game project", "Architecture and Infrastructure" },
                    { new Guid("992f4c45-bd19-4e7c-a254-bbc47cf5d2a3"), "Use software development processes to analyze a project problem, and to design, build, and test a corresponding software solution", "Software for Problem Solving" },
                    { new Guid("b48bff71-69f1-4c78-960a-0faddf1e4ab3"), "Demonstrate development skills using multiple programming languages, development environments, and platforms, including advanced and/or experimental topics in game programming", "Language Master" }
                });

            migrationBuilder.InsertData(
                table: "ObjectivesDetails",
                columns: new[] { "ObjectiveDetailId", "LinkUrl", "Name", "ObjectiveId" },
                values: new object[,]
                {
                    { new Guid("7ccf2530-6ec0-48ff-93f3-d78f97093925"), "https://source.kiddclan.com/johnkiddjr/console-tictactoe", "Windows/Linux Console - TicTacToe", new Guid("3b4ba5ed-7579-40bc-a825-04cc9845d7b3") },
                    { new Guid("bb0d162a-dcab-467d-9569-974365d6c6a2"), null, "Fantastic Frienemies", new Guid("4bbb3e1d-a872-4af7-a780-3eb07af8ea11") },
                    { new Guid("d74b75e4-34ae-4ffa-a7ff-7243c60307a9"), "https://source.kiddclan.com/johnkiddjr/johnkiddjr.com", "My Portfolio Website", new Guid("992f4c45-bd19-4e7c-a254-bbc47cf5d2a3") },
                    { new Guid("e7bec651-f436-4244-8530-d9a5791e58fa"), null, "Tapper Clone (BizStream Tapper)", new Guid("b48bff71-69f1-4c78-960a-0faddf1e4ab3") }
                });

            migrationBuilder.InsertData(
                table: "Overviews",
                columns: new[] { "OverviewId", "BodyHtml", "CreatedDate", "HeaderText" },
                values: new object[] { new Guid("416c2518-4151-4241-8ede-70d97ef8855c"), "Welcome to my portfolio! Use the navigation to look at what I have to offer. Feel free to contact me through email or LinkedIn if you want to talk about a job, a collaboration, or even if just to say \"Hi!\"", new DateTime(2022, 7, 7, 1, 27, 1, 664, DateTimeKind.Local).AddTicks(8273), "Software Engineer with years of experience with C++, C#, VB, and many others on multiple platforms" });

            migrationBuilder.InsertData(
                table: "PortfolioLinks",
                columns: new[] { "PortfolioLinkId", "Link", "LinkGroupId", "Text" },
                values: new object[,]
                {
                    { new Guid("34fa2058-a475-459d-9322-a4531d19093c"), "https://www.bizstream.com/blog/january-2022/windows-authentication-with-net-5", new Guid("89e84892-e148-4a1e-97a6-2cb7a51dde72"), "Windows Authentication with .Net 5" },
                    { new Guid("4b62efa1-77d1-4522-bdfe-38e4669d87cd"), "https://github.com/johnkiddjr", new Guid("1109491b-0626-4979-bc92-27b80d8df14c"), "GitHub Repositories (Open Source Projects)" },
                    { new Guid("93ff7386-bd51-4267-9fc8-e389e9e65cd3"), "https://source.kiddclan.com/johnkiddjr", new Guid("1109491b-0626-4979-bc92-27b80d8df14c"), "GibLab Repositories (Personal Projects)" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Description", "DirectUrl", "Name", "PictureUrl" },
                values: new object[,]
                {
                    { new Guid("0a46c060-d62c-4e12-b58c-bed903f98e0f"), "Just a simple game I wrote about a year ago to make sure my C++ skills weren't getting rusty. It's 2 player, with no AI, and very simple.", "https://source.kiddclan.com/johnkiddjr/console-tictactoe", "Windows/Linux Console - TicTacToe", "/images/simple-tictactoe.jpg" },
                    { new Guid("2590613c-6eed-4dab-93f6-f687d52dc9fe"), "This is a board game created as part of my GAM125 class, for this project I served as a content creator and organizer. It plays 2-6 players as they try to work their way through a dungeon together. Only one person gets the treasure though, so watch out for traps by your allies!", null, "Fantastic Frienemies", "/images/ff.jpg" },
                    { new Guid("35da0f22-1a01-4e36-8e67-986d2f194308"), "This is a clone of Tapper made by myself and several others at BizStream, written in C++ and using Lua for scripting. While I wrote most of the source code, it is property of BizStream and not linked here.", null, "Tapper Clone (BizStream Tapper)", "/images/biztapper.jpg" },
                    { new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"), "This is a website written with C# for backend, with Vue as the frontend. The Vue side utilizes Typescript. Database is MariaDb.", "https://source.kiddclan.com/johnkiddjr/johnkiddjr.com", "My Portfolio Website", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("3533c312-319a-46d0-9fed-35c117301a6a"));

            migrationBuilder.DeleteData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("6ebaffb8-80ca-4e1f-9dfa-4bb61b26de97"));

            migrationBuilder.DeleteData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("878e58d9-f199-4b53-8574-f23a0a8146b5"));

            migrationBuilder.DeleteData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("eed8f756-2620-4997-85e3-eee46bde557d"));

            migrationBuilder.DeleteData(
                table: "BioSections",
                keyColumn: "BioSectionId",
                keyValue: new Guid("381488e3-3550-4db1-a412-259a283cee64"));

            migrationBuilder.DeleteData(
                table: "BioSections",
                keyColumn: "BioSectionId",
                keyValue: new Guid("491fe316-cdcb-4b68-915b-5d086dec4970"));

            migrationBuilder.DeleteData(
                table: "BioSections",
                keyColumn: "BioSectionId",
                keyValue: new Guid("e852053a-a46e-4ae3-a26e-ef31a0386e3c"));

            migrationBuilder.DeleteData(
                table: "BioSections",
                keyColumn: "BioSectionId",
                keyValue: new Guid("efe97e6f-6a1c-4fc0-b53a-11efe24c5f9c"));

            migrationBuilder.DeleteData(
                table: "Bios",
                keyColumn: "BioId",
                keyValue: new Guid("dc635535-81af-4cb5-a873-869225a41016"));

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "ContactId",
                keyValue: new Guid("39916318-b0b8-434b-b787-c8387d917ee6"));

            migrationBuilder.DeleteData(
                table: "Files",
                keyColumn: "FileId",
                keyValue: new Guid("7f5c1a59-2e32-4d85-841e-3bafe737b39d"));

            migrationBuilder.DeleteData(
                table: "LinkGroups",
                keyColumn: "LinkGroupId",
                keyValue: new Guid("1109491b-0626-4979-bc92-27b80d8df14c"));

            migrationBuilder.DeleteData(
                table: "LinkGroups",
                keyColumn: "LinkGroupId",
                keyValue: new Guid("89e84892-e148-4a1e-97a6-2cb7a51dde72"));

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "ObjectiveId",
                keyValue: new Guid("1eb52b1b-022e-4115-87d7-98468d65ca8a"));

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "ObjectiveId",
                keyValue: new Guid("3b4ba5ed-7579-40bc-a825-04cc9845d7b3"));

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "ObjectiveId",
                keyValue: new Guid("3f307242-edad-4587-82d5-8535a22b94ee"));

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "ObjectiveId",
                keyValue: new Guid("4bbb3e1d-a872-4af7-a780-3eb07af8ea11"));

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "ObjectiveId",
                keyValue: new Guid("992f4c45-bd19-4e7c-a254-bbc47cf5d2a3"));

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "ObjectiveId",
                keyValue: new Guid("b48bff71-69f1-4c78-960a-0faddf1e4ab3"));

            migrationBuilder.DeleteData(
                table: "ObjectivesDetails",
                keyColumn: "ObjectiveDetailId",
                keyValue: new Guid("7ccf2530-6ec0-48ff-93f3-d78f97093925"));

            migrationBuilder.DeleteData(
                table: "ObjectivesDetails",
                keyColumn: "ObjectiveDetailId",
                keyValue: new Guid("bb0d162a-dcab-467d-9569-974365d6c6a2"));

            migrationBuilder.DeleteData(
                table: "ObjectivesDetails",
                keyColumn: "ObjectiveDetailId",
                keyValue: new Guid("d74b75e4-34ae-4ffa-a7ff-7243c60307a9"));

            migrationBuilder.DeleteData(
                table: "ObjectivesDetails",
                keyColumn: "ObjectiveDetailId",
                keyValue: new Guid("e7bec651-f436-4244-8530-d9a5791e58fa"));

            migrationBuilder.DeleteData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"));

            migrationBuilder.DeleteData(
                table: "PortfolioLinks",
                keyColumn: "PortfolioLinkId",
                keyValue: new Guid("34fa2058-a475-459d-9322-a4531d19093c"));

            migrationBuilder.DeleteData(
                table: "PortfolioLinks",
                keyColumn: "PortfolioLinkId",
                keyValue: new Guid("4b62efa1-77d1-4522-bdfe-38e4669d87cd"));

            migrationBuilder.DeleteData(
                table: "PortfolioLinks",
                keyColumn: "PortfolioLinkId",
                keyValue: new Guid("93ff7386-bd51-4267-9fc8-e389e9e65cd3"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("0a46c060-d62c-4e12-b58c-bed903f98e0f"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("2590613c-6eed-4dab-93f6-f687d52dc9fe"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("35da0f22-1a01-4e36-8e67-986d2f194308"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"));
        }
    }
}
