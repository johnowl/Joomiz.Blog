using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Joomiz.Blog.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IAuthorService authorService;
        private readonly IAuthorValidation authorValidation;

        public AuthorAppService(IAuthorService authorService, IAuthorValidation authorValidation)
        {
            this.authorService = authorService;
            this.authorValidation = authorValidation;
        }

        public AuthorAppService()
        {
            var authorRepository = RepositoryFactory.GetAuthorRepository();
            this.authorValidation = ValidationFactory.GetAuthorValidation(authorRepository);
            this.authorService = ServiceFactory.GetAuthorService(authorRepository, this.authorValidation);
        }

        public Dictionary<string, string> GetValidationErrors()
        {
            return this.authorValidation.GetErrors();
        }        

        public Author GetById(int id)
        {
            return authorService.GetById(id);
        }

        public void ChangePassword(string name, string password, string newPassword)
        {
            this.authorService.ChangePassword(name, password, newPassword);
        }

        public PagedList<Author> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return authorService.GetAll(pageNumber, pageSize);
        }

        public bool Add(Author obj)
        {            
            return authorService.Add(obj);
        }

        public bool Update(Author obj)
        {
            return authorService.Update(obj);
        }

        public void Delete(int id)
        {
            authorService.Delete(id);
        }
    }
}
