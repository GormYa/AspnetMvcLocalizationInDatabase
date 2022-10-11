using LocalizationInDatabase.Mvc.Data;
using LocalizationInDatabase.Mvc.Models.Entities;
using LocalizationInDatabase.Mvc.Services.EntityServices;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Text.RegularExpressions;

namespace LocalizationInDatabase.Mvc.Services;

public class LocalizationService : ILocalizationService
{
    private readonly IOptions<RequestLocalizationOptions> _options;
    private readonly ILanguageService _languageService;
    private readonly ApplicationDbContext _db;
    private readonly IMemoryCache _cache;

    public LocalizationService(IOptions<RequestLocalizationOptions> options,
        ILanguageService languageService,
        ApplicationDbContext db,
        IMemoryCache cache)
    {
        _options = options;
        _languageService = languageService;
        _db = db;
        _cache = cache;
    }

    public LocalizedHtmlString this[string name] { get { return Localize(name); } }

    public LocalizedHtmlString this[RouteValueDictionary routeValues, string name] { get { return Localize(routeValues, name); } }

    public LocalizedHtmlString this[string name, params object[] arguments] { get { return Localize(name, arguments); } }

    public LocalizedHtmlString this[RouteValueDictionary routeValues, string name, params object[] arguments] { get { return Localize(routeValues, name, arguments); } }

    public List<CultureInfo> GetCultures()
    {
        var supportedCultures = _options.Value.SupportedUICultures;
        return supportedCultures!.ToList();
    }

    private LocalizedHtmlString Localize(RouteValueDictionary routeValues, string name, params object[] args)
    {
        var resourceName = string.Empty;

        if (routeValues.TryGetValue("area", out var area) && !string.IsNullOrEmpty(area?.ToString()))
        {
            resourceName += $"{area}.";
        }

        if (routeValues.TryGetValue("controller", out var controller) && !string.IsNullOrEmpty(controller?.ToString()))
        {
            resourceName += $"{controller}.";
        }

        if (routeValues.TryGetValue("action", out var action) && !string.IsNullOrEmpty(action?.ToString()))
        {
            resourceName += $"{action}.";
        }

        resourceName += name;

        return Localize(resourceName, args);
    }

    private LocalizedHtmlString Localize(string name, params object[] args)
    {
        var uiCulture = Thread.CurrentThread.CurrentUICulture.Name;

        var language = GetLanguage(uiCulture);
        if (language == null)
        {
            return new LocalizedHtmlString(name, name, true);
        }

        var stringResource = GetStringResource(name, language.Id);
        if (stringResource == null)
        {
            var defaultCulture = "tr-TR";

            if (language.Culture.Equals(defaultCulture))
            {
                return new LocalizedHtmlString(name, name, true);
            }

            var defaultLanguage = GetLanguage(defaultCulture);
            if (defaultLanguage == null)
            {
                return new LocalizedHtmlString(name, name, true);
            }

            stringResource = GetStringResource(name, defaultLanguage.Id);

            if (stringResource == null)
            {
                return new LocalizedHtmlString(name, name, true);
            }
        }

        LocalizedHtmlString result;
        string stringResourceValue = stringResource.Value;
        stringResourceValue = Regex.Replace(stringResourceValue, "{", "{{");
        stringResourceValue = Regex.Replace(stringResourceValue, "}", "}}");

        if (args != null && args.Any())
        {
            for (int i = 0; i < args.Length; i++)
            {
                stringResourceValue = stringResourceValue.Replace($"{{{{{i}}}}}", $"{{{i}}}");
            }

            result = new LocalizedHtmlString(name, stringResourceValue, false, args);
        }
        else
        {
            result = new LocalizedHtmlString(name, stringResourceValue, false);
        }

        return result;
    }

    private StringResource? GetStringResource(string name, int languageId)
    {
        var cacheKey = $"stringResource_{name}_{languageId}";

        if (!_cache.TryGetValue(cacheKey, out StringResource stringResource))
        {
            var sr = _db.StringResources.FirstOrDefault(s => s.Name.Equals(name) && s.LanguageId.Equals(languageId));

            if (sr == null)
            {
                stringResource = new StringResource
                {
                    LanguageId = languageId,
                    Name = name,
                    Value = name,
                    IsApproved = false
                };

                _db.StringResources.Add(stringResource);
                _db.SaveChanges();

                _cache.Set(cacheKey, stringResource);

                return null;
            }

            _cache.Set(cacheKey, sr);

            stringResource = sr;
        }

        if (!stringResource.IsApproved || string.IsNullOrEmpty(stringResource.Value))
        {
            return null;
        }

        return stringResource;
    }

    private Language? GetLanguage(string culture)
    {
        var result = _cache.GetOrCreate($"language_{culture}", entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromHours(1);
            return _languageService.GetLanguageByCulture(culture);
        });

        return result;
    }
}
