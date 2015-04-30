using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class AuthorPasswordIsRequiredRule : ValidationRule<Author>
    {
        public AuthorPasswordIsRequiredRule()
        {
            this.Specification = new AuthorPasswordIsRequiredSpec();
            this.Error = new ValidationError("Password", ErrorMessage.AuthorPasswordIsRequired);
        }
    }
}
