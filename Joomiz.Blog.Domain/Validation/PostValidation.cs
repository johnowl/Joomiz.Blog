using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Validation
{
    public class PostValidation : IPostValidation
    {
        public bool Validate(Post obj)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetErrors()
        {
            throw new NotImplementedException();
        }
    }
}
