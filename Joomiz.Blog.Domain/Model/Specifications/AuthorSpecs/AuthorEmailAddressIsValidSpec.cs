using Joomiz.Blog.Domain.Contracts.Specification;
using System;

namespace Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs
{
    public class AuthorEmailAddressIsValidSpec : ISpecification<Author>
    {
        public bool IsSatisfiedBy(Author obj)
        {
            // TODO: change this validation to use REGEX for best results
            return obj.Email.Contains("@");
        }
    }
}
