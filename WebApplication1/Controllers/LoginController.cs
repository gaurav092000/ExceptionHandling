using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        CrudContext db2 = new CrudContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Index( User u)
        {
            var data = db2.users.Where(model => model.UserName == u.UserName && model.Password == u.Password).FirstOrDefault();
            if (data != null)
            {
                Session["Id"]=u.Id.ToString();
                Session["User"]=u.UserName.ToString();
                TempData["Login"] = "<script>alert('login SuccessFully')</script>";
                return RedirectToAction("Index", "Catagory");
            }

            else
            {
                TempData["Login"] = "<script>alert('Please Enter Username and Password')</script>";
                return View();  
            }
        }

        public ActionResult SignUp ()
        {
            return View();
        }
        [HttpPost]

        public ActionResult SignUp(User u)
        {
            if(ModelState.IsValid == true)
            {
                db2.users.Add(u);
                int n = db2.SaveChanges();
                if(n > 0)
                {
                    TempData["signup"] = "<script>alert('Resistration Successfull')</script>";
                    ModelState.Clear();
                }
                else
                {
                    TempData["signup"] = "<script>alert('Resistration Not Successfull')</script>";
                }
            }

            return View();
        }


    }
}