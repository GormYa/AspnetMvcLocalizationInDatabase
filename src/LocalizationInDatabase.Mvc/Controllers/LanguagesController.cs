using AutoMapper;
using LocalizationInDatabase.Mvc.Models.Entities;
using LocalizationInDatabase.Mvc.Services.EntityServices;
using LocalizationInDatabase.Mvc.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LocalizationInDatabase.Mvc.Controllers;

public class LanguagesController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;
    private readonly IStringResourceService _stringResourceService;

    public LanguagesController(IMapper mapper, ILanguageService languageService, IStringResourceService stringResourceService)
    {
        _mapper = mapper;
        _languageService = languageService;
        _stringResourceService = stringResourceService;
    }

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(LanguageViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var language = await _languageService.GetAsync(l => l.Culture.Equals(model.Culture));
        if (language == null)
        {
            var entity = _mapper.Map<Language>(model);
            await _languageService.AddAsync(entity);

            var defaultLanguage = await _languageService.GetAsync(l => l.Culture.Equals("tr-TR"));
            if (defaultLanguage != null)
            {
                var stringResources = await _stringResourceService.ListAsync(s => s.LanguageId.Equals(defaultLanguage.Id));
                if (stringResources != null && stringResources.Any())
                {
                    var newStringResources = stringResources.Select(s => new StringResource()
                    {
                        LanguageId = entity.Id,
                        Name = s.Name,
                        Value = s.Value,
                        IsApproved = s.IsApproved
                    }).ToList();

                    await _stringResourceService.AddRangeAsync(newStringResources);
                }
            }
        }

        if (model.SubmitButton == "redirect")
        {
            return RedirectToAction("List");
        }
        else
        {
            return RedirectToAction("Create");
        }
    }
    #endregion

    #region Read
    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var entities = await _languageService.ListAsync();
        var model = _mapper.Map<List<LanguageViewModel>>(entities);

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> DetailsAsync(int id)
    {
        var entity = await _languageService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<LanguageViewModel>(entity);

        return View(model);
    }
    #endregion

    #region Update
    [HttpGet]
    public async Task<IActionResult> EditAsync(int id, string? returnUrl)
    {
        var entity = await _languageService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<LanguageEditModel>(entity);

        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAsync(int id, LanguageEditModel model, string? returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var culture = await _languageService.GetAsync(e => e.Culture.Equals(model.Culture) && !e.Id.Equals(id));
        if (culture == null)
        {
            var entity = await _languageService.GetAsync(e => e.Id.Equals(id));
            if (entity == null)
            {
                return NotFound();
            }

            entity = _mapper.Map(model, entity);
            await _languageService.UpdateAsync(entity);
        }

        if (model.SubmitButton == "redirect")
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("List");
            }
            else
            {
                return Redirect(returnUrl);
            }
        }
        else
        {
            return RedirectToAction("Edit", new { Id = id, returnUrl });
        }
    }
    #endregion

    #region Delete
    [HttpGet]
    public async Task<IActionResult> DeleteAsync(int id, string? returnUrl)
    {
        var entity = await _languageService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        await _languageService.DeleteAsync(entity);

        return string.IsNullOrEmpty(returnUrl) ? RedirectToAction("List") : Redirect(returnUrl);
    }
    #endregion

    [HttpPost, ValidateAntiForgeryToken]
    public IActionResult ChangeLanguage(string cultureCode, string? returnUrl)
    {
        var language = _languageService.GetLanguageByCulture(cultureCode);

        if (language != null)
        {
            var cookieName = CookieRequestCultureProvider.DefaultCookieName;
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(language.Culture, language.Culture));
            var cookieOptions = new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1), SameSite = SameSiteMode.Strict };

            Response.Cookies.Append(cookieName, cookieValue, cookieOptions);
        }

        return string.IsNullOrEmpty(returnUrl) ? RedirectToAction("List") : Redirect(returnUrl);
    }
}
