using System.ComponentModel.DataAnnotations;

namespace LocalizationInDatabase.Mvc.ViewModels;

public class StringResourceEditModel
{
    public int LanguageId { get; set; }

    [Display(Name = "Name")]
    [MaxLength(500)]
    public string Name { get; set; } = null!;

    [Display(Name = "Value")]
    public string Value { get; set; } = null!;

    [Display(Name = "Approved?")]
    public bool IsApproved { get; set; }

    public string? SubmitButton { get; set; }
}
