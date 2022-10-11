﻿using System.ComponentModel.DataAnnotations;

namespace LocalizationInDatabase.Mvc.ViewModels;

public class LanguageViewModel
{
    public int Id { get; private set; }

    [Display(Name = "Culture")]
    [MaxLength(15)]
    public string Culture { get; set; } = null!;

    public string? SubmitButton { get; set; }
}
