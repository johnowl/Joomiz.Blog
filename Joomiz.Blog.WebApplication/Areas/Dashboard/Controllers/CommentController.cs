using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.WebApplication.Helpers;
using System;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Areas.Dashboard.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentAppService commentAppService;

        public CommentController(ICommentAppService commentAppService)
        {
            this.commentAppService = commentAppService;
        }

        public CommentController()
        {
            this.commentAppService = AppServiceFactory.GetCommentAppService();
        }
        
        [Authorize]
        public ActionResult Index(int pageNumber = 50)
        {
            PagedList<Comment> comments = this.commentAppService.GetAll(pageNumber);

            return View(comments);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Comment comment = this.commentAppService.GetById(id);

            if (comment == null)
                return new HttpNotFoundResult();

            return View(comment);
        }

        [Authorize]
        public ActionResult New()
        {
            return View();
        }

        
        [Authorize]
        [HttpPost]
        public ActionResult Save(Comment comment)
        {
            if (comment == null)
                throw new InvalidOperationException();

            if (comment.Id > 0)
            {
                if (!this.commentAppService.Update(comment))
                {
                    ViewBag.Error = "There are erros, please correct and try again.";
                    ControllerHelpers.AddErrors(this.commentAppService.GetValidationErrors(), ModelState);
                }
                else
                {
                    ViewBag.Message = "Comment successful updated.";
                }
            }
            else
            {
                if (!this.commentAppService.Add(comment))
                {
                    ViewBag.Error = "There are erros, please correct and try again.";
                    ControllerHelpers.AddErrors(this.commentAppService.GetValidationErrors(), ModelState);
                    RedirectToAction("New");
                }
                else
                {
                    ViewBag.Message = "Comment successful added.";
                }
            }

            return RedirectToAction("Edit", new { id = comment.Id });
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Comment comment = this.commentAppService.GetById(id);

            if (comment == null)
                return new HttpNotFoundResult();

            return View(comment);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            this.commentAppService.Delete(id);

            ViewBag.Message = "Comment successful deleted.";

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult ApproveComment(int id)
        {
            this.commentAppService.Approve(id, int.Parse(User.Identity.Name));

            ViewBag.Message = "Comment successful approved.";

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult RejectComment(int id)
        {
            this.commentAppService.Reject(id, int.Parse(User.Identity.Name));

            ViewBag.Message = "Comment successful rejected.";

            return RedirectToAction("Index");
        }
    }
}