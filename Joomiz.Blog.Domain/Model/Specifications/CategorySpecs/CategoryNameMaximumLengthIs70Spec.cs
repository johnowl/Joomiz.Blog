using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.CategorySpecs
{
    public class CategoryNameMaximumLengthIs70Spec : ISpecification<Category>
    {
        public bool IsSatisfiedBy(Category category)
        {
            return category.Name.Length <= 70;
        }
    }
}
