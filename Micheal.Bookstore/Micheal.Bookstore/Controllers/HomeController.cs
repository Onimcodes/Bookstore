using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using Micheal.Bookstore.Models;
    


namespace Micheal.Bookstore.Controllers
{
    public class HomeController:Controller
    {
        [ViewData]
        public string Title { get; set; }   
        public ViewResult Index()
        {
            ViewData["property1"] = "Abraham Micheal";
                ViewData["book"] = new BooksModel() { Author = "me", Id = 1 };
            Title = "Homepage";
            return View();
        }
        public ViewResult Aboutus()
        {
            Title = "About Us";
            return View();
        }
        public ViewResult ContactUs()
        {
            Title = "Contact Us";
            return View();
        }
    }
}
