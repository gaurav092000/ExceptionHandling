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

       public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Catagory c)
        {
  
            if (ModelState.IsValid==true)
            {

                db.catagories.Add(c);
                int n = db.SaveChanges();
                if (n > 0)
                {
                    TempData["Create"] = "<script>alert('Data added Success')</script>";
                    return RedirectToAction("Index", "Catagory");
                }
                else
                {
                    TempData["Create"] = "<script>alert('Data Not Add')</script>";
                }
            }
            return View();
        }
        
        public ActionResult EditCataory(int id) 
        {
            var edit = db.catagories.Where(model => model.CatagoryId == id).FirstOrDefault();
            return View(edit);
        }

        [HttpPost]
        public ActionResult EditCataory(Catagory ce)
        {

            if(ModelState.IsValid==true)
            {
           
                    db.Entry(ce).State =EntityState.Modified;
                int n = db.SaveChanges();
                if (n > 0)
                {
                    TempData["Edit"] = "<script>alert('Data Edit Success')</script>";
                    return RedirectToAction("Index", "Catagory");
                }
                else
                {
                    TempData["Create"] = "<script>alert('Data Not Edit')</script>";
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
           if(id > 0)
            {
                var delete= db.catagories.Where(model => model.CatagoryId==id) .FirstOrDefault();
                if(delete!=null)
                {
                    db.Entry(delete).State = EntityState.Deleted;
                    int n=db.SaveChanges();
                    if(n>0)
                    
                        {
                            TempData["Delete"] = "<script>alert('Are You sure')</script>";
                 
                        }
                    else
                        {
                            TempData["Delete"] = "<script>alert('Data not delete')</script>";
                        }
                    

                }
           }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var delete = db.catagories.Where(model => model.CatagoryId == id).FirstOrDefault();
            return View(delete);
        }


       






    }
}