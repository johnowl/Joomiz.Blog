using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Services;

namespace Joomiz.Blog.Application.Factories
{
    public static class ServiceFactory
    {
        public static IAuthorService GetAuthorService(IAuthorRepository repository, IValidation<Author> validation)
        {            
            return new AuthorService(repository, validation);
        }

        public static ICategoryService GetCategoryService(ICategoryRepository repository, IValidation<Category> validation)
        {            
            return new CategoryService(repository, validation);
        }

        public static ICommentService GetCommentService(ICommentRepository repository, IValidation<Comment> validation)
        {            
            return new CommentService(repository, validation);
        }

        public static IPostService GetPostService(IPostRepository repository, IValidation<Post> validation)
        {
            return new PostService(repository, validation);
        }

        public static IAuthenticationService GetAuthenticationService(IAuthorService authorService)
        {
            return new AuthenticationService(authorService);
        }
    }
}
