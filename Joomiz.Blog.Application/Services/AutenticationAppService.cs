using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Contracts.Services;
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
            this.authorService = ServiceFactory.GetAuthorService();
        }

        public Author Login(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            return this.authorService.GetByNameByPassword(name, password);
        }

        public void ChangePassword(string name, string password, string newPassword)
        {
            Author author = this.authorService.GetByNameByPassword(name, password);

            if (author == null)
                throw new Exception("Not found an author with provided information.");

            author.Password = newPassword;

            this.authorService.Update(author);
        }
    }
}
