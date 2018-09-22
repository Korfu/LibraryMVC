using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IActionResult Index()
        {
            List<Book> books = _booksRepository.GetBooks();
            return View(books);
        }
        public IActionResult Details(int id)
        {
            var book = _booksRepository.GetBook(id);

            return View(book);
        }

    }
}