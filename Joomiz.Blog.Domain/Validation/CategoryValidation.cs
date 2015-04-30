using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Validation.Rules.AuthorRules;

namespace Joomiz.Blog.Domain.Validation
{
    public class CategoryValidation : Validation<Category>, ICategoryValidation
    {
        public CategoryValidation(ICategoryRepository categoryRepository)
        {
            this.AddRule(new CategoryNameIsRequiredRule());
            this.AddRule(new CategoryNameMaximumLengthIs70Rule());
            this.AddRule(new CategoryNameMustBeUniqueRule(categoryRepository));
        }
    }
}
