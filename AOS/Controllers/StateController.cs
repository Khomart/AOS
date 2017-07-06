using AOS.DbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AOS.Controllers
{
    [Authorize(Roles = "State")]
    public class StateController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: State
        public ActionResult Index()
        {
            return View();
        }
    }
}