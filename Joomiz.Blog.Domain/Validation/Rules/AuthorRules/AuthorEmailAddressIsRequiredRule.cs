using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class AuthorEmailAddressIsRequiredRule : ValidationRule<Author>
    {
        public AuthorEmailAddressIsRequiredRule()
        {
            this.Specification = new AuthorEmailAddressIsRequiredSpec();
            this.Error = new ValidationError("Email", ErrorMessage.AuthorEmailAddressIsRequired);
        }
    }
}
