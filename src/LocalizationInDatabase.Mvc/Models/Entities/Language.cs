using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace LocalizationInDatabase.Mvc.Models.Entities;

public class Language
{
    [Key]
    public int Id { get; set; }

    [StringLength(15)]
    [Required]
    public string Culture { get; set; } = null!;

    public ICollection<StringResource> StringResources { get; set; } = null!;
}

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        var languages = new Language[] {
            new Language { Id = 1, Culture = "tr-TR" },
            new Language { Id = 2, Culture = "en-US" }
        };

        builder.HasData(languages);
    }
}
