using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.MainSite
{
    /// <inheritdoc />
    public partial class ChangedTableNameForProjLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLink_Projects_ProjectId",
                table: "ProjectLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectLink",
                table: "ProjectLink");

            migrationBuilder.RenameTable(
                name: "ProjectLink",
                newName: "ProjectLinks");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectLink_ProjectId",
                table: "ProjectLinks",
                newName: "IX_ProjectLinks_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectLinks",
                table: "ProjectLinks",
                column: "ProjectLinkId");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 13, 57, 5, 697, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLinks_Projects_ProjectId",
                table: "ProjectLinks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectLinks_Projects_ProjectId",
                table: "ProjectLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectLinks",
                table: "ProjectLinks");

            migrationBuilder.RenameTable(
                name: "ProjectLinks",
                newName: "ProjectLink");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectLinks_ProjectId",
                table: "ProjectLink",
                newName: "IX_ProjectLink_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectLink",
                table: "ProjectLink",
                column: "ProjectLinkId");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 12, 43, 58, 721, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectLink_Projects_ProjectId",
                table: "ProjectLink",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
