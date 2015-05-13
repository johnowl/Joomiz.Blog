using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.PostSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.PostRules
{
    public class PostBodyIsRequiredRule : ValidationRule<Post>
    {
        public PostBodyIsRequiredRule()
        {
            this.Specification = new PostBodyIsRequiredSpec();
            this.Error = new ValidationError("Body", ErrorMessage.PostBodyIsRequired);
        }
    }
}
