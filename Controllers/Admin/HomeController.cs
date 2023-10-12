using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers.Admin
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
