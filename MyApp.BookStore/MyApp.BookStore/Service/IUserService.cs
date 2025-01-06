namespace MyApp.BookStore.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsUserAuthenticated();
    }
}