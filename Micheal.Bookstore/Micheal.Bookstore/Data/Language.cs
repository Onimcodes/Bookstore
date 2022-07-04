using System.Collections.Generic;

namespace Micheal.Bookstore.Data
{
    public class Language
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public ICollection<Books> Books { get; set; }   
    }
}
