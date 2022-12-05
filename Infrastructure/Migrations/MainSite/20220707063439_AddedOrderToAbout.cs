using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.MainSite
{
    public partial class AddedOrderToAbout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "BioSections",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BioSections",
                keyColumn: "BioSectionId",
                keyValue: new Guid("381488e3-3550-4db1-a412-259a283cee64"),
                column: "Order",
                value: 3);

            migrationBuilder.UpdateData(
                table: "BioSections",
                keyColumn: "BioSectionId",
                keyValue: new Guid("491fe316-cdcb-4b68-915b-5d086dec4970"),
                column: "Order",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BioSections",
                keyColumn: "BioSectionId",
                keyValue: new Guid("e852053a-a46e-4ae3-a26e-ef31a0386e3c"),
                column: "Order",
                value: 4);

            migrationBuilder.UpdateData(
                table: "BioSections",
                keyColumn: "BioSectionId",
                keyValue: new Guid("efe97e6f-6a1c-4fc0-b53a-11efe24c5f9c"),
                column: "Order",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2022, 7, 7, 2, 34, 39, 364, DateTimeKind.Local).AddTicks(2721));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "BioSections");

            migrationBuilder.UpdateData(
                table: "Overviews",
                keyColumn: "OverviewId",
                keyValue: new Guid("416c2518-4151-4241-8ede-70d97ef8855c"),
                column: "CreatedDate",
                value: new DateTime(2022, 7, 7, 1, 27, 1, 664, DateTimeKind.Local).AddTicks(8273));
        }
    }
}
