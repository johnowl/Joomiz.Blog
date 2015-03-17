using Joomiz.Blog.Domain.Contracts.Specification;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Validation
{
    public class Validation<T> : IValidation<T> where T : IEntity
    {
        public IList<IValidationRule<T>> ValidationRules { get; private set; }
        private IList<IValidationError> ErrorList { get; set; }

        public Validation()
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

        public bool Validate(T obj)
        {
            this.ErrorList = new List<IValidationError>();

            foreach (IValidationRule<T> rule in this.ValidationRules)
            {
                if (rule.Specification.IsSatisfiedBy(obj) == false)
                {
                    this.ErrorList.Add(rule.Error);
                }
            }

            return this.ErrorList.Count == 0;
        }

        public IEnumerable<IValidationError> GetErrors()
        {
            return this.ErrorList;
        }
    }
}
