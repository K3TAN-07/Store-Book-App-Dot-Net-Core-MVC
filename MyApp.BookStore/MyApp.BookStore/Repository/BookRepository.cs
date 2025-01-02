using Microsoft.EntityFrameworkCore;
using MyApp.BookStore.Data;
using MyApp.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel bookModel) {
            var newBook = new Books()
            {
                Author = bookModel.Author,
                CreatedOn = DateTime.UtcNow,
                Description = bookModel.Description,
                Language = bookModel.Language,
                TotalPages = bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value : 0 ,
                Title = bookModel.Title,
                UpdatedOn = DateTime.UtcNow,
            };
           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();

            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToArrayAsync();
            if (allbooks?.Any() == true) {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages,
                        Id = book.Id
                    });
                }
            }
            return books;
        } 

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
        }

        public List<BookModel> SearchBooks(string bookName, string AuthorName)
        {
            return DataSource().Where(x => x.Title.Contains(bookName) || x.Author.Contains(AuthorName)).ToList();
        }

        public List<BookModel> DataSource()
        {

            return new List<BookModel>()
            {
                new BookModel(){Id = 1, Title = "Java", Author = "ketan" , Description="This is description of Java book", Category="Programing", Language="English", TotalPages=1023},
                new BookModel(){Id = 2, Title = "Dotnet", Author = "Devid", Description="This is description of Dotnet book", Category="Programing", Language="English", TotalPages=223},
                new BookModel(){Id = 3, Title = "React js", Author = "brilium", Description="This is description of React js book", Category="Programing", Language="English", TotalPages=333},
                new BookModel(){Id = 4, Title = "DatabaseSQL", Author= "pgadmin", Description = "This is description of Database book", Category="Programing", Language="English", TotalPages=2323}
            };
        }
    }
}
