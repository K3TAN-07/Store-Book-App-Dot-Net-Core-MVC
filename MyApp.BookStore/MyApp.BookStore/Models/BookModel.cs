using System.ComponentModel.DataAnnotations;

namespace MyApp.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage = " Please enter the title for your book")]
        public string Title { get; set; }

        [Required(ErrorMessage = " Please enter the Author for your book")]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage = " Please enter the TotalPages for your book")]

        [Display(Name ="Total pages of book")]
        public int? TotalPages { get; set; }
        public string Language { get; set; }
    }
}
