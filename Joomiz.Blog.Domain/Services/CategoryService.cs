using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IValidation<Category> categoryValidation;

        public CategoryService(ICategoryRepository categoryRepository, IValidation<Category> categoryValidation)
        {
            this.categoryRepository = categoryRepository;
            this.categoryValidation = categoryValidation;
        }

        public Category GetById(int id)
        {
            return this.categoryRepository.GetById(id);
        }

        public PagedList<Category> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return this.categoryRepository.GetAll(pageNumber, pageSize);
        }

        public bool Add(Category obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            obj.DateCreated = DateTime.UtcNow;

            if (!this.categoryValidation.Validate(obj))
                return false;            

            this.categoryRepository.Add(obj);

            return true;
        }

        public bool Update(Category obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            if (!this.categoryValidation.Validate(obj))
                return false;

            this.categoryRepository.Update(obj);

            return true;
        }

        public void Delete(int id)
        {
            this.categoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetByPostId(int postId)
        {
            return this.categoryRepository.GetByPostId(postId);
        }
    }
}
