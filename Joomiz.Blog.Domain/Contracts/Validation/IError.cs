using System;

namespace Joomiz.Blog.Domain.Contracts.Validation
{
    public interface IValidationError
    {
        string Message { get; }
        string PropertyName { get; }
    }
}
