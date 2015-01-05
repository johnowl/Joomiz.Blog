using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository authorRepository;
        private readonly IAuthorValidation authorValidation;

        public AuthorService(IAuthorRepository authorRepository, IAuthorValidation authorValidation)
        {
            this.authorRepository = authorRepository;
            this.authorValidation = authorValidation;
        }

        public Author GetById(int id)
        {
            return this.authorRepository.GetById(id);
        }

        public Author GetByName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            return this.authorRepository.GetByName(name);
        }

        public PagedList<Author> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return this.authorRepository.GetAll(pageNumber, pageSize);
        }

        public bool Add(Author obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            if (!this.authorValidation.Validate(obj))
                return false;

            this.authorRepository.Add(obj);

            return true;
        }

        public void ChangePassword(string name, string password, string newPassword)
        {
            Author author = this.GetByName(name);

            if (author == null)
                throw new Exception("Not found an author with provided information.");

            if(author.Password != password)
                throw new Exception("Not found an author with provided information.");

            author.Password = newPassword;

            this.authorRepository.Update(author);
        }

        public bool Update(Author obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            var author = this.GetById(obj.Id);

            if (author == null)
                throw new Exception(string.Format("Author {0} not found.", obj.Id));

            author.IsActive = obj.IsActive;
            author.Name = obj.Name;
            author.Email = obj.Email;

            if (!this.authorValidation.Validate(author))
                return false;

            this.authorRepository.Update(author);

            return true;
        }

        public void Delete(int id)
        {
            this.authorRepository.Delete(id);
        }
    }
}
