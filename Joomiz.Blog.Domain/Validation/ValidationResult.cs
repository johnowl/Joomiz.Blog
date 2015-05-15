using Joomiz.Blog.Domain.Contracts.Validation;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Validation
{
    public class ValidationResult : IValidationResult
    {

        public IList<IValidationError> Errors { get; private set; }

        public bool IsValid { get { return this.Errors.Count == 0; } }

        public ValidationResult()
        {
            this.Errors = new List<IValidationError>();
        }

        public void AddError(IValidationError error)
        {
            this.AddError(error);
        }
    }
}
