using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.PostSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.PostRules
{
    public class PostTitleIsRequiredRule : ValidationRule<Post>
    {
        public PostTitleIsRequiredRule()
        {
            this.Specification = new PostTitleIsRequiredSpec();
            this.Error = new ValidationError("Title", ErrorMessage.PostTitleIsRequired);
        }
    }
}
