using Microsoft.AspNetCore.Mvc;

namespace MyApp.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Home Controller";
        }
    }
}
