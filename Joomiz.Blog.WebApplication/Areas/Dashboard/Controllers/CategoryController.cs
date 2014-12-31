using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Areas.Dashboard.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Dashboard/Category
        public ActionResult Index()
        {
            return View();
        }
    }
}