using Microsoft.AspNetCore.Mvc;
using MyApp.BookStore.Models;
using MyApp.BookStore.Repository;
using System.Threading.Tasks;

namespace MyApp.BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccoountRepository _accoountRepository;

        public AccountController(IAccoountRepository accoountRepository) {
            _accoountRepository = accoountRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accoountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded) { 
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("",errorMessage.Description);
                    }
                    return View(userModel);
                }
                ModelState.Clear();
            }
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInUserModel signInUserModel, string returnUrl)
        {
            if (ModelState.IsValid) {
             var result =  await _accoountRepository.PasswordSignInAsync(signInUserModel);
                if (result.Succeeded) {
                    if (!string.IsNullOrEmpty(returnUrl)) {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");                
                }
                 ModelState.AddModelError("", "Invalid credentials.");
            }
            return View(signInUserModel);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout() { 
            await _accoountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accoountRepository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View(model);
        }
    }
}
