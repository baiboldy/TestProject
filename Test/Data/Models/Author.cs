using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Data.Models
{
    public class Author
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Имя автора")]
        [StringLength(30)]
        [MinLength(2)]
        [Required(ErrorMessage = "Длина имени составляет от 2 до 30 символов ")]
        [DataType(DataType.Text)]
        public string name { get; set; }
    }
}
