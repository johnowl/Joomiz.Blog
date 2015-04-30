using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.CategorySpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class CategoryNameIsRequiredRule : ValidationRule<Category>
    {
        public CategoryNameIsRequiredRule()
        {
            this.Specification = new CategoryNameIsRequiredSpec();
            this.Error = new ValidationError("Name", ErrorMessage.CategoryNameIsRequired);
        }
    }
}
