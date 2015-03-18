using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;

namespace Joomiz.Blog.Domain.Validation
{
    public class CategoryValidation : Validation<Category>, ICategoryValidation
    {
    }
}
