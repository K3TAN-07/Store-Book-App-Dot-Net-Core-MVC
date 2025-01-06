using Microsoft.AspNetCore.Identity;
using MyApp.BookStore.Models;
using MyApp.BookStore.Service;
using System.Threading.Tasks;

namespace MyApp.BookStore.Repository
{
    public class AccoountRepository : IAccoountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;


        public AccoountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IUserService userService) {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                UserName = userModel.Email
            };
           var result = await _userManager.CreateAsync(user, userModel.Password);

        return result;
        }

        public async Task<SignInResult> PasswordSignInAsync(SignInUserModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, true);

            return result;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
           return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
           
        }
    }
}
