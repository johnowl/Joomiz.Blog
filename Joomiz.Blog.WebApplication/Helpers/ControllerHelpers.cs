using System.Collections.Generic;
using System.Web.Mvc;

namespace Joomiz.Blog.WebApplication.Helpers
{
    public static class ControllerHelpers
    {
        public static void AddErrors(Dictionary<string, string> errors, ModelStateDictionary modelState, string prefix = "")
        {
            if (prefix != "")
                prefix += ".";

            foreach (KeyValuePair<string, string> error in errors)
            {
                modelState.AddModelError(string.Concat(prefix, error.Key), error.Value);
            }
        }
    }
}