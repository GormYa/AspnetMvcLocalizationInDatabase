using System.ComponentModel.DataAnnotations;

namespace LocalizationInDatabase.Mvc.ViewModels;

public class StringResourceViewModel
{
    public int Id { get; private set; }

    public int LanguageId { get; set; }
    public LanguageViewModel Language { get; set; } = null!;

    [Display(Name = "Name")]
    [StringLength(500)]
    public string Name { get; set; } = null!;

    [Display(Name = "Value")]
    public string Value { get; set; } = null!;

    [Display(Name = "Approved?")]
    public bool IsApproved { get; set; }

    public string? SubmitButton { get; set; }
}
