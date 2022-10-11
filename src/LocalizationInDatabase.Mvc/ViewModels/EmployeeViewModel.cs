using System.ComponentModel.DataAnnotations;

namespace LocalizationInDatabase.Mvc.ViewModels;

public class EmployeeViewModel
{
    public Guid Id { get; private set; }

    [Display(Name = "Name")]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public string? SubmitButton { get; set; }
}
