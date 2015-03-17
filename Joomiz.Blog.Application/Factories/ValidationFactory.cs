using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Validation;

namespace Joomiz.Blog.Application.Factories
{
    public static class ValidationFactory
    {
        public static IValidation<Author> GetAuthorValidation(IAuthorRepository authorRepository)
        {
            return new AuthorValidation(authorRepository);
        }

        public static IValidation<Category> GetCategoryValidation()
        {
            return new CategoryValidation();
        }

        public static IValidation<Comment> GetCommentValidation()
        {
            return new CommentValidation();
        }

        public static IValidation<Post> GetPostValidation()
        {
            return new PostValidation();
        }
    }
}
