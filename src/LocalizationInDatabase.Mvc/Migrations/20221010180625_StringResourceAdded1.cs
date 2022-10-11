using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalizationInDatabase.Mvc.Migrations
{
    public partial class StringResourceAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "IsApproved", "LanguageId", "Name", "Value" },
                values: new object[] { 194, true, 1, "Languages.List.Th_name", "ADI" });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "IsApproved", "LanguageId", "Name", "Value" },
                values: new object[] { 195, true, 2, "Languages.List.Th_name", "NAME" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StringResources",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "StringResources",
                keyColumn: "Id",
                keyValue: 195);
        }
    }
}
