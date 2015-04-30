using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Specification;
using System;

namespace Joomiz.Blog.Domain.Model.Specifications.CategorySpecs
{
    public class CategoryNameMustBeUniqueSpec : ISpecification<Category>
    {
        private readonly ICategoryRepository Repository { get; set; }

        public CategoryNameMustBeUniqueSpec(ICategoryRepository repository)
        {
            this.Repository = repository;
        }

        public bool IsSatisfiedBy(Category obj)
        {
            var searchCategory = this.Repository.GetByName(obj.Name);

            if (searchCategory != null && searchCategory.Id != obj.Id)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}