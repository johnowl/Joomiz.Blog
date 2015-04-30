using Joomiz.Blog.Domain.Contracts.Specification;
using System;

namespace Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs
{
    public class AuthorPasswordIsValidSpec : ISpecification<Author>
    {
        public bool IsSatisfiedBy(Author obj)
        {
            return obj.Password.Length >= 8 && obj.Password.Length < 13;
        }
    }
}
