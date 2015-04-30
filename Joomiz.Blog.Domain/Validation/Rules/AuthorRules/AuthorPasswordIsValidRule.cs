using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class AuthorPasswordIsValidRule : ValidationRule<Author>
    {
        public AuthorPasswordIsValidRule()
        {
            this.Specification = new AuthorPasswordIsValidSpec();
            this.Error = new ValidationError("Password", ErrorMessage.AuthorPasswordIsInvalid);
        }
    }
}
