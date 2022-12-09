using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc /> 
    public partial class AddedCardBackgrounds : Migration
    {
        /// <inheritdoc /> 
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardBackgrounds",
                columns: table => new
                {
                    CardBackgroundId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TagId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImageFileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TitleFontColor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescriptionFontColor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardBackgrounds", x => x.CardBackgroundId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 27, 1, 48, 43, 924, DateTimeKind.Local).AddTicks(9865));
        }

        /// <inheritdoc /> 
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardBackgrounds");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2022, 11, 19, 21, 27, 44, 971, DateTimeKind.Local).AddTicks(4835));
        }
    }
}