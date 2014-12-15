using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Category GetById(int id)
        {
            return this.categoryRepository.GetById(id);
        }

        public PagedList<Category> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return this.categoryRepository.GetAll(pageNumber, pageSize);
        }

        public void Add(Category obj)
        {
            this.categoryRepository.Add(obj);
        }

        public void Update(Category obj)
        {
            this.categoryRepository.Update(obj);
        }

        public void Delete(int id)
        {
            this.categoryRepository.Delete(id);
        }
    }
}
