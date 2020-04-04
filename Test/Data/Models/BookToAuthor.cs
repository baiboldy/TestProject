using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data.Models
{
    public class BookToAuthor
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Book")]
        public virtual Book book { get; set; }
        [Display(Name = "Author")]
        public virtual Author author { get; set; }
        public int bookId { get; set; }
        public int authorId { get; set; }
    }
}
