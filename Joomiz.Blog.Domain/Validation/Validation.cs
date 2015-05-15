using Joomiz.Blog.Domain.Contracts.Specification;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Validation
{
    public class ValidationEngine<T> : IValidationEngine<T> where T : IEntity
    {
        public IList<IValidationRule<T>> ValidationRules { get; private set; }

        public ValidationEngine()
        {
            this.ValidationRules = new List<IValidationRule<T>>();
        }        

        public void AddRule(IValidationRule<T> rule)
        {
            this.ValidationRules.Add(rule);
        }

        public void AddRule(ISpecification<T> specification, IValidationError error)
        {
            this.ValidationRules.Add(new ValidationRule<T>(specification, error));
        }

        public IValidationResult Validate(T obj)
        {
            var result = new ValidationResult();

            foreach (IValidationRule<T> rule in this.ValidationRules)
            {
                if (rule.Specification.IsSatisfiedBy(obj) == false)
                {
                    result.AddError(rule.Error);
                }
            }

            return result;
        }
        
    }
}
