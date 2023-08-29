using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        CrudContext db1= new CrudContext();
        public ActionResult Index(int id)
        {        
          
            var data=db1.products.Include(x=> x.Catagory).Where(x => x.CategoryId == id).ToList();
            return View(data);
        }


    }
}