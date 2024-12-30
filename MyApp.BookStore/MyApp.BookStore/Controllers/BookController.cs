using Microsoft.AspNetCore.Mvc;
using MyApp.BookStore.Models;
using MyApp.BookStore.Repository;
using System.Collections.Generic;

namespace MyApp.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();           
        }

        public List<BookModel> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }

        public BookModel GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public List<BookModel> SearchBooks(string bookName, string author)
        {
            return _bookRepository.SearchBooks(bookName, author);
        }
    }
}
