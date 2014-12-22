using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Services;

namespace Joomiz.Blog.Application.Factories
{
    public static class ServiceFactory
    {
        public static IAuthorService GetAuthorService()
        {
            IAuthorRepository repository = RepositoryFactory.GetAuthorRepository();
            return new AuthorService(repository);
        }

        public static ICategoryService GetCategoryService()
        {
            ICategoryRepository repository = RepositoryFactory.GetCategoryRepository();
            return new CategoryService(repository);
        }

        public static ICommentService GetCommentService()
        {
            ICommentRepository repository = RepositoryFactory.GetCommentRepository();
            return new CommentService(repository);
        }

        public static IPostService GetPostService()
        {
            IPostRepository repository = RepositoryFactory.GetPostRepository();
            return new PostService(repository);
        }
    }
}
