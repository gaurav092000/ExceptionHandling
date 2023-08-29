using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionHandling.Controllers
{
    public class HomeController : Controller
    {
        [HandleError]
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        }

        public ActionResult Error() 
        {
            return View();        
        }

        
    }
}