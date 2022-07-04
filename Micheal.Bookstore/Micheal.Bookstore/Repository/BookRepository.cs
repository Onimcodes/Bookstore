using Micheal.Bookstore.Data;
using Micheal.Bookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Micheal.Bookstore.Repository
{
    public class BookRepository
    {
        private readonly BookstoreContext _context = null;

        public BookRepository(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BooksModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                createdOn = DateTime.UtcNow,
                updatedOn = DateTime.UtcNow,
                Title = model.Title,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                LanguageId = model.LanguageId,
                Description = model.Description,
                CoverImageUrl = model.CoverImageUrl,  
                BookPdfUrl = model.BookPdfUrl,  
            };
            newBook.bookGallery = new List<BookGallery>();  
            foreach(var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL,
                });
            }
           await _context.Books.AddAsync(newBook);
           await _context.SaveChangesAsync();
            return newBook.Id;  
        }
        public async Task<List<BooksModel>> GetAllBooks()
        {
            var books = new List<BooksModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BooksModel()
                    {
                        Title = book.Title,
                        Author = book.Author,
                        Description = book.Description,
                        Category = book.Category,
                        LanguageId = book.LanguageId,
                        //Language = book.Language.Name,
                        TotalPages = book.TotalPages,
                        Id = book.Id,
                        CoverImageUrl = book.CoverImageUrl, 
                    });
                }
            }
            return books;
        }
        public async Task<BooksModel>  GetBookId(int id)
        {
            return await _context.Books.Where(x => x.Id == id).Select(book => new BooksModel()
            {
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                LanguageId = book.LanguageId,
                Language = book.Language.Name,
                TotalPages = book.TotalPages,
                Id = book.Id,
                CoverImageUrl = book.CoverImageUrl,
                Gallery = book.bookGallery.Select(g => new GalleryModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL,
                }).ToList(),
                BookPdfUrl = book.BookPdfUrl
            }).FirstOrDefaultAsync();
        }
        public List<BooksModel> SearchBook(string title, string authorName)
        {
            return null;
        }
     
    }
}
