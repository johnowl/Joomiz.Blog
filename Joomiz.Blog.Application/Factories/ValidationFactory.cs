using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Validation;

namespace Joomiz.Blog.Application.Factories
{
    public static class ValidationFactory
    {
        public static IAuthorValidation GetAuthorValidation(IAuthorRepository authorRepository)
        {
            return new AuthorValidation(authorRepository);
        }

        public static ICategoryValidation GetCategoryValidation()
        {
            return new CategoryValidation();
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
