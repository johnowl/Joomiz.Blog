using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Entities;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostAppService postAppService;

        public HomeController()
        {
            this.postAppService = AppServiceFactory.GetPostService();
        }

        public HomeController(IPostAppService postAppService)
        {
            this.postAppService = postAppService;
        }

        public ActionResult Index(int pageNumber = 1)
        {
            PagedList<Post> posts = postAppService.GetAll(pageNumber, 10);

            return View();
        }

        public ActionResult Post(int id)
        {
            Post post = postAppService.GetById(id);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}