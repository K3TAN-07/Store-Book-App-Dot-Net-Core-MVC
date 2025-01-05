using Microsoft.AspNetCore.Http;
using MyApp.BookStore.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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

        public string CoverImageUrl { get; set; }
        
        [Required]
        [Display(Name ="Choose the cover photo of your book")]
        public IFormFile CoverPhoto { get; set; }

        [Required]
        [Display(Name = "Choose the gallery photos of your book")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }
        public string BookPdfUrl { get; set; }

        [Required]
        [Display(Name = "Choose the PDF of your book")]
        public IFormFile BookPdf { get; set; }

    }

}

