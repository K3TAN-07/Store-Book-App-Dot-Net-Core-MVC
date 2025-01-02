using Microsoft.AspNetCore.Mvc;

namespace MyApp.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AboutUs() 
        { 
            return View();
        }

        public ViewResult ContactUS()
        {
            return View();
        }

        public ViewResult Error() 
        {
            return View();
        }
    }
}
