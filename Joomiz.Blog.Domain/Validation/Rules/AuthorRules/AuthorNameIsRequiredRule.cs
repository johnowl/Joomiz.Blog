using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class AuthorNameIsRequiredRule : ValidationRule<Author>
    {
        public AuthorNameIsRequiredRule()
        {
            this.Specification = new AuthorNameIsRequiredSpec();
            this.Error = new ValidationError("Name", ErrorMessage.AuthorNameIsRequired);
        }
    }
}
