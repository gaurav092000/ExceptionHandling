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

        CrudContext db1 = new CrudContext();

        public ActionResult IndexList()
        {
            var data= db1.products.Include(x => x.Catagory).ToList();
            return View(data);
        }
        public ActionResult Index(int id)
        {

            var data = db1.products.Include(x => x.Catagory).Where(x => x.CategoryId == id).ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            var data = db1.catagories.Where(x => x.status == true).ToList();
            TempData["Map"] = new SelectList(data, "CatagoryId", "CatagoryName");
            return View();
        }

        [HttpPost]

        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid == true)
            {

                db1.products.Add(p);
                int n = db1.SaveChanges();
                if (n > 0)
                {
                    TempData["Create"] = "<script>alert('Data Add Successfully')</script>";
                    return RedirectToAction("IndexList", "Product");
                }
                else
                {
                    TempData["Create"] = "<script>alert('Data Not ADD')</script>";
                }

            }
            return View();
        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            var data1 = db1.catagories.Where(x => x.status == true).ToList();
            TempData["Mapp"] = new SelectList(data1, "CatagoryId", "CatagoryName");
            var edit = db1.products.Where(model => model.ProductId == id).FirstOrDefault();
            return View(edit);
        }

        [HttpPost]

        public ActionResult Edit(Product pp)
        {
            if (ModelState.IsValid == true)
            {
                db1.Entry(pp).State = EntityState.Modified;
                int n = db1.SaveChanges();
                if (n > 0)
                {
                    TempData["Edit"] = "<script>alert('Data Edit Successfully')</script>";
                    return RedirectToAction("IndexList", "Product");
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
            var delete = db1.products.Where(model => model.ProductId== id).FirstOrDefault();
            if (delete!=null) 
            {
                db1.Entry(delete).State = EntityState.Deleted;
                int n=db1.SaveChanges();
                if (n > 0)
                {
                    TempData["Delete"] = "<script>alert('Data Delete Successfully')</script>";
                    return RedirectToAction("IndexList", "Product");
                }
                else
                {
                    TempData["Delete"] = "<script>alert('Data Not Edit')</script>";
                }
            }
            return View();
        }

    }
}