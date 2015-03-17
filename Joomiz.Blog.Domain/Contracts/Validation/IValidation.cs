using Joomiz.Blog.Domain.Contracts.Specification;
using Joomiz.Blog.Domain.Model;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Contracts.Validation
{
    public interface IValidation<T> where T : IEntity
    {
        IList<IValidationRule<T>> ValidationRules { get; }
        void AddRule(IValidationRule<T> rule);
        void AddRule(ISpecification<T> specification, IValidationError error);
        bool Validate(T obj);
        IEnumerable<IValidationError> GetErrors();
    }
}
