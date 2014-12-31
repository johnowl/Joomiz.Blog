using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Areas.Dashboard.Controllers
{
    public class CommentController : Controller
    {
        // GET: Dashboard/Comment
        public ActionResult Index()
        {
            return View();
        }
    }
}