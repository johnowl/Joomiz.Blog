using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.WebApplication.ActionFilters;
using Joomiz.Blog.WebApplication.Helpers;
using Joomiz.Blog.WebApplication.ViewModels;
using Joomiz.Blog.WebApplication.ViewModels.Blog;
using System;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostAppService postAppService;
        private readonly ICommentAppService commentAppService;

        public BlogController()
        {
            this.postAppService = AppServiceFactory.GetPostAppService();
            this.commentAppService = AppServiceFactory.GetCommentAppService();
        }

        public BlogController(IPostAppService postAppService, ICommentAppService commentAppService)
        {
            this.postAppService = postAppService;
            this.commentAppService = commentAppService;
        }

        public ActionResult Index(int pageNumber = 1)
        {
            var viewModel = new IndexViewModel();
            viewModel.Posts = postAppService.GetAll(pageNumber, 50);

            return View(viewModel);
        }

        [ImportModelStateFromTempData]
        public ActionResult Post(int id)
        {
            var viewModel = new PostViewModel();
            viewModel.Post = postAppService.GetById(id, 1, 150);

            return View(viewModel);
        }

        [HttpPost, ExportModelStateToTempData]
        public ActionResult AddComment(Comment comment)
        {
            var validationResult = this.commentAppService.Add(comment);

            if (validationResult.IsValid == false)
                ControllerHelpers.AddErrors(validationResult.Errors, ModelState);            

            return RedirectToAction("Post", new { id = comment.PostId });
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