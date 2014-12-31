using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Areas.Dashboard.Controllers
{
    public class AutenticationController : Controller
    {
        // GET: Dashboard/Autentication
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string user, string password)
        {
            return View();
        }
    }
}