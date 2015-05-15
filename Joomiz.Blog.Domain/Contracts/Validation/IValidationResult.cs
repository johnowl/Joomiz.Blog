using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joomiz.Blog.Domain.Contracts.Validation
{
    public interface IValidationResult
    {
        IList<IValidationError> Errors { get; }
        bool IsValid { get; }
        void AddError(IValidationError error);
    }
}
