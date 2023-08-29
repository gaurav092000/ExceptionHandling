using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Product

    { 
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="ProductName is Required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "ProductName is Required")]
        public string ProductPrice { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]

        public virtual Catagory Catagory { get; set; }  


       





    }
}