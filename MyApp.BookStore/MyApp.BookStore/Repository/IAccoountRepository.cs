using Microsoft.AspNetCore.Identity;
using MyApp.BookStore.Models;
using System.Threading.Tasks;

namespace MyApp.BookStore.Repository
{
    public interface IAccoountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<SignInResult> PasswordSignInAsync(SignInUserModel signInModel);
        Task SignOutAsync();
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordModel model);

    }
}