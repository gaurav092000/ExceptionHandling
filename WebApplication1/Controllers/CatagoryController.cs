using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CatagoryController : Controller
    {
        // GET: Catagory

        CrudContext db =new CrudContext();
        public ActionResult Index()
        {
            var data = db.catagories.Include(x => x.Products).ToList();
            return View(data);
        }


     
    

    }
}