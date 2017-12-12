using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class mvcProductModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="This is field is Mandetory")]
        public string ProductName { get; set; }
        public double Price { get; set; }
    }
}