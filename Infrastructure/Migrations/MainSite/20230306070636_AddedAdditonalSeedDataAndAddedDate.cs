using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations.MainSite
{
    /// <inheritdoc />
    public partial class AddedAdditonalSeedDataAndAddedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Projects",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AdminSections",
                keyColumn: "AdminSectionId",
                keyValue: new Guid("860d2bd2-c8ac-4011-980b-a76830b32541"),
                column: "SectionTitle",
                value: "Article Management");

            migrationBuilder.InsertData(
                table: "AdminSections",
                columns: new[] { "AdminSectionId", "SectionTitle" },
                values: new object[,]
                {
                    { new Guid("08db1dc5-1ebc-4334-81b4-22ff3c75b527"), "Admin Management" },
                    { new Guid("08db1dc5-3dd3-425c-820c-4268e219dadd"), "Project Management" }
                });

            migrationBuilder.InsertData(
                table: "AdminSectionsItems",
                columns: new[] { "AdminSectionItemId", "AdminSectionId", "LinkText", "LinkUrl" },
                values: new object[,]
                {
                    { new Guid("08db1dd1-dc20-4aac-8d68-94390a576ec9"), new Guid("08db1dc5-1ebc-4334-81b4-22ff3c75b527"), "Add Section", "/Admin/AddSection" },
                    { new Guid("08db1dd1-ec7e-4daf-8d3d-859391d415cf"), new Guid("08db1dc5-1ebc-4334-81b4-22ff3c75b527"), "Add Section Item", "/Admin/AddSectionItem" },
                    { new Guid("f410c76b-e8d5-4315-ac94-a739b98f7a0c"), new Guid("08db1dc5-3dd3-425c-820c-4268e219dadd"), "Add Project", "/Project/AddProject" }
                });

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6286));

            migrationBuilder.InsertData(
                table: "ProjectImages",
                columns: new[] { "ProjectImageId", "AltText", "ProjectId", "Url" },
                values: new object[,]
                {
                    { new Guid("08db1e06-2e75-49ab-896f-9788075da899"), "Title Screen for Knockout Arcade", new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"), "f03912f92b3e4f96be8df8e6fc481986.png" },
                    { new Guid("08db1e06-2e76-4ee2-8768-aa567530f060"), "Fight!", new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"), "8a1635ea5b05404883bf8f0c488172eb.png" },
                    { new Guid("08db1e06-2e77-4ca4-8782-afb4b7d6d86e"), "Character Select screen for Knockout Arcade", new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"), "4bf524eb3b584c66b822e8056c3ddee4.png" },
                    { new Guid("08db1e06-2e78-47e6-8845-2a3ef9a1f023"), "Stage Select screen for Knockout Arcade", new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"), "10ac07360ab749d0bbc3b8a63e09bb10.png" },
                    { new Guid("08db1e06-2e79-42c5-8560-3997e920306d"), "Close up of a kick happening in Knockout Arcade", new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"), "9f83759f89c14e979311acd4cb3c14ce.png" },
                    { new Guid("08db1e07-c53a-446b-81a2-82876521112f"), "Editor Project Selection Page", new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"), "3e54a89bd2684eba95f68c838cd95ce3.png" },
                    { new Guid("08db1e07-c53a-4d9f-8777-04fdc4b93ae7"), "Editor Character Selection Page", new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"), "1af8b33b248e4fb985691b6cbe9f12f4.png" },
                    { new Guid("08db1e07-c53b-4b3f-854d-f3fc6f3c73b2"), "Default palette, move editor visible.", new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"), "2613367a2bdc4cbea5fbbf4a241a2f97.png" },
                    { new Guid("08db1e07-c53c-4852-8185-7f60db2bbee2"), "Yellow palette, palette editor visible.", new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"), "4a29d56dd5124a2fb310ddb814334f1e.png" }
                });

            migrationBuilder.InsertData(
                table: "ProjectLinks",
                columns: new[] { "ProjectLinkId", "ProjectId", "Text", "Url" },
                values: new object[,]
                {
                    { new Guid("08db1e06-2e79-4530-8bcd-de7c94012db5"), new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"), "Character Editor Tool", "/portfolio/KOArcadeTool" },
                    { new Guid("08db1e07-c53c-4866-88a1-69d0f8e25d06"), new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"), "Knockout Arcade", "/portfolio/KOArcade" }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("0a46c060-d62c-4e12-b58c-bed903f98e0f"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6405));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("2590613c-6eed-4dab-93f6-f687d52dc9fe"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6396));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("35da0f22-1a01-4e36-8e67-986d2f194308"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6399));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6402));

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DateAdded", "Description", "DownloadUrl", "LanguageUsed", "LibrariesUsed", "Name", "NetVersion", "ProjectSlug", "ProjectType", "RepositoryType", "RepositoryUrl", "ShortDescription" },
                values: new object[,]
                {
                    { new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"), new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6407), "I served as Programming Lead on this project, supervising two other programmers while contributing to both this project and the Character Data Editor Tool.\r\n\r\nOfficial description of the game:\r\n\r\nWelcome to KNOCK-OUT ARCADE!\r\n\r\nThis is a 2D retro-inspired fighting game with easy-to-pick-up controls and stylish combos. The game takes place at a famous arcade, owned by a dangerous businessman.", "https://jazz-boy.itch.io/knock-out-arcade", "GameMaker Language (GML)", null, "Knockout Arcade", null, "KOArcade", 1, 1, "https://github.com/KnockoutArcade/KnockoutArcade", "This is a 2D retro-inspired fighting game with easy-to-pick-up controls and stylish combos. The game takes place at a famous arcade, owned by a dangerous businessman." },
                    { new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"), new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6410), "For Knockout Arcade I served as the Lead Programmer. As part of my responsibilities, I created and maintained this Character Editor Tool.\r\n\r\nThis editor is used to create and modify the data for the characters in Knockout Arcade. The data is exported in JSON format to be imported and used by the game directly. This greatly improved the usability of the code and made it trivial to add new characters or make changes to the character's stats or moves.\r\n\r\nAdditionally, this tool allows designers to make palette changes in real-time. Greatly reducing the time it takes to try out new palettes for the characters.", "https://github.com/KnockoutArcade/Character-Data-Editor/releases", "C#, GLSL", "ImGui.Net, Raylib-cs, Newtonsoft.Json, Serilog, System.Commandline, Hardware.Info", "Knockout Arcade Character Editor Tool", "7.0", "KOArcadeTool", 1, 1, "https://github.com/KnockoutArcade/Character-Data-Editor", "This is an editor for creating and modifying the data for the characters in Knockout Arcade!" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdminSections",
                keyColumn: "AdminSectionId",
                keyValue: new Guid("08db1dc5-1ebc-4334-81b4-22ff3c75b527"));

            migrationBuilder.DeleteData(
                table: "AdminSections",
                keyColumn: "AdminSectionId",
                keyValue: new Guid("08db1dc5-3dd3-425c-820c-4268e219dadd"));

            migrationBuilder.DeleteData(
                table: "AdminSectionsItems",
                keyColumn: "AdminSectionItemId",
                keyValue: new Guid("08db1dd1-dc20-4aac-8d68-94390a576ec9"));

            migrationBuilder.DeleteData(
                table: "AdminSectionsItems",
                keyColumn: "AdminSectionItemId",
                keyValue: new Guid("08db1dd1-ec7e-4daf-8d3d-859391d415cf"));

            migrationBuilder.DeleteData(
                table: "AdminSectionsItems",
                keyColumn: "AdminSectionItemId",
                keyValue: new Guid("f410c76b-e8d5-4315-ac94-a739b98f7a0c"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e06-2e75-49ab-896f-9788075da899"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e06-2e76-4ee2-8768-aa567530f060"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e06-2e77-4ca4-8782-afb4b7d6d86e"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e06-2e78-47e6-8845-2a3ef9a1f023"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e06-2e79-42c5-8560-3997e920306d"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e07-c53a-446b-81a2-82876521112f"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e07-c53a-4d9f-8777-04fdc4b93ae7"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e07-c53b-4b3f-854d-f3fc6f3c73b2"));

            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("08db1e07-c53c-4852-8185-7f60db2bbee2"));

            migrationBuilder.DeleteData(
                table: "ProjectLinks",
                keyColumn: "ProjectLinkId",
                keyValue: new Guid("08db1e06-2e79-4530-8bcd-de7c94012db5"));

            migrationBuilder.DeleteData(
                table: "ProjectLinks",
                keyColumn: "ProjectLinkId",
                keyValue: new Guid("08db1e07-c53c-4866-88a1-69d0f8e25d06"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"));

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "AdminSections",
                keyColumn: "AdminSectionId",
                keyValue: new Guid("860d2bd2-c8ac-4011-980b-a76830b32541"),
                column: "SectionTitle",
                value: "Articles");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 15, 42, 50, 572, DateTimeKind.Local).AddTicks(3398));
        }
    }
}
