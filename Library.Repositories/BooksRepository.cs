using Library.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            },
            new Book
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
            using (var context = new LibraryContext())
            {
                //dodanie Include() zwraca nam cały obiekt a nie tylko klucz główny, potrzebujemy tego, aby dobrać się do nazwy genre, bo ona była "głębiej w modelu"
                return context.Book.Include(x => x.Genre).SingleOrDefault(x =>x.Id == id);
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var context = new LibraryContext())
            {
                return context.Book.Include(x => x.Genre).ToList();
            }
        }

        // w dodawaniu nie trzeba dodawać Include, bo on i tak pracuje na całym obiekcie, a nie na jego kluczu
        public int AddBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                context.Book.Add(book);
                context.SaveChanges();
                return book.Id;
            }
        }

        public void EditBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                var originalBook = context.Book.Find(book.Id);
                context.Entry(originalBook).CurrentValues.SetValues(book);
                context.SaveChanges();
            }
        }

        public void DeleteBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                var originalBook = context.Book.Find(book.Id);
                context.Book.Remove(originalBook);
                context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetBooksByGenreId(int? genreId)
        {
            var booksByGenre = _allBooks.Where(x => x.Genre.Id == genreId);
            return booksByGenre;
        }
    }

    public interface IBooksRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        int AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(Book book);
        IEnumerable<Book> GetBooksByGenreId(int? genreId);
    }
}
