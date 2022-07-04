using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Micheal.Bookstore.Components
{
    public class TopBooksViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
