using Joomiz.Blog.Domain.Contracts.Specification;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;

namespace Joomiz.Blog.Domain.Validation
{
    public class ValidationRule<T> : IValidationRule<T> where T: IEntity
    {
        public IValidationError Error { get; private set; }
        public ISpecification<T> Specification { get; private set; }

        public ValidationRule(ISpecification<T> specification, IValidationError error)
        {
            this.Specification = specification;
            this.Error = error;
        }
    }
}
