using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Data.Models
{
    public class Book
    {
        [Key]
        [BindNever]
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        [Display(Name = "Pulisher")]
        public virtual Publisher publisher { get; set; }
        public float price { get; set; }
        public DateTime publishedAt { get; set; }
        public int publisherId { get; set; }
    }
}
