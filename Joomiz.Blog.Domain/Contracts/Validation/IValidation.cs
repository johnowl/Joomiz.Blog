using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Contracts.Validation
{
    public interface IValidation<T>
    {
        bool Validate(T obj);
        Dictionary<string, string> GetErrors();
    }
}
