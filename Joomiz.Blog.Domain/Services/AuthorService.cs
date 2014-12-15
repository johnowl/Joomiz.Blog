using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public Author GetById(int id)
        {
            return this.authorRepository.GetById(id);
        }

        public PagedList<Author> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return this.authorRepository.GetAll(pageNumber, pageSize);
        }

        public void Add(Author obj)
        {
            this.authorRepository.Add(obj);
        }

        public void Update(Author obj)
        {
            this.authorRepository.Update(obj);
        }

        public void Delete(int id)
        {
            this.authorRepository.Delete(id);
        }
    }
}
