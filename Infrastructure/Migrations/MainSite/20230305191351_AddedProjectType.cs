using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.MainSite
{
    /// <inheritdoc />
    public partial class AddedProjectType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectType",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 14, 13, 51, 409, DateTimeKind.Local).AddTicks(3858));

            migrationBuilder.UpdateData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("9694bc54-7f9a-40d4-9101-5059cacc6d41"),
                column: "Url",
                value: "ff.jpg");

            migrationBuilder.UpdateData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("bc1c350d-6813-4a94-8148-285bc2b4966b"),
                column: "Url",
                value: "biztapper.jpg");

            migrationBuilder.UpdateData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("f477507f-186b-43af-a668-38a054098ca7"),
                column: "Url",
                value: "simple-tictactoe.jpg");

            migrationBuilder.InsertData(
                table: "ProjectImages",
                columns: new[] { "ProjectImageId", "AltText", "ProjectId", "Url" },
                values: new object[] { new Guid("6d18f31c-beba-44a8-8ad2-494f0ae8089f"), "Portfolio Home Snippet", new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"), "portfolio-web.png" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("0a46c060-d62c-4e12-b58c-bed903f98e0f"),
                column: "ProjectType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("2590613c-6eed-4dab-93f6-f687d52dc9fe"),
                column: "ProjectType",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("35da0f22-1a01-4e36-8e67-986d2f194308"),
                column: "ProjectType",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("5b4a154e-4c71-45e5-8dee-d7bbdae7abe2"),
                column: "ProjectType",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("6d18f31c-beba-44a8-8ad2-494f0ae8089f"));

            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2023, 3, 5, 13, 57, 5, 697, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("9694bc54-7f9a-40d4-9101-5059cacc6d41"),
                column: "Url",
                value: "/images/ff.jpg");

            migrationBuilder.UpdateData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("bc1c350d-6813-4a94-8148-285bc2b4966b"),
                column: "Url",
                value: "/images/biztapper.jpg");

            migrationBuilder.UpdateData(
                table: "ProjectImages",
                keyColumn: "ProjectImageId",
                keyValue: new Guid("f477507f-186b-43af-a668-38a054098ca7"),
                column: "Url",
                value: "/images/simple-tictactoe.jpg");
        }
    }
}
