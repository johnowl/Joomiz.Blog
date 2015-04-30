using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.CommentSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.CommentRules
{
    public class CommentBodyIsRequiredRule : ValidationRule<Comment>
    {
        public CommentBodyIsRequiredRule()
        {
            this.Specification = new CommentBodyIsRequiredSpec();
            this.Error = new ValidationError("PostId", ErrorMessage.CommentBodyIsRequired);
        }
    }
}
