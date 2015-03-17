using Joomiz.Blog.Domain.Contracts.Validation;

namespace Joomiz.Blog.Domain.Validation
{
    public class ValidationError : IValidationError
    {
        public string Message { get; private set; }
        public string PropertyName { get; private set; }

        public ValidationError(string propertyName, string message)
        {
            this.PropertyName = propertyName;
            this.Message = message;
        }
    }
}
