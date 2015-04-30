using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.CategorySpecs;

namespace Joomiz.Blog.Domain.Validation
{
    public class CategoryValidation : Validation<Category>, ICategoryValidation
    {
        public CategoryValidation(ICategoryRepository categoryRepository)
        {
            this.AddRule(new CategoryNameIsRequiredSpec(), new ValidationError("Name", ErrorMessage.CategoryNameIsRequired));
            this.AddRule(new CategoryNameMaximumLengthIs70Spec(), new ValidationError("Name", ErrorMessage.CategoryNameLengthMustBeLessThen71));
            this.AddRule(new CategoryNameMustBeUniqueSpec(categoryRepository), new ValidationError("Name", ErrorMessage.NotSet));
        }
    }
}
