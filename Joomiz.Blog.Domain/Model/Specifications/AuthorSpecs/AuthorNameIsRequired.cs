﻿using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs
{
    public class AuthorNameIsRequired : ISpecification<Author>
    {
        public bool IsSatisfiedBy(Author obj)
        {
            return string.IsNullOrEmpty(obj.Name) == false;                
        }
    }
}
