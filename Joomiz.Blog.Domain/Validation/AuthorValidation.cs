using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs;

namespace Joomiz.Blog.Domain.Validation
{
    public class AuthorValidation : Validation<Author>, IAuthorValidation
    {
        public AuthorValidation(IAuthorRepository authorRepository)
        {
            this.AddRule(new AuthorEmailAddressIsRequired(), new ValidationError("Email", ErrorMessage.AuthorEmailAddressIsRequired));
            this.AddRule(new AuthorEmailAddressIsValid(), new ValidationError("Email", ErrorMessage.AuthorEmailAddressIsInvalid));
            this.AddRule(new AuthorNameIsRequired(), new ValidationError("Name", ErrorMessage.AuthorNameIsRequired));
            this.AddRule(new AuthorNameLengthMustBeLessThan70Spec(), new ValidationError("Name", ErrorMessage.AuthorNameLengthMustBeLessThen70));
            this.AddRule(new AuthorPasswordIsRequired(), new ValidationError("Password", ErrorMessage.AuthorPasswordIsRequired));
            this.AddRule(new AuthorPasswordIsValid(), new ValidationError("Password", ErrorMessage.AuthorPasswordIsInvalid));
        }
    }
}
