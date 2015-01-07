using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Entities;
using System.Web.Mvc;
using System.Web.Security;

namespace Joomiz.Blog.WebApplication.Areas.Dashboard.Controllers
{
    public class AutenticationController : Controller
    {
        private readonly IAutenticationAppService autenticationAppService;

        public AutenticationController()
        {
            this.autenticationAppService = AppServiceFactory.GetAutenticationAppService();
        }

        public AutenticationController(IAutenticationAppService autenticationAppService)
        {
            this.autenticationAppService = autenticationAppService;
        }

        // GET: Dashboard/Autentication
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string user, string password)
        {
            Author author = this.autenticationAppService.Login(user, password);

            if(author != null)
            {
                FormsAuthentication.SetAuthCookie(author.Id.ToString(), false);
                return RedirectToAction("Index", "PostController");
            }
            else
            {
                ModelState.AddModelError("Login", "Username or password incorrect.");
                return View();
            }            
        }
    }
}