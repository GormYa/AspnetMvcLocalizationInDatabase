using System.ComponentModel.DataAnnotations;

namespace LocalizationInDatabase.Mvc.ViewModels;

public class EmployeeEditModel
{
    [Display(Name = "Name")]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public string? SubmitButton { get; set; }
}
