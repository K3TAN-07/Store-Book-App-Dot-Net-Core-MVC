using Microsoft.AspNetCore.Mvc;
using MyApp.BookStore.Models;

namespace MyApp.BookStore.Controllers
{
    public class AccountController : Controller
    {
        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public IActionResult Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            return View();
        }
    }
}
