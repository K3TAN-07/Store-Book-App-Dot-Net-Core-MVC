﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.BookStore.Models;
using MyApp.BookStore.Repository;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace MyApp.BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccoountRepository _accountRepository;

        public AccountController(IAccoountRepository accoountRepository) {
            _accountRepository = accoountRepository;
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
                var result = await _accountRepository.CreateUserAsync(userModel);
                if (!result.Succeeded) { 
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("",errorMessage.Description);
                    }
                    return View(userModel);
                }
                ModelState.Clear();
                return RedirectToAction("ConfirmEmail",new { email = userModel.Email});
            }
            return View(userModel);
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
             var result =  await _accountRepository.PasswordSignInAsync(signInUserModel);
                if (result.Succeeded) {
                    if (!string.IsNullOrEmpty(returnUrl)) {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");                
                }
                if (result.IsNotAllowed) {
                    ModelState.AddModelError("", "Not allowed to login");

                }
                else
                {
                    ModelState.AddModelError("", "Invalid credentials.");
                }
            }
            return View(signInUserModel);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout() { 
            await _accountRepository.SignOutAsync();
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
                var result = await _accountRepository.ChangePasswordAsync(model);
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

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
        {
            EmailConfirmModel model = new EmailConfirmModel
            {
                Email = email
            };

            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(' ', '+');
                var result = await _accountRepository.ConfirmEmailAsync(uid, token);
                if (result.Succeeded)
                {
                    model.EmailVerified = true;
                }
            }

            return View(model);
        }


        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(EmailConfirmModel model)
        {
            var user = await _accountRepository.GetUserByEmailAsync(model.Email);

            if (user != null) {

                if (user.EmailConfirmed)
                {
                    model.EmailVerified = true;
                    return View(model);
                }

                await _accountRepository.GenerateEmailConfirmationTokenAsync(user);
                model.EmailSent = true;
                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError("","Someting went wrong.");
            }

            return View(model);
        }

        // forgot password
        [AllowAnonymous , HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid) {

               var user = await _accountRepository.GetUserByEmailAsync(model.Email);
                if (user != null) { 
                   await  _accountRepository.GenerateForgotPasswordTokenAsync(user);
                }

                ModelState.Clear();
                model.EmailSent = true;

            }
            return View(model);
        }

        //reset password
        [AllowAnonymous, HttpGet("reset-password")]
        public IActionResult RestPassword(string uid, string token)
        {
            ResetPasswordModel model = new ResetPasswordModel()
            {
                Token = token,
                UserId = uid
            };
            return View(model);
        }

        [AllowAnonymous, HttpPost("reset-password")]
        public async Task<IActionResult> RestPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(' ', '+');
                var result = await _accountRepository.ResetPasswordAsync(model);

                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }

    }
}
