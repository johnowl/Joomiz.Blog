using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.CategorySpecs;

namespace Joomiz.Blog.Domain.Validation.Rules.AuthorRules
{
    public class CategoryNameMaximumLengthIs70Rule : ValidationRule<Category>
    {
        public CategoryNameMaximumLengthIs70Rule()
        {
            this.Specification = new CategoryNameMaximumLengthIs70Spec();
            this.Error = new ValidationError("Name", ErrorMessage.CategoryNameMaximumLengthIs70);
        }
    }
}
