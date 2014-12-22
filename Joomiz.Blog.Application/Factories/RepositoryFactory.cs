using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Infrastructure.Repository;

namespace Joomiz.Blog.Application.Factories
{
    public static class RepositoryFactory
    {
        public static IAuthorRepository GetAuthorRepository()
        {
            return new AuthorRepository();            
        }

        public static ICommentRepository GetCommentRepository()
        {
            return new CommentRepository();
        }

        public static IPostRepository GetPostRepository()
        {
            return new PostRepository();
        }

        public static ICategoryRepository GetCategoryRepository()
        {
            return new CategoryRepository();
        }
    }
}
