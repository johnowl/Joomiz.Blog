using Joomiz.Blog.Domain.Model;
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Category category)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteCategory(int id)
        {
            return View();
        }
    }
}