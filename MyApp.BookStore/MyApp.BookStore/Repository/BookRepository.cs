using MyApp.BookStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        } 

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string bookName, string AuthorName)
        {
            return DataSource().Where(x => x.Title.Contains(bookName) || x.Author.Contains(AuthorName)).ToList();
        }

        public List<BookModel> DataSource()
        {

            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title = "Java", Author = "ketan" },
                new BookModel(){Id = 2, Title = "Dotnet", Author = "Devid" },
                new BookModel(){Id = 3, Title = "React js", Author = "brilium"},
                new BookModel(){Id = 4, Title = "DatabaseSQL", Author= "pgadmin"}
            };
        }
    }
}
