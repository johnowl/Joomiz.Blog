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
        private readonly IAuthenticationService authenticationService;

        public AutenticationAppService(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        public AutenticationAppService()
        {
            var authorRepository = RepositoryFactory.GetAuthorRepository();
            var authorService = ServiceFactory.GetAuthorService(authorRepository, null);

            this.authenticationService = ServiceFactory.GetAuthenticationService(authorService);
        }

        public Author Login(string name, string password)
        {
            return this.authenticationService.Login(name, password);
        }
    }
}
