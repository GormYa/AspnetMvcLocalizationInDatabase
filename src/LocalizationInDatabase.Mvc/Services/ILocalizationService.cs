using Microsoft.AspNetCore.Mvc.Localization;
using System.Globalization;

namespace LocalizationInDatabase.Mvc.Services;

public interface ILocalizationService
{
    LocalizedHtmlString this[string name] { get; }
    LocalizedHtmlString this[RouteValueDictionary routeValues, string name] { get; }
    LocalizedHtmlString this[string name, params object[] arguments] { get; }
    LocalizedHtmlString this[RouteValueDictionary routeValues, string name, params object[] arguments] { get; }

    List<CultureInfo> GetCultures();
}
