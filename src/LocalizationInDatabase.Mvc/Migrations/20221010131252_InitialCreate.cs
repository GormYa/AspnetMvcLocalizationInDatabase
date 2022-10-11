using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalizationInDatabase.Mvc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Culture = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StringResources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StringResources_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture" },
                values: new object[] { 1, "tr-TR" });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Culture" },
                values: new object[] { 2, "en-US" });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "IsApproved", "LanguageId", "Name", "Value" },
                values: new object[,]
                {
                    { 1, true, 1, "Navbar.Home.Index.Link", "Ana Sayfa" },
                    { 2, true, 1, "Navbar.Employees.List.Link", "Çalışanlar" },
                    { 3, true, 1, "Navbar.Languages.List.Link", "Diller" },
                    { 4, true, 1, "Submenu.Employees.Create.Button", "Ekle" },
                    { 5, true, 1, "Submenu.Employees.List.Button", "Listeye Dön" },
                    { 6, true, 1, "Submenu.Employees.Edit.Button", "Düzenle" },
                    { 7, true, 1, "Submenu.Employees.Delete.Button", "Sil" },
                    { 8, true, 1, "Submenu.Languages.Create.Button", "Ekle" },
                    { 9, true, 1, "Submenu.Languages.List.Button", "Listeye Dön" },
                    { 10, true, 1, "Submenu.Languages.Edit.Button", "Düzenle" },
                    { 11, true, 1, "Submenu.Languages.Delete.Button", "Sil" },
                    { 12, true, 1, "Submenu.StringResources.Create.Button", "Ekle" },
                    { 13, true, 1, "Submenu.StringResources.List.Button", "Listeye Dön" },
                    { 14, true, 1, "Submenu.StringResources.Edit.Button", "Düzenle" },
                    { 15, true, 1, "Submenu.StringResources.Delete.Button", "Sil" },
                    { 16, true, 1, "Breadcrumb.Home.Index", "Ana Sayfa" },
                    { 17, true, 1, "Breadcrumb.Employees.Create", "Ekle" },
                    { 18, true, 1, "Breadcrumb.Employees.List", "Çalışanlar" },
                    { 19, true, 1, "Breadcrumb.Employees.Details", "{0}" },
                    { 20, true, 1, "Breadcrumb.Employees.Edit", "Düzenle" },
                    { 21, true, 1, "Breadcrumb.Languages.Create", "Ekle" },
                    { 22, true, 1, "Breadcrumb.Languages.List", "Diller" },
                    { 23, true, 1, "Breadcrumb.Languages.Details", "{0}" },
                    { 24, true, 1, "Breadcrumb.Languages.Edit", "Düzenle" },
                    { 25, true, 1, "Breadcrumb.StringResources.Create", "Ekle" },
                    { 26, true, 1, "Breadcrumb.StringResources.List", "Çeviriler" },
                    { 27, true, 1, "Breadcrumb.StringResources.Details", "{0}" },
                    { 28, true, 1, "Breadcrumb.StringResources.Edit", "Düzenle" },
                    { 29, true, 1, "Employees.List.Title", "Çalışanlar" },
                    { 30, true, 1, "Employees.List.Heading", "Çalışanlar" },
                    { 31, true, 1, "Employees.List.No_employees", "Çalışan yok." },
                    { 32, true, 1, "Employees.List.Th_name", "ADI" },
                    { 33, true, 1, "Employees.List.Details.Link", "İncele" },
                    { 34, true, 1, "Employees.List.Edit.Link", "Düzenle" },
                    { 35, true, 1, "Employees.List.Delete.Link", "Sil" },
                    { 36, true, 1, "Employees.Create.Title", "Çalışan Ekle" },
                    { 37, true, 1, "Employees.Create.Heading", "Çalışan Ekle" },
                    { 38, true, 1, "Employees.Create.Submit.Button", "Ekle" },
                    { 39, true, 1, "Employees.Create.Submit_and_return_list.Button", "Ekle ve Listeye Dön" },
                    { 40, true, 1, "Employees.Create.Return_list.Link", "Listeye Dön" },
                    { 41, true, 1, "Employees.Edit.Title", "Çalışanı Düzenle" },
                    { 42, true, 1, "Employees.Edit.Heading", "Çalışanı Düzenle" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "IsApproved", "LanguageId", "Name", "Value" },
                values: new object[,]
                {
                    { 43, true, 1, "Employees.Edit.Submit.Button", "Kaydet" },
                    { 44, true, 1, "Employees.Edit.Submit_and_go_back.Button", "Kaydet ve Geri Dön" },
                    { 45, true, 1, "Employees.Edit.Go_back.Link", "Geri Dön" },
                    { 46, true, 1, "Employees.Edit.Submit_and_return_list.Button", "Kaydet ve Listeye Dön" },
                    { 47, true, 1, "Employees.Edit.Return_list.Link", "Listeye Dön" },
                    { 48, true, 1, "Employees.Details.Title", "{0}" },
                    { 49, true, 1, "Employees.Details.Heading", "{0}" },
                    { 50, true, 1, "Languages.List.Title", "Diller" },
                    { 51, true, 1, "Languages.List.Heading", "Diller" },
                    { 52, true, 1, "Languages.List.No_languages", "Dil yok." },
                    { 53, true, 1, "Languages.List.Th_culture", "KÜLTÜR KODU" },
                    { 54, true, 1, "Languages.List.StringResources.Link", "Çeviriler" },
                    { 55, true, 1, "Languages.List.Details.Link", "İncele" },
                    { 56, true, 1, "Languages.List.Edit.Link", "Düzenle" },
                    { 57, true, 1, "Languages.List.Delete.Link", "Sil" },
                    { 58, true, 1, "Languages.Create.Title", "Dil Ekle" },
                    { 59, true, 1, "Languages.Create.Heading", "Dil Ekle" },
                    { 60, true, 1, "Languages.Create.Submit.Button", "Ekle" },
                    { 61, true, 1, "Languages.Create.Submit_and_return_list.Button", "Ekle ve Listeye Dön" },
                    { 62, true, 1, "Languages.Create.Return_list.Link", "Listeye Dön" },
                    { 63, true, 1, "Languages.Details.Title", "{0}" },
                    { 64, true, 1, "Languages.Details.Heading", "{0}" },
                    { 65, true, 1, "Languages.Edit.Title", "Dili Düzenle" },
                    { 66, true, 1, "Languages.Edit.Heading", "Dili Düzenle" },
                    { 67, true, 1, "Languages.Edit.Submit.Button", "Kaydet" },
                    { 68, true, 1, "Languages.Edit.Submit_and_go_back.Button", "Kaydet ve Geri Dön" },
                    { 69, true, 1, "Languages.Edit.Go_back.Link", "Geri Dön" },
                    { 70, true, 1, "Languages.Edit.Submit_and_return_list.Button", "Kaydet ve Listeye Dön" },
                    { 71, true, 1, "Languages.Edit.Return_list.Link", "Listeye Dön" },
                    { 72, true, 1, "StringResources.List.Title", "Çeviriler" },
                    { 73, true, 1, "StringResources.List.Heading", "Çeviriler" },
                    { 74, true, 1, "StringResources.List.No_resources", "Çeviri yok." },
                    { 75, true, 1, "StringResources.List.Th_name", "ADI" },
                    { 76, true, 1, "StringResources.List.Th_value", "ÇEVİRİ" },
                    { 77, true, 1, "StringResources.List.Th_is_approved", "DURUMU" },
                    { 78, true, 1, "StringResources.List.Approved", "Onaylı" },
                    { 79, true, 1, "StringResources.List.Unapproved", "Onaysız" },
                    { 80, true, 1, "StringResources.List.Details.Link", "İncele" },
                    { 81, true, 1, "StringResources.List.Edit.Link", "Düzenle" },
                    { 82, true, 1, "StringResources.List.Delete.Link", "Sil" },
                    { 83, true, 1, "StringResources.Edit.Title", "Çeviriyi Düzenle" },
                    { 84, true, 1, "StringResources.Edit.Heading", "Çeviriyi Düzenle" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "IsApproved", "LanguageId", "Name", "Value" },
                values: new object[,]
                {
                    { 85, true, 1, "StringResources.Edit.Submit.Button", "Kaydet" },
                    { 86, true, 1, "StringResources.Edit.Submit_and_go_back.Button", "Kaydet ve Geri Dön" },
                    { 87, true, 1, "StringResources.Edit.Go_back.Link", "Geri Dön" },
                    { 88, true, 1, "StringResources.Edit.Submit_and_return_list.Button", "Kaydet ve Listeye Dön" },
                    { 89, true, 1, "StringResources.Edit.Return_list.Link", "Listeye Dön" },
                    { 90, true, 1, "StringResources.Details.Title", "Çeviri Detayları" },
                    { 91, true, 1, "StringResources.Details.Heading", "Çeviri Detayları" },
                    { 92, true, 1, "StringResources.Create.Title", "Çalışan Ekle" },
                    { 93, true, 1, "StringResources.Create.Heading", "Çalışan Ekle" },
                    { 94, true, 1, "StringResources.Create.Submit.Button", "Ekle" },
                    { 95, true, 1, "StringResources.Create.Submit_and_return_list.Button", "Ekle ve Listeye Dön" },
                    { 96, true, 1, "StringResources.Create.Return_list.Link", "Listeye Dön" },
                    { 97, true, 2, "Navbar.Home.Index.Link", "Home" },
                    { 98, true, 2, "Navbar.Employees.List.Link", "Employees" },
                    { 99, true, 2, "Navbar.Languages.List.Link", "Languages" },
                    { 100, true, 2, "Submenu.Employees.Create.Button", "Add New" },
                    { 101, true, 2, "Submenu.Employees.List.Button", "Back To List" },
                    { 102, true, 2, "Submenu.Employees.Edit.Button", "Edit" },
                    { 103, true, 2, "Submenu.Employees.Delete.Button", "Delete" },
                    { 104, true, 2, "Submenu.Employees.Details.Button", "Details" },
                    { 105, true, 2, "Submenu.Languages.Create.Button", "Add New" },
                    { 106, true, 2, "Submenu.Languages.List.Button", "Back To List" },
                    { 107, true, 2, "Submenu.Languages.Edit.Button", "Edit" },
                    { 108, true, 2, "Submenu.Languages.Delete.Button", "Delete" },
                    { 109, true, 2, "Submenu.StringResources.Create.Button", "Add New" },
                    { 110, true, 2, "Submenu.StringResources.List.Button", "Back To List" },
                    { 111, true, 2, "Submenu.StringResources.Edit.Button", "Edit" },
                    { 112, true, 2, "Submenu.StringResources.Delete.Button", "Delete" },
                    { 113, true, 2, "Breadcrumb.Home.Index", "Home" },
                    { 114, true, 2, "Breadcrumb.Employees.Create", "Add New" },
                    { 115, true, 2, "Breadcrumb.Employees.List", "Employees" },
                    { 116, true, 2, "Breadcrumb.Employees.Details", "{0}" },
                    { 117, true, 2, "Breadcrumb.Employees.Edit", "Edit" },
                    { 118, true, 2, "Breadcrumb.Languages.Create", "Add New" },
                    { 119, true, 2, "Breadcrumb.Languages.List", "Languages" },
                    { 120, true, 2, "Breadcrumb.Languages.Details", "{0}" },
                    { 121, true, 2, "Breadcrumb.Languages.Edit", "Edit" },
                    { 122, true, 2, "Breadcrumb.StringResources.Create", "Add New" },
                    { 123, true, 2, "Breadcrumb.StringResources.List", "String Resources" },
                    { 124, true, 2, "Breadcrumb.StringResources.Details", "{0}" },
                    { 125, true, 2, "Breadcrumb.StringResources.Edit", "Edit" },
                    { 126, true, 2, "Employees.List.Title", "Employees" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "IsApproved", "LanguageId", "Name", "Value" },
                values: new object[,]
                {
                    { 127, true, 2, "Employees.List.Heading", "Employees" },
                    { 128, true, 2, "Employees.List.No_employees", "No employees." },
                    { 129, true, 2, "Employees.List.Th_name", "NAME" },
                    { 130, true, 2, "Employees.List.Details.Link", "Details" },
                    { 131, true, 2, "Employees.List.Edit.Link", "Edit" },
                    { 132, true, 2, "Employees.List.Delete.Link", "Delete" },
                    { 133, true, 2, "Employees.Create.Title", "New Employee" },
                    { 134, true, 2, "Employees.Create.Heading", "New Employee" },
                    { 135, true, 2, "Employees.Create.Submit.Button", "Save" },
                    { 136, true, 2, "Employees.Create.Submit_and_return_list.Button", "Save and Back To List" },
                    { 137, true, 2, "Employees.Create.Return_list.Link", "Back To List" },
                    { 138, true, 2, "Employees.Edit.Title", "Edit Employee" },
                    { 139, true, 2, "Employees.Edit.Heading", "Edit Employee" },
                    { 140, true, 2, "Employees.Edit.Submit.Button", "Save" },
                    { 141, true, 2, "Employees.Edit.Submit_and_go_back.Button", "Save and Go Back" },
                    { 142, true, 2, "Employees.Edit.Go_back.Link", "Go Back" },
                    { 143, true, 2, "Employees.Edit.Submit_and_return_list.Button", "Save and Back To List" },
                    { 144, true, 2, "Employees.Edit.Return_list.Link", "Back To List" },
                    { 145, true, 2, "Employees.Details.Title", "{0}" },
                    { 146, true, 2, "Employees.Details.Heading", "{0}" },
                    { 147, true, 2, "Languages.List.Title", "Languages" },
                    { 148, true, 2, "Languages.List.Heading", "Languages" },
                    { 149, true, 2, "Languages.List.No_languages", "No languages." },
                    { 150, true, 2, "Languages.List.Th_culture", "CULTURE" },
                    { 151, true, 2, "Languages.List.StringResources.Link", "String Resources" },
                    { 152, true, 2, "Languages.List.Details.Link", "Details" },
                    { 153, true, 2, "Languages.List.Edit.Link", "Edit" },
                    { 154, true, 2, "Languages.List.Delete.Link", "Delete" },
                    { 155, true, 2, "Languages.Create.Title", "New Language" },
                    { 156, true, 2, "Languages.Create.Heading", "New Language" },
                    { 157, true, 2, "Languages.Create.Submit.Button", "Save" },
                    { 158, true, 2, "Languages.Create.Submit_and_return_list.Button", "Save and Back To List" },
                    { 159, true, 2, "Languages.Create.Return_list.Link", "Back To List" },
                    { 160, true, 2, "Languages.Details.Title", "{0}" },
                    { 161, true, 2, "Languages.Details.Heading", "{0}" },
                    { 162, true, 2, "Languages.Edit.Title", "Edit Language" },
                    { 163, true, 2, "Languages.Edit.Heading", "Edit Language" },
                    { 164, true, 2, "Languages.Edit.Submit.Button", "Save" },
                    { 165, true, 2, "Languages.Edit.Submit_and_go_back.Button", "Save and Go Back" },
                    { 166, true, 2, "Languages.Edit.Go_back.Link", "Go Back" },
                    { 167, true, 2, "Languages.Edit.Submit_and_return_list.Button", "Save and Back To List" },
                    { 168, true, 2, "Languages.Edit.Return_list.Link", "Back To List" }
                });

            migrationBuilder.InsertData(
                table: "StringResources",
                columns: new[] { "Id", "IsApproved", "LanguageId", "Name", "Value" },
                values: new object[,]
                {
                    { 169, true, 2, "StringResources.List.Title", "String Resources" },
                    { 170, true, 2, "StringResources.List.Heading", "String Resources" },
                    { 171, true, 2, "StringResources.List.No_resources", "No string resources." },
                    { 172, true, 2, "StringResources.List.Th_name", "NAME" },
                    { 173, true, 2, "StringResources.List.Th_value", "VALUE" },
                    { 174, true, 2, "StringResources.List.Th_is_approved", "STATUS" },
                    { 175, true, 2, "StringResources.List.Approved", "Approved" },
                    { 176, true, 2, "StringResources.List.Unapproved", "Unapproved" },
                    { 177, true, 2, "StringResources.List.Details.Link", "Details" },
                    { 178, true, 2, "StringResources.List.Edit.Link", "Edit" },
                    { 179, true, 2, "StringResources.List.Delete.Link", "Delete" },
                    { 180, true, 2, "StringResources.Edit.Title", "Edit String Resource" },
                    { 181, true, 2, "StringResources.Edit.Heading", "Edit String Resource" },
                    { 182, true, 2, "StringResources.Edit.Submit.Button", "Save" },
                    { 183, true, 2, "StringResources.Edit.Submit_and_go_back.Button", "Save and Go Back" },
                    { 184, true, 2, "StringResources.Edit.Go_back.Link", "Go Back" },
                    { 185, true, 2, "StringResources.Edit.Submit_and_return_list.Button", "Save and Back To List" },
                    { 186, true, 2, "StringResources.Edit.Return_list.Link", "Back To List" },
                    { 187, true, 2, "StringResources.Details.Title", "Details" },
                    { 188, true, 2, "StringResources.Details.Heading", "Details" },
                    { 189, true, 2, "StringResources.Create.Title", "New String Resource" },
                    { 190, true, 2, "StringResources.Create.Heading", "New String Resource" },
                    { 191, true, 2, "StringResources.Create.Submit.Button", "Save" },
                    { 192, true, 2, "StringResources.Create.Submit_and_return_list.Button", "Save and Back To List" },
                    { 193, true, 2, "StringResources.Create.Return_list.Link", "Back To List" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StringResources_LanguageId",
                table: "StringResources",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "StringResources");

            migrationBuilder.DropTable(
                name: "Languages");
        }
    }
}
