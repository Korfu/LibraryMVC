using Library.Models;
using System;
using System.Collections.Generic;

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
                Id=1,
                Title="Czerwona książeczka",
                Author="Mao Ze Tung",
                ProductionYear = 1925,
                Genre = new Genre
                {
                    Id =1,
                    Name ="Political fiction"
                }
            }
        };

        public List<Book> GetBooks()
        {
            return _allBooks;
        }
    }

    public interface IBooksRepository
    {
        List<Book> GetBooks();
    }
}
