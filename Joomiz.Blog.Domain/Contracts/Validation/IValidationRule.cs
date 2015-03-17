using Joomiz.Blog.Domain.Contracts.Specification;
using Joomiz.Blog.Domain.Model;
using System;

namespace Joomiz.Blog.Domain.Contracts.Validation
{
    public interface IValidationRule<T> where T : IEntity
    {
        IValidationError Error { get; }
        ISpecification<T> Specification { get; }
    }
}
