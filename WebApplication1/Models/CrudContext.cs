using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CrudContext:DbContext
    {
      public   DbSet<Catagory> catagories { get; set; }

       public  DbSet<Product> products { get; set; }   
    }
}