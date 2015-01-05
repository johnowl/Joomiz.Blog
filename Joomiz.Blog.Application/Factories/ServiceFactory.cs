using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Services;

namespace Joomiz.Blog.Application.Factories
{
    public static class ServiceFactory
    {
        public static IAuthorService GetAuthorService(IAuthorRepository repository, IAuthorValidation validation)
        {            
            return new AuthorService(repository, validation);
        }

        public static ICategoryService GetCategoryService(ICategoryRepository repository, ICategoryValidation validation)
        {            
            return new CategoryService(repository, validation);
        }

        public static ICommentService GetCommentService(ICommentRepository repository, ICommentValidation validation)
        {            
            return new CommentService(repository, validation);
        }

        public static IPostService GetPostService(IPostRepository repository, IPostValidation validation)
        {
            return new PostService(repository, validation);
        }
    }
}
