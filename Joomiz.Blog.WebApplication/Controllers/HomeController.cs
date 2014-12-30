using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.WebApplication.ViewModels;
using Joomiz.Blog.WebApplication.ViewModels.Maps;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostAppService postAppService;
        private readonly ICommentAppService commentAppService;

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
            var posts = postAppService.GetAll(pageNumber, 50);
            var viewModel = new IndexViewModel(posts);

            return View(viewModel);
        }

        public ActionResult Post(int id)
        {
            Post post = postAppService.GetById(id, 1, 150);
            PostViewModel postViewModel = MapToViewModel.From(post);
            
            return View(postViewModel);
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