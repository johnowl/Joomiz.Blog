using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.PostSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.PostRules
{
    public class PostTitleMaximumLengthIs70Rule : ValidationRule<Post>
    {
        public PostTitleMaximumLengthIs70Rule()
        {
            this.Specification = new PostTitleMaximumLengthIs70Spec();
            this.Error = new ValidationError("Title", ErrorMessage.PostTitleMaximumLengthIs70);
        }
    }
}
