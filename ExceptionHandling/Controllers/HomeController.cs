using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionHandling.Controllers
{
 
    public class HomeController : Controller
    {
        //[HandleError] action method mai errorfilter lagna
        public ActionResult Index()
        {
            throw new Exception();
            return View();
        }

        public ActionResult About() 
        {
            throw new Exception();
            return View();        
        }

        
    }
}