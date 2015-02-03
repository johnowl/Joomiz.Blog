using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Model;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Areas.Dashboard.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostAppService postAppService;

        public PostController()
        {
            this.postAppService = AppServiceFactory.GetPostAppService();
        }

        public PostController(IPostAppService postAppService)
        {
            this.postAppService = postAppService;
        }

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
        public ActionResult Save(Post post)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
     
    }
}