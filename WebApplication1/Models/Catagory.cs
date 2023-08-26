using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Catagory
    {
        [Key]
        public int CatagoryId { get; set; }

        [Required(ErrorMessage ="CatagoryName Required")]
        public string CatagoryName { get; set; }

        [Required(ErrorMessage = "CatagoryDescrition Required")]
        public string CatagoryDescription { get; set; }

       public  bool status { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}