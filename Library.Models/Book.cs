using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50,ErrorMessage ="Title must not be longer than 50 characters")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(50, ErrorMessage = "Author name must not be longer than 50 characters")]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Published year is required")]
        [Range(0, 2018, ErrorMessage = "Please enter valid Year")]
        [DisplayName("Published Year")]
        public int ProductionYear { get; set; }


        [DisplayName("Genre")]
        public Genre Genre { get; set; }

        public int GenreId { get; set; }
    }
}
