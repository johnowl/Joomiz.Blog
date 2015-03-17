using Joomiz.Blog.Domain.Contracts.Validation;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Helpers
{
    public static class ControllerHelpers
    {
        public static void AddErrors(IEnumerable<IValidationError> errors, ModelStateDictionary modelState, string prefix = "")
        {
            if (prefix != "")
                prefix += ".";

            foreach (IValidationError error in errors)
            {
                modelState.AddModelError(string.Concat(prefix, error.PropertyName), error.Message);
            }
        }
    }
}