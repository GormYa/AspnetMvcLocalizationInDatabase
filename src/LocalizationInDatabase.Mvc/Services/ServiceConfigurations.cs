using LocalizationInDatabase.Mvc.Services.EntityServices;

namespace LocalizationInDatabase.Mvc.Services;

public static class ServiceConfigurations
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IStringResourceService, StringResourceService>();
        services.AddScoped<ILocalizationService, LocalizationService>();

        return services;
    }
}
