using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Repositories
{
    public class BooksRepository : IBooksRepository
    {
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
            }
        };

        public Book GetBook(int id)
        {
            return _allBooks.FirstOrDefault(x => x.Id == id);
        }

        public List<Book> GetBooks()
        {
            return _allBooks;
        }

        public int AddBook(Book book)
        {
            var maxId = _allBooks.Select(x => x.Id).Max();
            book.Id = maxId + 1;
            var genreRepository = new GenreRepository();
            book.Genre = genreRepository.Get(book.GenreId);
            _allBooks.Add(book);
            return book.Id;
        }
    }

    public interface IBooksRepository
    {
        List<Book> GetBooks();
        Book GetBook(int id);
        int AddBook(Book book);
    }
}
