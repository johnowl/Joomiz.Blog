using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class AuthorNameMaximumLengthIs70Rule : ValidationRule<Author>
    {
        public AuthorNameMaximumLengthIs70Rule()
        {
            this.Specification = new AuthorNameMaximumLengthIs70Spec();
            this.Error = new ValidationError("Name", ErrorMessage.AuthorNameMaximumLengthIs70);
        }
    }
}
