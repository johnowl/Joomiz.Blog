using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.CommentSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.CommentRules
{
    public class CommentNameIsRequiredRule : ValidationRule<Comment>
    {
        public CommentNameIsRequiredRule()
        {
            this.Specification = new CommentNameIsRequiredSpec();
            this.Error = new ValidationError("Name", ErrorMessage.CommentNameIsRequired);
        }
    }
}
