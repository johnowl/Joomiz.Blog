using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs;
using Joomiz.Blog.Domain.Validation.Rules.AuthorRules;

namespace Joomiz.Blog.Domain.Validation
{
    public class AuthorValidation : ValidationEngine<Author>, IAuthorValidation
    {
        public AuthorValidation()
        {
            AddRule(new AuthorEmailAddressIsRequiredRule());
            AddRule(new AuthorEmailAddressIsValidRule());
            AddRule(new AuthorNameIsRequiredRule());
            AddRule(new AuthorNameMaximumLengthIs70Rule());
            AddRule(new AuthorPasswordIsRequiredRule());
            AddRule(new AuthorPasswordIsValidRule());
        }
    }
}
