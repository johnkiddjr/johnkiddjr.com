using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.MainSite
{
    /// <inheritdoc />
    public partial class AddedAdminArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectImages_Projects_ProjectId",
                table: "ProjectImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLinks_Projects_ProjectId",
                table: "ProjectLinks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectLinks_ProjectId",
                table: "ProjectLinks");

            migrationBuilder.DropIndex(
                name: "IX_ProjectImages_ProjectId",
                table: "ProjectImages");

            migrationBuilder.CreateTable(
                name: "AdminSections",
                columns: table => new
                {
                    AdminSectionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    SectionTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSections", x => x.AdminSectionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdminSectionsItems",
                columns: table => new
                {
                    AdminSectionItemId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    AdminSectionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    LinkText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinkUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSectionsItems", x => x.AdminSectionItemId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AdminSections",
                columns: new[] { "AdminSectionId", "SectionTitle" },
                values: new object[] { new Guid("860d2bd2-c8ac-4011-980b-a76830b32541"), "Articles" });

            migrationBuilder.InsertData(
                table: "AdminSectionsItems",
                columns: new[] { "AdminSectionItemId", "AdminSectionId", "LinkText", "LinkUrl" },
                values: new object[] { new Guid("fd4afcdb-14b4-40b7-a490-75d92168bee6"), new Guid("860d2bd2-c8ac-4011-980b-a76830b32541"), "Upload New Article", "/Article/Upload" });

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 15, 42, 50, 572, DateTimeKind.Local).AddTicks(3398));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminSections");

            migrationBuilder.DropTable(
                name: "AdminSectionsItems");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 15, 12, 21, 832, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLinks_ProjectId",
                table: "ProjectLinks",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectImages_ProjectId",
                table: "ProjectImages",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectImages_Projects_ProjectId",
                table: "ProjectImages",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLinks_Projects_ProjectId",
                table: "ProjectLinks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
