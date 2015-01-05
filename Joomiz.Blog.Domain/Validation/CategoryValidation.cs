using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
namespace Joomiz.Blog.Domain.Validation
{
    public class CategoryValidation : ICategoryValidation
    {
        public bool Validate(Category obj)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetErrors()
        {
            throw new NotImplementedException();
        }
    }
}
