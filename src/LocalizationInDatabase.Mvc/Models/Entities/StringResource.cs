using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LocalizationInDatabase.Mvc.Models.Entities;

public class StringResource
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int LanguageId { get; set; }
    public Language Language { get; set; } = null!;

    [StringLength(500)]
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Value { get; set; } = null!;

    [Required]
    public bool IsApproved { get; set; }
}

public class StringResourceConfiguration : IEntityTypeConfiguration<StringResource>
{
    public void Configure(EntityTypeBuilder<StringResource> builder)
    {
        var stringResources = new StringResource[] {
            // Navbars
            new StringResource { Id = 1, LanguageId = 1, IsApproved = true, Name = "Navbar.Home.Index.Link", Value = "Ana Sayfa" },
            new StringResource { Id = 2, LanguageId = 1, IsApproved = true, Name = "Navbar.Employees.List.Link", Value = "Çalışanlar" },
            new StringResource { Id = 3, LanguageId = 1, IsApproved = true, Name = "Navbar.Languages.List.Link", Value = "Diller" },
            // Submenus
            new StringResource { Id = 4, LanguageId = 1, IsApproved = true, Name = "Submenu.Employees.Create.Button", Value = "Ekle" },
            new StringResource { Id = 5, LanguageId = 1, IsApproved = true, Name = "Submenu.Employees.List.Button", Value = "Listeye Dön" },
            new StringResource { Id = 6, LanguageId = 1, IsApproved = true, Name = "Submenu.Employees.Edit.Button", Value = "Düzenle" },
            new StringResource { Id = 7, LanguageId = 1, IsApproved = true, Name = "Submenu.Employees.Delete.Button", Value = "Sil" },
            new StringResource { Id = 8, LanguageId = 1, IsApproved = true, Name = "Submenu.Languages.Create.Button", Value = "Ekle" },
            new StringResource { Id = 9, LanguageId = 1, IsApproved = true, Name = "Submenu.Languages.List.Button", Value = "Listeye Dön" },
            new StringResource { Id = 10, LanguageId = 1, IsApproved = true, Name = "Submenu.Languages.Edit.Button", Value = "Düzenle" },
            new StringResource { Id = 11, LanguageId = 1, IsApproved = true, Name = "Submenu.Languages.Delete.Button", Value = "Sil" },
            new StringResource { Id = 12, LanguageId = 1, IsApproved = true, Name = "Submenu.StringResources.Create.Button", Value = "Ekle" },
            new StringResource { Id = 13, LanguageId = 1, IsApproved = true, Name = "Submenu.StringResources.List.Button", Value = "Listeye Dön" },
            new StringResource { Id = 14, LanguageId = 1, IsApproved = true, Name = "Submenu.StringResources.Edit.Button", Value = "Düzenle" },
            new StringResource { Id = 15, LanguageId = 1, IsApproved = true, Name = "Submenu.StringResources.Delete.Button", Value = "Sil" },
            // Breadcrumbs
            new StringResource { Id = 16, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Home.Index", Value = "Ana Sayfa" },
            new StringResource { Id = 17, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Employees.Create", Value = "Ekle" },
            new StringResource { Id = 18, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Employees.List", Value = "Çalışanlar" },
            new StringResource { Id = 19, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Employees.Details", Value = "{0}" },
            new StringResource { Id = 20, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Employees.Edit", Value = "Düzenle" },
            new StringResource { Id = 21, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Languages.Create", Value = "Ekle" },
            new StringResource { Id = 22, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Languages.List", Value = "Diller" },
            new StringResource { Id = 23, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Languages.Details", Value = "{0}" },
            new StringResource { Id = 24, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.Languages.Edit", Value = "Düzenle" },
            new StringResource { Id = 25, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.StringResources.Create", Value = "Ekle" },
            new StringResource { Id = 26, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.StringResources.List", Value = "Çeviriler" },
            new StringResource { Id = 27, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.StringResources.Details", Value = "{0}" },
            new StringResource { Id = 28, LanguageId = 1, IsApproved = true, Name = "Breadcrumb.StringResources.Edit", Value = "Düzenle" },
            // Employee list
            new StringResource { Id = 29, LanguageId = 1, IsApproved = true, Name = "Employees.List.Title", Value = "Çalışanlar" },
            new StringResource { Id = 30, LanguageId = 1, IsApproved = true, Name = "Employees.List.Heading", Value = "Çalışanlar" },
            new StringResource { Id = 31, LanguageId = 1, IsApproved = true, Name = "Employees.List.No_employees", Value = "Çalışan yok." },
            new StringResource { Id = 32, LanguageId = 1, IsApproved = true, Name = "Employees.List.Th_name", Value = "ADI" },
            new StringResource { Id = 33, LanguageId = 1, IsApproved = true, Name = "Employees.List.Details.Link", Value = "İncele" },
            new StringResource { Id = 34, LanguageId = 1, IsApproved = true, Name = "Employees.List.Edit.Link", Value = "Düzenle" },
            new StringResource { Id = 35, LanguageId = 1, IsApproved = true, Name = "Employees.List.Delete.Link", Value = "Sil" },
            // Create employee
            new StringResource { Id = 36, LanguageId = 1, IsApproved = true, Name = "Employees.Create.Title", Value = "Çalışan Ekle" },
            new StringResource { Id = 37, LanguageId = 1, IsApproved = true, Name = "Employees.Create.Heading", Value = "Çalışan Ekle" },
            new StringResource { Id = 38, LanguageId = 1, IsApproved = true, Name = "Employees.Create.Submit.Button", Value = "Ekle" },
            new StringResource { Id = 39, LanguageId = 1, IsApproved = true, Name = "Employees.Create.Submit_and_return_list.Button", Value = "Ekle ve Listeye Dön" },
            new StringResource { Id = 40, LanguageId = 1, IsApproved = true, Name = "Employees.Create.Return_list.Link", Value = "Listeye Dön" },
            // Edit employee
            new StringResource { Id = 41, LanguageId = 1, IsApproved = true, Name = "Employees.Edit.Title", Value = "Çalışanı Düzenle" },
            new StringResource { Id = 42, LanguageId = 1, IsApproved = true, Name = "Employees.Edit.Heading", Value = "Çalışanı Düzenle" },
            new StringResource { Id = 43, LanguageId = 1, IsApproved = true, Name = "Employees.Edit.Submit.Button", Value = "Kaydet" },
            new StringResource { Id = 44, LanguageId = 1, IsApproved = true, Name = "Employees.Edit.Submit_and_go_back.Button", Value = "Kaydet ve Geri Dön" },
            new StringResource { Id = 45, LanguageId = 1, IsApproved = true, Name = "Employees.Edit.Go_back.Link", Value = "Geri Dön" },
            new StringResource { Id = 46, LanguageId = 1, IsApproved = true, Name = "Employees.Edit.Submit_and_return_list.Button", Value = "Kaydet ve Listeye Dön" },
            new StringResource { Id = 47, LanguageId = 1, IsApproved = true, Name = "Employees.Edit.Return_list.Link", Value = "Listeye Dön" },
            // Employee details
            new StringResource { Id = 48, LanguageId = 1, IsApproved = true, Name = "Employees.Details.Title", Value = "{0}" },
            new StringResource { Id = 49, LanguageId = 1, IsApproved = true, Name = "Employees.Details.Heading", Value = "{0}" },
            // Language list
            new StringResource { Id = 50, LanguageId = 1, IsApproved = true, Name = "Languages.List.Title", Value = "Diller" },
            new StringResource { Id = 51, LanguageId = 1, IsApproved = true, Name = "Languages.List.Heading", Value = "Diller" },
            new StringResource { Id = 52, LanguageId = 1, IsApproved = true, Name = "Languages.List.No_languages", Value = "Dil yok." },
            new StringResource { Id = 53, LanguageId = 1, IsApproved = true, Name = "Languages.List.Th_culture", Value = "KÜLTÜR KODU" },
            new StringResource { Id = 54, LanguageId = 1, IsApproved = true, Name = "Languages.List.StringResources.Link", Value = "Çeviriler" },
            new StringResource { Id = 55, LanguageId = 1, IsApproved = true, Name = "Languages.List.Details.Link", Value = "İncele" },
            new StringResource { Id = 56, LanguageId = 1, IsApproved = true, Name = "Languages.List.Edit.Link", Value = "Düzenle" },
            new StringResource { Id = 57, LanguageId = 1, IsApproved = true, Name = "Languages.List.Delete.Link", Value = "Sil" },
            // Create language
            new StringResource { Id = 58, LanguageId = 1, IsApproved = true, Name = "Languages.Create.Title", Value = "Dil Ekle" },
            new StringResource { Id = 59, LanguageId = 1, IsApproved = true, Name = "Languages.Create.Heading", Value = "Dil Ekle" },
            new StringResource { Id = 60, LanguageId = 1, IsApproved = true, Name = "Languages.Create.Submit.Button", Value = "Ekle" },
            new StringResource { Id = 61, LanguageId = 1, IsApproved = true, Name = "Languages.Create.Submit_and_return_list.Button", Value = "Ekle ve Listeye Dön" },
            new StringResource { Id = 62, LanguageId = 1, IsApproved = true, Name = "Languages.Create.Return_list.Link", Value = "Listeye Dön" },
            // Language details
            new StringResource { Id = 63, LanguageId = 1, IsApproved = true, Name = "Languages.Details.Title", Value = "{0}" },
            new StringResource { Id = 64, LanguageId = 1, IsApproved = true, Name = "Languages.Details.Heading", Value = "{0}" },
            // Edit language
            new StringResource { Id = 65, LanguageId = 1, IsApproved = true, Name = "Languages.Edit.Title", Value = "Dili Düzenle" },
            new StringResource { Id = 66, LanguageId = 1, IsApproved = true, Name = "Languages.Edit.Heading", Value = "Dili Düzenle" },
            new StringResource { Id = 67, LanguageId = 1, IsApproved = true, Name = "Languages.Edit.Submit.Button", Value = "Kaydet" },
            new StringResource { Id = 68, LanguageId = 1, IsApproved = true, Name = "Languages.Edit.Submit_and_go_back.Button", Value = "Kaydet ve Geri Dön" },
            new StringResource { Id = 69, LanguageId = 1, IsApproved = true, Name = "Languages.Edit.Go_back.Link", Value = "Geri Dön" },
            new StringResource { Id = 70, LanguageId = 1, IsApproved = true, Name = "Languages.Edit.Submit_and_return_list.Button", Value = "Kaydet ve Listeye Dön" },
            new StringResource { Id = 71, LanguageId = 1, IsApproved = true, Name = "Languages.Edit.Return_list.Link", Value = "Listeye Dön" },
            // String resources list
            new StringResource { Id = 72, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Title", Value = "Çeviriler" },
            new StringResource { Id = 73, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Heading", Value = "Çeviriler" },
            new StringResource { Id = 74, LanguageId = 1, IsApproved = true, Name = "StringResources.List.No_resources", Value = "Çeviri yok." },
            new StringResource { Id = 75, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Th_name", Value = "ADI" },
            new StringResource { Id = 76, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Th_value", Value = "ÇEVİRİ" },
            new StringResource { Id = 77, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Th_is_approved", Value = "DURUMU" },
            new StringResource { Id = 78, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Approved", Value = "Onaylı" },
            new StringResource { Id = 79, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Unapproved", Value = "Onaysız" },
            new StringResource { Id = 80, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Details.Link", Value = "İncele" },
            new StringResource { Id = 81, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Edit.Link", Value = "Düzenle" },
            new StringResource { Id = 82, LanguageId = 1, IsApproved = true, Name = "StringResources.List.Delete.Link", Value = "Sil" },
            // Edit string resource
            new StringResource { Id = 83, LanguageId = 1, IsApproved = true, Name = "StringResources.Edit.Title", Value = "Çeviriyi Düzenle" },
            new StringResource { Id = 84, LanguageId = 1, IsApproved = true, Name = "StringResources.Edit.Heading", Value = "Çeviriyi Düzenle" },
            new StringResource { Id = 85, LanguageId = 1, IsApproved = true, Name = "StringResources.Edit.Submit.Button", Value = "Kaydet" },
            new StringResource { Id = 86, LanguageId = 1, IsApproved = true, Name = "StringResources.Edit.Submit_and_go_back.Button", Value = "Kaydet ve Geri Dön" },
            new StringResource { Id = 87, LanguageId = 1, IsApproved = true, Name = "StringResources.Edit.Go_back.Link", Value = "Geri Dön" },
            new StringResource { Id = 88, LanguageId = 1, IsApproved = true, Name = "StringResources.Edit.Submit_and_return_list.Button", Value = "Kaydet ve Listeye Dön" },
            new StringResource { Id = 89, LanguageId = 1, IsApproved = true, Name = "StringResources.Edit.Return_list.Link", Value = "Listeye Dön" },
            // String resource details
            new StringResource { Id = 90, LanguageId = 1, IsApproved = true, Name = "StringResources.Details.Title", Value = "Çeviri Detayları" },
            new StringResource { Id = 91, LanguageId = 1, IsApproved = true, Name = "StringResources.Details.Heading", Value = "Çeviri Detayları" },
            // Create string resource
            new StringResource { Id = 92, LanguageId = 1, IsApproved = true, Name = "StringResources.Create.Title", Value = "Çalışan Ekle" },
            new StringResource { Id = 93, LanguageId = 1, IsApproved = true, Name = "StringResources.Create.Heading", Value = "Çalışan Ekle" },
            new StringResource { Id = 94, LanguageId = 1, IsApproved = true, Name = "StringResources.Create.Submit.Button", Value = "Ekle" },
            new StringResource { Id = 95, LanguageId = 1, IsApproved = true, Name = "StringResources.Create.Submit_and_return_list.Button", Value = "Ekle ve Listeye Dön" },
            new StringResource { Id = 96, LanguageId = 1, IsApproved = true, Name = "StringResources.Create.Return_list.Link", Value = "Listeye Dön" },
            
            
            
            
            // Navbars
            new StringResource { Id = 97, LanguageId = 2, IsApproved = true, Name = "Navbar.Home.Index.Link", Value = "Home" },
            new StringResource { Id = 98, LanguageId = 2, IsApproved = true, Name = "Navbar.Employees.List.Link", Value = "Employees" },
            new StringResource { Id = 99, LanguageId = 2, IsApproved = true, Name = "Navbar.Languages.List.Link", Value = "Languages" },
            // Submenus
            new StringResource { Id = 100, LanguageId = 2, IsApproved = true, Name = "Submenu.Employees.Create.Button", Value = "Add New" },
            new StringResource { Id = 101, LanguageId = 2, IsApproved = true, Name = "Submenu.Employees.List.Button", Value = "Back To List" },
            new StringResource { Id = 102, LanguageId = 2, IsApproved = true, Name = "Submenu.Employees.Edit.Button", Value = "Edit" },
            new StringResource { Id = 103, LanguageId = 2, IsApproved = true, Name = "Submenu.Employees.Delete.Button", Value = "Delete" },
            new StringResource { Id = 104, LanguageId = 2, IsApproved = true, Name = "Submenu.Employees.Details.Button", Value = "Details" },
            new StringResource { Id = 105, LanguageId = 2, IsApproved = true, Name = "Submenu.Languages.Create.Button", Value = "Add New" },
            new StringResource { Id = 106, LanguageId = 2, IsApproved = true, Name = "Submenu.Languages.List.Button", Value = "Back To List" },
            new StringResource { Id = 107, LanguageId = 2, IsApproved = true, Name = "Submenu.Languages.Edit.Button", Value = "Edit" },
            new StringResource { Id = 108, LanguageId = 2, IsApproved = true, Name = "Submenu.Languages.Delete.Button", Value = "Delete" },
            new StringResource { Id = 109, LanguageId = 2, IsApproved = true, Name = "Submenu.StringResources.Create.Button", Value = "Add New" },
            new StringResource { Id = 110, LanguageId = 2, IsApproved = true, Name = "Submenu.StringResources.List.Button", Value = "Back To List" },
            new StringResource { Id = 111, LanguageId = 2, IsApproved = true, Name = "Submenu.StringResources.Edit.Button", Value = "Edit" },
            new StringResource { Id = 112, LanguageId = 2, IsApproved = true, Name = "Submenu.StringResources.Delete.Button", Value = "Delete" },
            // Breadcrumbs
            new StringResource { Id = 113, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Home.Index", Value = "Home" },
            new StringResource { Id = 114, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Employees.Create", Value = "Add New" },
            new StringResource { Id = 115, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Employees.List", Value = "Employees" },
            new StringResource { Id = 116, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Employees.Details", Value = "{0}" },
            new StringResource { Id = 117, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Employees.Edit", Value = "Edit" },
            new StringResource { Id = 118, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Languages.Create", Value = "Add New" },
            new StringResource { Id = 119, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Languages.List", Value = "Languages" },
            new StringResource { Id = 120, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Languages.Details", Value = "{0}" },
            new StringResource { Id = 121, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.Languages.Edit", Value = "Edit" },
            new StringResource { Id = 122, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.StringResources.Create", Value = "Add New" },
            new StringResource { Id = 123, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.StringResources.List", Value = "String Resources" },
            new StringResource { Id = 124, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.StringResources.Details", Value = "{0}" },
            new StringResource { Id = 125, LanguageId = 2, IsApproved = true, Name = "Breadcrumb.StringResources.Edit", Value = "Edit" },
            // Employee list
            new StringResource { Id = 126, LanguageId = 2, IsApproved = true, Name = "Employees.List.Title", Value = "Employees" },
            new StringResource { Id = 127, LanguageId = 2, IsApproved = true, Name = "Employees.List.Heading", Value = "Employees" },
            new StringResource { Id = 128, LanguageId = 2, IsApproved = true, Name = "Employees.List.No_employees", Value = "No employees." },
            new StringResource { Id = 129, LanguageId = 2, IsApproved = true, Name = "Employees.List.Th_name", Value = "NAME" },
            new StringResource { Id = 130, LanguageId = 2, IsApproved = true, Name = "Employees.List.Details.Link", Value = "Details" },
            new StringResource { Id = 131, LanguageId = 2, IsApproved = true, Name = "Employees.List.Edit.Link", Value = "Edit" },
            new StringResource { Id = 132, LanguageId = 2, IsApproved = true, Name = "Employees.List.Delete.Link", Value = "Delete" },
            // Create employee
            new StringResource { Id = 133, LanguageId = 2, IsApproved = true, Name = "Employees.Create.Title", Value = "New Employee" },
            new StringResource { Id = 134, LanguageId = 2, IsApproved = true, Name = "Employees.Create.Heading", Value = "New Employee" },
            new StringResource { Id = 135, LanguageId = 2, IsApproved = true, Name = "Employees.Create.Submit.Button", Value = "Save" },
            new StringResource { Id = 136, LanguageId = 2, IsApproved = true, Name = "Employees.Create.Submit_and_return_list.Button", Value = "Save and Back To List" },
            new StringResource { Id = 137, LanguageId = 2, IsApproved = true, Name = "Employees.Create.Return_list.Link", Value = "Back To List" },
            // Edit employee
            new StringResource { Id = 138, LanguageId = 2, IsApproved = true, Name = "Employees.Edit.Title", Value = "Edit Employee" },
            new StringResource { Id = 139, LanguageId = 2, IsApproved = true, Name = "Employees.Edit.Heading", Value = "Edit Employee" },
            new StringResource { Id = 140, LanguageId = 2, IsApproved = true, Name = "Employees.Edit.Submit.Button", Value = "Save" },
            new StringResource { Id = 141, LanguageId = 2, IsApproved = true, Name = "Employees.Edit.Submit_and_go_back.Button", Value = "Save and Go Back" },
            new StringResource { Id = 142, LanguageId = 2, IsApproved = true, Name = "Employees.Edit.Go_back.Link", Value = "Go Back" },
            new StringResource { Id = 143, LanguageId = 2, IsApproved = true, Name = "Employees.Edit.Submit_and_return_list.Button", Value = "Save and Back To List" },
            new StringResource { Id = 144, LanguageId = 2, IsApproved = true, Name = "Employees.Edit.Return_list.Link", Value = "Back To List" },
            // Employee details
            new StringResource { Id = 145, LanguageId = 2, IsApproved = true, Name = "Employees.Details.Title", Value = "{0}" },
            new StringResource { Id = 146, LanguageId = 2, IsApproved = true, Name = "Employees.Details.Heading", Value = "{0}" },
            // Language list
            new StringResource { Id = 147, LanguageId = 2, IsApproved = true, Name = "Languages.List.Title", Value = "Languages" },
            new StringResource { Id = 148, LanguageId = 2, IsApproved = true, Name = "Languages.List.Heading", Value = "Languages" },
            new StringResource { Id = 149, LanguageId = 2, IsApproved = true, Name = "Languages.List.No_languages", Value = "No languages." },
            new StringResource { Id = 150, LanguageId = 2, IsApproved = true, Name = "Languages.List.Th_culture", Value = "CULTURE" },
            new StringResource { Id = 151, LanguageId = 2, IsApproved = true, Name = "Languages.List.StringResources.Link", Value = "String Resources" },
            new StringResource { Id = 152, LanguageId = 2, IsApproved = true, Name = "Languages.List.Details.Link", Value = "Details" },
            new StringResource { Id = 153, LanguageId = 2, IsApproved = true, Name = "Languages.List.Edit.Link", Value = "Edit" },
            new StringResource { Id = 154, LanguageId = 2, IsApproved = true, Name = "Languages.List.Delete.Link", Value = "Delete" },
            // Create language
            new StringResource { Id = 155, LanguageId = 2, IsApproved = true, Name = "Languages.Create.Title", Value = "New Language" },
            new StringResource { Id = 156, LanguageId = 2, IsApproved = true, Name = "Languages.Create.Heading", Value = "New Language" },
            new StringResource { Id = 157, LanguageId = 2, IsApproved = true, Name = "Languages.Create.Submit.Button", Value = "Save" },
            new StringResource { Id = 158, LanguageId = 2, IsApproved = true, Name = "Languages.Create.Submit_and_return_list.Button", Value = "Save and Back To List" },
            new StringResource { Id = 159, LanguageId = 2, IsApproved = true, Name = "Languages.Create.Return_list.Link", Value = "Back To List" },
            // Language details
            new StringResource { Id = 160, LanguageId = 2, IsApproved = true, Name = "Languages.Details.Title", Value = "{0}" },
            new StringResource { Id = 161, LanguageId = 2, IsApproved = true, Name = "Languages.Details.Heading", Value = "{0}" },
            // Edit language
            new StringResource { Id = 162, LanguageId = 2, IsApproved = true, Name = "Languages.Edit.Title", Value = "Edit Language" },
            new StringResource { Id = 163, LanguageId = 2, IsApproved = true, Name = "Languages.Edit.Heading", Value = "Edit Language" },
            new StringResource { Id = 164, LanguageId = 2, IsApproved = true, Name = "Languages.Edit.Submit.Button", Value = "Save" },
            new StringResource { Id = 165, LanguageId = 2, IsApproved = true, Name = "Languages.Edit.Submit_and_go_back.Button", Value = "Save and Go Back" },
            new StringResource { Id = 166, LanguageId = 2, IsApproved = true, Name = "Languages.Edit.Go_back.Link", Value = "Go Back" },
            new StringResource { Id = 167, LanguageId = 2, IsApproved = true, Name = "Languages.Edit.Submit_and_return_list.Button", Value = "Save and Back To List" },
            new StringResource { Id = 168, LanguageId = 2, IsApproved = true, Name = "Languages.Edit.Return_list.Link", Value = "Back To List" },
            // String resources list
            new StringResource { Id = 169, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Title", Value = "String Resources" },
            new StringResource { Id = 170, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Heading", Value = "String Resources" },
            new StringResource { Id = 171, LanguageId = 2, IsApproved = true, Name = "StringResources.List.No_resources", Value = "No string resources." },
            new StringResource { Id = 172, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Th_name", Value = "NAME" },
            new StringResource { Id = 173, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Th_value", Value = "VALUE" },
            new StringResource { Id = 174, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Th_is_approved", Value = "STATUS" },
            new StringResource { Id = 175, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Approved", Value = "Approved" },
            new StringResource { Id = 176, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Unapproved", Value = "Unapproved" },
            new StringResource { Id = 177, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Details.Link", Value = "Details" },
            new StringResource { Id = 178, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Edit.Link", Value = "Edit" },
            new StringResource { Id = 179, LanguageId = 2, IsApproved = true, Name = "StringResources.List.Delete.Link", Value = "Delete" },
            // Edit string resource
            new StringResource { Id = 180, LanguageId = 2, IsApproved = true, Name = "StringResources.Edit.Title", Value = "Edit String Resource" },
            new StringResource { Id = 181, LanguageId = 2, IsApproved = true, Name = "StringResources.Edit.Heading", Value = "Edit String Resource" },
            new StringResource { Id = 182, LanguageId = 2, IsApproved = true, Name = "StringResources.Edit.Submit.Button", Value = "Save" },
            new StringResource { Id = 183, LanguageId = 2, IsApproved = true, Name = "StringResources.Edit.Submit_and_go_back.Button", Value = "Save and Go Back" },
            new StringResource { Id = 184, LanguageId = 2, IsApproved = true, Name = "StringResources.Edit.Go_back.Link", Value = "Go Back" },
            new StringResource { Id = 185, LanguageId = 2, IsApproved = true, Name = "StringResources.Edit.Submit_and_return_list.Button", Value = "Save and Back To List" },
            new StringResource { Id = 186, LanguageId = 2, IsApproved = true, Name = "StringResources.Edit.Return_list.Link", Value = "Back To List" },
            // String resource details
            new StringResource { Id = 187, LanguageId = 2, IsApproved = true, Name = "StringResources.Details.Title", Value = "Details" },
            new StringResource { Id = 188, LanguageId = 2, IsApproved = true, Name = "StringResources.Details.Heading", Value = "Details" },
            // Create string resource
            new StringResource { Id = 189, LanguageId = 2, IsApproved = true, Name = "StringResources.Create.Title", Value = "New String Resource" },
            new StringResource { Id = 190, LanguageId = 2, IsApproved = true, Name = "StringResources.Create.Heading", Value = "New String Resource" },
            new StringResource { Id = 191, LanguageId = 2, IsApproved = true, Name = "StringResources.Create.Submit.Button", Value = "Save" },
            new StringResource { Id = 192, LanguageId = 2, IsApproved = true, Name = "StringResources.Create.Submit_and_return_list.Button", Value = "Save and Back To List" },
            new StringResource { Id = 193, LanguageId = 2, IsApproved = true, Name = "StringResources.Create.Return_list.Link", Value = "Back To List" },

            new StringResource { Id = 194, LanguageId = 1, IsApproved = true, Name = "Languages.List.Th_name", Value = "ADI" },
            new StringResource { Id = 195, LanguageId = 2, IsApproved = true, Name = "Languages.List.Th_name", Value = "NAME" },
        };

        builder.HasData(stringResources);
    }
}
