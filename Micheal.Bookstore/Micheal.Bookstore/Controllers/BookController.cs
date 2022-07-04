using Micheal.Bookstore.Models;
using Micheal.Bookstore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Micheal.Bookstore.Controllers
{
    
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
       private readonly LanguageRepository _languageRepository = null;  
        private readonly IWebHostEnvironment _webHostEnvironment = null;    
        public BookController(BookRepository bookRepository,
            LanguageRepository languageRepository, 
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        [ViewData]
        public string Title { get; set; }

        public async Task<ViewResult> GetAllBooks() 
        {
            Title = "All Books";
            List<BooksModel> data = await _bookRepository.GetAllBooks();
            
            return View(data);
        }
        [Route("book-details/{id}", Name = "bookDetailsRoute")]
        public async Task<ViewResult>  GetBook(int id)
        {
            var data = await _bookRepository.GetBookId(id);

            return View(data);
        }
        public List<BooksModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
        
        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            //var model = new BooksModel()
            //{
                //Language = "3"
            //};
            ViewBag.Language = new SelectList( await _languageRepository.GetLanguages(), "Id", "Name");

            //var group1 = new SelectListGroup() { Name = "Group 1" };
            //var group2 = new SelectListGroup() { Name = "Group 2" };
            //var group3 = new SelectListGroup() { Name = "Group 3" };
            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //}).ToList() ;

            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){Text ="Hindi" , Value = "1", Group = group1},
            //    new SelectListItem(){Text ="English" , Value = "2", Group = group1},
            //    new SelectListItem(){Text ="Pidgin" , Value = "3", Group = group2},
            //    new SelectListItem(){Text ="Yoruba" , Value = "4", Group = group2},
            //    new SelectListItem(){Text ="Igbo" , Value = "5", Group = group3},
            //    new SelectListItem(){Text ="Hausa" , Value = "6", Group = group3},

            //};

            Title = "Add new book";  
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(); 
        }
        [HttpPost]
        public async Task<IActionResult>  AddNewBook(BooksModel bookmodel)
        {
            if (ModelState.IsValid)
            {
                if(bookmodel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                  bookmodel.CoverImageUrl =   await UploadImage(folder,bookmodel.CoverPhoto);
                }
                if (bookmodel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";
                    bookmodel.Gallery = new List<GalleryModel>(); 
                    foreach (var file in bookmodel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        bookmodel.Gallery.Add(gallery);
                    }
               
                }
                if (bookmodel.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    bookmodel.BookPdfUrl = await UploadImage(folder, bookmodel.BookPdf);
                }
                int id = await _bookRepository.AddNewBook(bookmodel);

                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });

                }
            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");


            return View();

        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder,FileMode.Create));
            return "/"+folderPath;
        }

    }
}
