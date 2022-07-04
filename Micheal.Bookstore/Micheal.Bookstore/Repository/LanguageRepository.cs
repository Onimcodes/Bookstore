using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Micheal.Bookstore.Data;
using Micheal.Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Micheal.Bookstore.Repository
{
    public class LanguageRepository
    {
        private readonly BookstoreContext _context = null;
        public LanguageRepository(BookstoreContext context)
        {
            _context = context;
        }
        public async Task<List<LanguageModel>> GetLanguages()
        {
           return await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,  
                Description = x.Description

            }).ToListAsync();
        }
        
    }
}
