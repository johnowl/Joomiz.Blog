using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.WebApplication.ActionFilters;
using Joomiz.Blog.WebApplication.ViewModels;
using Joomiz.Blog.WebApplication.ViewModels.Base;
using Joomiz.Blog.WebApplication.ViewModels.Maps;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostAppService postAppService;

        public BlogController()
        {
            this.postAppService = AppServiceFactory.GetPostService();
        }

        public BlogController(IPostAppService postAppService)
        {
            this.postAppService = postAppService;
        }

        public ActionResult Index(int pageNumber = 1)
        {
            var posts = postAppService.GetAll(pageNumber, 50);
            var viewModel = new PostListViewModel(posts);

            return View(viewModel);
        }

        [ImportModelStateFromTempData]
        public ActionResult Post(int id)
        {
            Post post = postAppService.GetById(id, 1, 150);
            PostSingleViewModel viewModel = new PostSingleViewModel(post);

            if (ViewData["commentViewModel"] != null)
                viewModel.NewComment = ViewData["newCommentViewModel"] as AddCommentViewModel;

            return View(viewModel);
        }

        [HttpPost, ExportModelStateToTempData]
        public ActionResult AddComment(AddCommentViewModel commentViewModel)
        {
            if (ModelState.IsValid)
            {
                // gravar o comentário
            }            

            ViewData["newCommentViewModel"] = commentViewModel;
            ViewData["ModelState"] = ModelState;

            return RedirectToAction("Post", new { id = commentViewModel.PostId });
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