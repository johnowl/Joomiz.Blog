using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthorService authorService;

        public AuthenticationService(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public Author Login(string name, string password)
        {
            Author author = this.authorService.GetByName(name);

            if (author.Password == password)
                return author;

            return null;
        }
    }
}
