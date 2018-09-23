using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IGenreRepository _genreRepository;

        public BooksController(IBooksRepository booksRepository, IGenreRepository genreRepository)
        {
            _booksRepository = booksRepository;
            _genreRepository = genreRepository;
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

        public IActionResult Create()
        {
            ViewBag.Genres = ViewBag.Genres = GetGenres();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var bookIdToBeSabed = _booksRepository.AddBook(book);
                return RedirectToAction("Details", new { id = bookIdToBeSabed });
            } else
            {
                ViewBag.Genres = ViewBag.Genres = GetGenres();
                return View(book);
            }


        }

        public IActionResult Edit(int id)
        {
            ViewBag.Genres = _genreRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });

            var currentBook = _booksRepository.GetBook(id);

            return View(currentBook);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _booksRepository.EditBook(book);
                return RedirectToAction("Details", new { id = book.Id });
            }
            else
            {
                ViewBag.Genres = GetGenres();
                return View(book);
            }
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Genres = ViewBag.Genres = GetGenres();

            var currentBook = _booksRepository.GetBook(id);
            return View(currentBook);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            _booksRepository.DeleteBook(book);
            return RedirectToAction("Index");
        }

        private dynamic GetGenres()
        {
            return _genreRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

    }
}