using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Application.Services
{
    public class AutenticationAppService : IAutenticationAppService
    {
        private readonly IAuthorService authorService;

        public AutenticationAppService(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public AutenticationAppService()
        {
            var authorRepository = RepositoryFactory.GetAuthorRepository();
            this.authorService = ServiceFactory.GetAuthorService(authorRepository, null);
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
