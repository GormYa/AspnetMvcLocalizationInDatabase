using Microsoft.AspNetCore.Mvc;

namespace LocalizationInDatabase.Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
