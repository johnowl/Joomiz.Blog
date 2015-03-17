﻿using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs
{
    public class AuthorNameLengthMustBeLessThan70Spec : ISpecification<Author>
    {
        public bool IsSatisfiedBy(Author author)
        {
            return author.Name.Length < 70;
        }
    }
}
