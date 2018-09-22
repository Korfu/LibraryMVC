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
        public IActionResult Index()
        {
            var _booksRepository = new BooksRepository();

            List<Book> books = _booksRepository.GetBooks();

            return View(books);
        }
    }
}