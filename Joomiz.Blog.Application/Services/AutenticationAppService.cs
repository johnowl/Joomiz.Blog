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
        private readonly IAuthorValidation authorValidation;

        public AutenticationAppService(IAuthorService authorService, IAuthorValidation authorValidation)
        {
            this.authorService = authorService;
            this.authorValidation = authorValidation;
        }

        public AutenticationAppService()
        {
            var authorRepository = RepositoryFactory.GetAuthorRepository();
            this.authorValidation = ValidationFactory.GetAuthorValidation(authorRepository);
            this.authorService = ServiceFactory.GetAuthorService(authorRepository, authorValidation);
        }

        public Author Login(string name, string password)
        {           
            Author author = this.authorService.GetByName(name);

            if (author.Password == password)
                return author;

            return null;
        }

        public void ChangePassword(string name, string password, string newPassword)
        {
            this.authorService.ChangePassword(name, password, newPassword);
        }
    }
}
