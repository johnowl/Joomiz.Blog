using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Validation;

namespace Joomiz.Blog.Application.Factories
{
    public static class ValidationFactory
    {
        public static IAuthorValidation GetAuthorValidation()
        {
            return new AuthorValidation();
        }

        public static ICategoryValidation GetCategoryValidation(ICategoryRepository categoryRepository)
        {
            return new CategoryValidation(categoryRepository);
        }

        public static ICommentValidation GetCommentValidation()
        {
            return new CommentValidation();
        }

        public static IPostValidation GetPostValidation()
        {
            return new PostValidation();
        }
    }
}
