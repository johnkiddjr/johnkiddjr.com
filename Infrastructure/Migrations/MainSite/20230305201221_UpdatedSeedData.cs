using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.MainSite
{
    /// <inheritdoc />
    public partial class UpdatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("6ebaffb8-80ca-4e1f-9dfa-4bb61b26de97"),
                column: "PhotoUrl",
                value: "programming.jpg");

            migrationBuilder.UpdateData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("878e58d9-f199-4b53-8574-f23a0a8146b5"),
                column: "PhotoUrl",
                value: "me-bio.jpg");

            migrationBuilder.UpdateData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("eed8f756-2620-4997-85e3-eee46bde557d"),
                column: "PhotoUrl",
                value: "arcade-machine.jpg");

            migrationBuilder.UpdateData(
                table: "Bios",
                keyColumn: "BioId",
                keyValue: new Guid("dc635535-81af-4cb5-a873-869225a41016"),
                column: "PictureUrl",
                value: "me-small.jpg");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 15, 12, 21, 832, DateTimeKind.Local).AddTicks(5423));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"),
                column: "LibrariesUsed",
                value: "Markdig, RestSharp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("6ebaffb8-80ca-4e1f-9dfa-4bb61b26de97"),
                column: "PhotoUrl",
                value: "/images/programming.jpg");

            migrationBuilder.UpdateData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("878e58d9-f199-4b53-8574-f23a0a8146b5"),
                column: "PhotoUrl",
                value: "/images/me-bio.jpg");

            migrationBuilder.UpdateData(
                table: "BioDetails",
                keyColumn: "BioDetailId",
                keyValue: new Guid("eed8f756-2620-4997-85e3-eee46bde557d"),
                column: "PhotoUrl",
                value: "/images/arcade-machine.jpg");

            migrationBuilder.UpdateData(
                table: "Bios",
                keyColumn: "BioId",
                keyValue: new Guid("dc635535-81af-4cb5-a873-869225a41016"),
                column: "PictureUrl",
                value: "/images/me-small.jpg");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 14, 13, 51, 409, DateTimeKind.Local).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"),
                column: "LibrariesUsed",
                value: "");
        }
    }
}
