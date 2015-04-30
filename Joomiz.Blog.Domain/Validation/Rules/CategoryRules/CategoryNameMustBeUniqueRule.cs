using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.CategorySpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class CategoryNameMustBeUniqueRule : ValidationRule<Category>
    {
        public CategoryNameMustBeUniqueRule(ICategoryRepository repository)
        {
            this.Specification = new CategoryNameMustBeUniqueSpec(repository);
            this.Error = new ValidationError("Name", ErrorMessage.AuthorEmailAddressIsRequired);
        }
    }
}
