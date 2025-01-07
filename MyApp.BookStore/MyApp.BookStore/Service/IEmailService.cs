using MyApp.BookStore.Models;
using System.Threading.Tasks;

namespace MyApp.BookStore.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}