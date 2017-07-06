using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AOS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            else
            {
                if (User.IsInRole("State"))
                {
                    return RedirectToAction("Index", "State");
                }
                else if (User.IsInRole("Operator"))
                {
                    return RedirectToAction("Index", "Operator");
                }
                else if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else 
                {
                    return RedirectToAction("Index", "State");
                }
            }
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}