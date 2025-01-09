using Microsoft.AspNetCore.Mvc;

namespace MyApp.BookStore.Areas.Financial.Controllers
{
    [Area("financial")]
    [Route("financial/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
