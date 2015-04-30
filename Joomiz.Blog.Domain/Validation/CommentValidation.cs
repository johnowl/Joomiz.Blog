using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Validation.Rules.CommentRules;

namespace Joomiz.Blog.Domain.Validation
{
    public class CommentValidation : Validation<Comment>, ICommentValidation
    {
        public CommentValidation()
        {
            AddRule(new CommentNameIsRequiredRule());
            AddRule(new CommentPostIdIsRequiredRule());
            AddRule(new CommentBodyIsRequiredRule());
        }
    }
}
