using Microsoft.AspNetCore.Mvc;
using MyApp.BookStore.Models;
using MyApp.BookStore.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.BookStore.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public HomeController(
            IUserService userService,
            IEmailService emailService)
        {          
            _userService = userService;
            _emailService = emailService;
        }
        public async Task<ViewResult> IndexAsync()
        {
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "test@gmail.com" },
                 PlaceHolders = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("{{UserName}}", "Ketan")
                    }
            };

            await _emailService.SendTestEmail(options);

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
