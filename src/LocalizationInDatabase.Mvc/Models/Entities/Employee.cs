using System.ComponentModel.DataAnnotations;

namespace LocalizationInDatabase.Mvc.Models.Entities;

public class Employee
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(50)]
    [Required]
    public string Name { get; set; } = null!;
}
