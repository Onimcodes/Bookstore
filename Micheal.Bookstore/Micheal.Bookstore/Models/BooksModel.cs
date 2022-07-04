using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Micheal.Bookstore.Helpers;
using Microsoft.AspNetCore.Http;

namespace Micheal.Bookstore.Models
{
    public class BooksModel
    {
        public int Id { get; set; }
        //[StringLength(100,MinimumLength =5)]
        //[Required(ErrorMessage = "OOps! You have to enter the title of your book")]
        [MyCustomValidationAttribute(ErrorMessage ="Your title must contain mvc")]
        public string Title { get; set; }

        [Required(ErrorMessage = "OOps! You have to enter the author name")]
        public string Author { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please choose the language of your book" )]
        public int LanguageId { get; set; }
        public string Language { get; set; }    
        [Display (Name = "Total pages of  book")]
        [Required(ErrorMessage = "OOps! You have to enter the total pages")]
        public int? TotalPages { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        [Display(Name = "Choose the cover gallery of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }
        public string CoverImageUrl { get; set; } 
        public List<GalleryModel> Gallery { get; set; }    
        public IFormFile BookPdf { get; set; }  
        public string BookPdfUrl { get; set; }  
    }
}
