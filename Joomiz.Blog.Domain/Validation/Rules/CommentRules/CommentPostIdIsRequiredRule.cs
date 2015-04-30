using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.CommentSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.CommentRules
{
    public class CommentPostIdIsRequiredRule : ValidationRule<Comment>
    {
        public CommentPostIdIsRequiredRule()
        {
            this.Specification = new CommentPostIdIsRequiredSpec();
            this.Error = new ValidationError("PostId", ErrorMessage.CommentPostIdIsRequired);
        }
    }
}
