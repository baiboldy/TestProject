using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.ViewModels
{
    public class BookToAuthorViewModel
    {
        public IEnumerable<BookToAuthor> allBookToAuthor { get; set; }
        public int selectedValue { get; set; }
        public string searchValue { get; set; }
        
    }
}
