using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.PostSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.PostRules
{
    public class PostAuthorIsRequiredRule : ValidationRule<Post>
    {
        public PostAuthorIsRequiredRule()
        {
            this.Specification = new PostAuthorIsRequiredSpec();
            this.Error = new ValidationError("Author", ErrorMessage.PostAuthorIsRequired);
        }
    }
}
