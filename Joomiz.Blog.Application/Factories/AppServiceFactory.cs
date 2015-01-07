using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Services;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Services;

namespace Joomiz.Blog.Application.Factories
{
    public static class AppServiceFactory
    {
        public static IAuthorAppService GetAuthorAppService()
        {
            return new AuthorAppService();
        }       

        public static ICommentAppService GetCommentAppService()
        {
            return new CommentAppService();
        }

        public static IPostAppService GetPostAppService()
        {
            return new PostAppService();
        }

        public static IAutenticationAppService GetAutenticationAppService()
        {
            return new AutenticationAppService();
        }
    }
}
