using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.CategorySpecs
{
    public class CategoryNameIsRequiredSpec : ISpecification<Category>
    {
        public bool IsSatisfiedBy(Category obj)
        {
            return string.IsNullOrWhiteSpace(obj.Name) == false;
        }
    }
}
