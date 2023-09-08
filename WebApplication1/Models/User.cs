using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}