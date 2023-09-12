using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations.MainSite
{
    /// <inheritdoc />
    public partial class AddedPlatforms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProjectPlatforms",
                columns: table => new
                {
                    ProjectPlatformId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ProjectId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PlatformId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPlatforms", x => x.ProjectPlatformId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 9, 9, 22, 52, 33, 166, DateTimeKind.Local).AddTicks(1753));

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "Name" },
                values: new object[,]
                {
                    { new Guid("4f279f13-bec0-45ea-965c-9dde847f03ca"), "Windows" },
                    { new Guid("f8cbbfaa-d89e-4cb1-a4b1-912aa0da1d4d"), "Physical" }
                });

            migrationBuilder.InsertData(
                table: "ProjectPlatforms",
                columns: new[] { "ProjectPlatformId", "PlatformId", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("42cf8fbc-d043-4ef2-8207-45ca92f29ec9"), new Guid("4f279f13-bec0-45ea-965c-9dde847f03ca"), new Guid("0a46c060-d62c-4e12-b58c-bed903f98e0f") },
                    { new Guid("54b3c3b5-0e70-4d0f-a163-a089027599b5"), new Guid("f8cbbfaa-d89e-4cb1-a4b1-912aa0da1d4d"), new Guid("2590613c-6eed-4dab-93f6-f687d52dc9fe") },
                    { new Guid("6cb3a514-03da-4602-a5ab-68a4e02be07c"), new Guid("4f279f13-bec0-45ea-965c-9dde847f03ca"), new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56") },
                    { new Guid("78a504f8-671d-4fe6-a87b-4e0ef7957d4d"), new Guid("4f279f13-bec0-45ea-965c-9dde847f03ca"), new Guid("08db1e07-c533-41a9-86e9-aafee37468dd") },
                    { new Guid("d5bf7480-2ee7-411d-a6ff-5f6ce4ce7ee1"), new Guid("4f279f13-bec0-45ea-965c-9dde847f03ca"), new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2") },
                    { new Guid("f8fbf0c6-a925-48a4-921e-3b1380f4a6c9"), new Guid("4f279f13-bec0-45ea-965c-9dde847f03ca"), new Guid("35da0f22-1a01-4e36-8e67-986d2f194308") }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 9, 22, 52, 33, 166, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 9, 22, 52, 33, 166, DateTimeKind.Local).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("0a46c060-d62c-4e12-b58c-bed903f98e0f"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 9, 22, 52, 33, 166, DateTimeKind.Local).AddTicks(1912));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("2590613c-6eed-4dab-93f6-f687d52dc9fe"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 9, 22, 52, 33, 166, DateTimeKind.Local).AddTicks(1902));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("35da0f22-1a01-4e36-8e67-986d2f194308"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 9, 22, 52, 33, 166, DateTimeKind.Local).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"),
                column: "DateAdded",
                value: new DateTime(2023, 9, 9, 22, 52, 33, 166, DateTimeKind.Local).AddTicks(1909));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "ProjectPlatforms");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("08db1e06-2e6d-415c-8bb9-435e511b2a56"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6407));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("08db1e07-c533-41a9-86e9-aafee37468dd"),
                column: "DateAdded",
                value: new DateTime(2023, 3, 6, 2, 6, 36, 350, DateTimeKind.Local).AddTicks(6410));

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
        }
    }
}
