﻿using Joomiz.Blog.Domain.Contracts.Specification;
using System;

namespace Joomiz.Blog.Domain.Model.Specifications.AuthorSpecs
{
    public class AuthorPasswordIsRequired : ISpecification<Author>
    {
        public bool IsSatisfiedBy(Author obj)
        {
            return string.IsNullOrEmpty(obj.Password) == false;
        }
    }
}
