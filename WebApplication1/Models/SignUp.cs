using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class SignUp
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Username Requied")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Password Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm Password Required")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}