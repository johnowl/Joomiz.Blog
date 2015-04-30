using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class AuthorEmailAddressIsValidRule: ValidationRule<Author>
    {
        public AuthorEmailAddressIsValidRule()
        {
            this.Specification = new AuthorEmailAddressIsValidSpec();
            this.Error = new ValidationError("Email", ErrorMessage.AuthorEmailAddressIsInvalid);
        }
    }
}
