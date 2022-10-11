using LocalizationInDatabase.Mvc.Data;
using LocalizationInDatabase.Mvc.Services;
using LocalizationInDatabase.Mvc.Services.EntityServices;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RequestLocalizationOptions>(localizationOptions =>
{
    localizationOptions.ApplyCurrentCultureToResponseHeaders = true;
    localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
});

builder.Services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddLocalization();

builder.Services.AddControllersWithViews().AddViewLocalization();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));

builder.Services.AddCustomServices();

builder.Services.AddMemoryCache();

var app = builder.Build();

app.Use(async (context, next) =>
{
    using var scope = app.Services.CreateScope();

    var localizationOptions = scope.ServiceProvider.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
    var languageService = scope.ServiceProvider.GetRequiredService<ILanguageService>();

    var languages = await languageService.ListAsync();
    var cultures = languages!.Select(s => new CultureInfo(s.Culture)).ToArray();

    var turkishCulture = new CultureInfo("tr-TR");
    localizationOptions.DefaultRequestCulture = new RequestCulture(turkishCulture, turkishCulture);
    localizationOptions.SupportedCultures = cultures;
    localizationOptions.SupportedUICultures = cultures;

    await next.Invoke();
});

app.UseRequestLocalization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
