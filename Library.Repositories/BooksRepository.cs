using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly IGenreRepository _genreRepository;

        public BooksRepository(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public static List<Book> _allBooks = new List<Book>
        {
            new Book
            {
                Id=1,
                Title="Myśli współczesnego człowieka",
                Author="Roma Dmowski",
                ProductionYear = 1920,
                Genre = new Genre
                {
                    Id =1,
                    Name ="Political fiction"
                }
            },
            new Book
            {
                Id=2,
                Title="Czerwona książeczka",
                Author="Mao Ze Tung",
                ProductionYear = 1925,
                Genre = new Genre
                {
                    Id =1,
                    Name ="Political fiction"
                }
            },
             new Book
            {
                Id=3,
                Title="Potop",
                Author="Henryk Sienkiewicz",
                ProductionYear = 1905,
                Genre = new Genre
                {
                    Id =3,
                    Name ="Adventure"
                }
            },new Book
            {
                Id=4,
                Title="Ogniem i Mieczem",
                Author="Adam Mickiewicz",
                ProductionYear = 1875,
                Genre = new Genre
                {
                    Id = 2,
                    Name = "Fantasy"
                }
            }
        };

        public Book GetBook(int id)
        {
            return _allBooks.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetBooks()
        {
            return _allBooks.OrderBy( x =>x.Id).ToList();
        }

        public int AddBook(Book book)
        {
            var maxId = _allBooks.Select(x => x.Id).Max();
            book.Id = maxId + 1;
            book.Genre = _genreRepository.Get(book.GenreId);
            _allBooks.Add(book);
            return book.Id;
        }

        public void EditBook(Book book)
        {
            var existingBook = _allBooks.FirstOrDefault(x => x.Id == book.Id);
            _allBooks.Remove(existingBook);
            book.Genre = _genreRepository.Get(book.GenreId);
            _allBooks.Add(book);
        }

        public void DeleteBook(Book book)
        {
            var existingBook = _allBooks.FirstOrDefault(x => x.Id == book.Id);
            _allBooks.Remove(existingBook);
        }

        public IEnumerable<Book> GetBooksByGenreId(int? genreId)
        {
            var booksByGenre = _allBooks.Where(x => x.Genre.Id == genreId);
            return booksByGenre;
        }
    }

    public interface IBooksRepository
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        int AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(Book book);
        IEnumerable<Book> GetBooksByGenreId(int? genreId);
    }
}
