using AutoMapper;
using LocalizationInDatabase.Mvc.Models.Entities;
using LocalizationInDatabase.Mvc.Services.EntityServices;
using LocalizationInDatabase.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Globalization;

namespace LocalizationInDatabase.Mvc.Controllers;

[Route("[controller]")]
public class StringResourcesController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;
    private readonly IStringResourceService _stringResourceService;
    private readonly IMemoryCache _cache;

    public StringResourcesController(IMapper mapper,
        ILanguageService languageService,
        IStringResourceService stringResourceService,
        IMemoryCache cache)
    {
        _mapper = mapper;
        _languageService = languageService;
        _stringResourceService = stringResourceService;
        _cache = cache;
    }

    #region Create
    [HttpGet("{culture}/[action]")]
    public async Task<IActionResult> CreateAsync(string culture)
    {
        var language = await _languageService.GetAsync(l => l.Culture.Equals(culture));
        if (language == null)
        {
            return NotFound();
        }

        ViewBag.CultureInfo = new CultureInfo(language.Culture);
        ViewBag.Language = _mapper.Map<LanguageViewModel>(language);

        return View();
    }

    [HttpPost("{culture}/[action]"), ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAsync(string culture, StringResourceEditModel model)
    {
        var language = await _languageService.GetAsync(l => l.Culture.Equals(culture));
        if (language == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            ViewBag.CultureInfo = new CultureInfo(language.Culture);
            ViewBag.Language = _mapper.Map<LanguageViewModel>(language);

            return View(model);
        }

        var stringResource = await _stringResourceService.GetAsync(s => s.Name.Equals(model.Name) && s.LanguageId.Equals(language.Id));
        if (stringResource == null)
        {
            var entity = _mapper.Map<StringResource>(model);
            entity.LanguageId = language.Id;

            await _stringResourceService.AddAsync(entity);
        }

        if (model.SubmitButton == "redirect")
        {
            return RedirectToAction("List", new { Culture = culture });
        }
        else
        {
            return RedirectToAction("Create", new { Culture = culture });
        }
    }
    #endregion

    #region Read
    [HttpGet("{culture}/[action]")]
    public async Task<IActionResult> ListAsync(string culture)
    {
        var language = await _languageService.GetAsync(l => l.Culture.Equals(culture));
        if (language == null)
        {
            return NotFound();
        }

        ViewBag.CultureInfo = new CultureInfo(language.Culture);
        ViewBag.Language = _mapper.Map<LanguageViewModel>(language);

        var entities = await _stringResourceService.ListAsync(sr => sr.LanguageId.Equals(language.Id),
            include: sr => sr.Include(i => i.Language),
            orderBy: sr => sr.OrderBy(o => o.IsApproved).ThenBy(o => o.Name));
        var model = _mapper.Map<List<StringResourceViewModel>>(entities);

        return View(model);
    }

    [HttpGet("{culture}/[action]/{id}")]
    public async Task<IActionResult> DetailsAsync(string culture, int id)
    {
        var language = await _languageService.GetAsync(l => l.Culture.Equals(culture));
        if (language == null)
        {
            return NotFound();
        }

        ViewBag.CultureInfo = new CultureInfo(language.Culture);
        ViewBag.Language = _mapper.Map<LanguageViewModel>(language);

        var entity = await _stringResourceService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<StringResourceViewModel>(entity);

        return View(model);
    }
    #endregion

    #region Update
    [HttpGet("{culture}/[action]/{id}")]
    public async Task<IActionResult> EditAsync(string culture, int id, string? returnUrl)
    {
        var language = await _languageService.GetAsync(l => l.Culture.Equals(culture));
        if (language == null)
        {
            return NotFound();
        }

        ViewBag.CultureInfo = new CultureInfo(language.Culture);
        ViewBag.Language = _mapper.Map<LanguageViewModel>(language);

        var entity = await _stringResourceService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        var model = _mapper.Map<StringResourceEditModel>(entity);

        return View(model);
    }

    [HttpPost("{culture}/[action]/{id}"), ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAsync(string culture, int id, StringResourceEditModel model, string? returnUrl)
    {
        var language = await _languageService.GetAsync(l => l.Culture.Equals(culture));
        if (language == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            ViewBag.CultureInfo = new CultureInfo(language.Culture);
            ViewBag.Language = _mapper.Map<LanguageViewModel>(language);

            return View(model);
        }

        var stringResource = await _stringResourceService.GetAsync(s => s.Name.Equals(model.Name) && s.LanguageId.Equals(language.Id) && !s.Id.Equals(id));
        if (stringResource == null)
        {
            var entity = await _stringResourceService.GetAsync(e => e.Id.Equals(id));
            if (entity == null)
            {
                return NotFound();
            }

            entity = _mapper.Map(model, entity);
            entity.LanguageId = language.Id;
            await _stringResourceService.UpdateAsync(entity);

            _cache.Remove($"stringResource_{entity.Name}_{language.Id}");
        }

        if (model.SubmitButton == "redirect")
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("List", new { Culture = culture });
            }
            else
            {
                return Redirect(returnUrl);
            }
        }
        else
        {
            return RedirectToAction("Edit", new { Culture = culture, Id = id, returnUrl });
        }
    }
    #endregion

    #region Delete
    [HttpGet("{culture}/[action]/{id}")]
    public async Task<IActionResult> DeleteAsync(string culture, int id, string? returnUrl)
    {
        var language = await _languageService.GetAsync(l => l.Culture.Equals(culture));
        if (language == null)
        {
            return NotFound();
        }

        ViewBag.CultureInfo = new CultureInfo(language.Culture);
        ViewBag.Language = _mapper.Map<LanguageViewModel>(language);

        var entity = await _stringResourceService.GetAsync(e => e.Id.Equals(id));
        if (entity == null)
        {
            return NotFound();
        }

        _cache.Remove($"stringResource_{entity.Name}_{language.Id}");
        await _stringResourceService.DeleteAsync(entity);

        return string.IsNullOrEmpty(returnUrl) ? RedirectToAction("List", new { Culture = culture }) : Redirect(returnUrl);
    }
    #endregion
}
