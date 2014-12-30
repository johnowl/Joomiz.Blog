using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IAuthorService authorService;

        public AuthorAppService(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public AuthorAppService()
        {
            this.authorService = ServiceFactory.GetAuthorService();
        }

        public Author GetById(int id)
        {
            return authorService.GetById(id);
        }

        public PagedList<Author> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return authorService.GetAll(pageNumber, pageSize);
        }

        public void Add(Author obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            authorService.Add(obj);
        }

        public void Update(Author obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            var author = authorService.GetById(obj.Id);

            if (author == null)
                throw new Exception(string.Format("Author {0} not found.", obj.Id));

            author.IsActive = obj.IsActive;
            author.Name = obj.Name;
            author.Email = obj.Email;            

            authorService.Update(obj);
        }

        public void Delete(int id)
        {
            authorService.Delete(id);
        }
    }
}
