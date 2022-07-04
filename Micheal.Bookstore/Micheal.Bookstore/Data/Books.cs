﻿using System;
using System.Collections.Generic;

namespace Micheal.Bookstore.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public int TotalPages { get; set; }
        public string CoverImageUrl { get; set; }

        public string Description { get; set; }
        public DateTime? createdOn { get; set; }
        public DateTime? updatedOn { get; set; }
        public Language Language { get; set; }
        public string BookPdfUrl { get; set; }  
        public ICollection<BookGallery> bookGallery { get; set; }
    }
}
