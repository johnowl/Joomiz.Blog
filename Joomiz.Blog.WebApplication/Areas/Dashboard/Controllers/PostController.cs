using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Areas.Dashboard.Controllers
{
    public class PostController : Controller
    {
        // GET: Dashboard/Post
        public ActionResult Index()
        {
            return View();
        }
    }
}