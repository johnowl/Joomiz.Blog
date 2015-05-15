using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.PostSpecs;
using Joomiz.Blog.Domain.Validation.Rules.PostRules;

namespace Joomiz.Blog.Domain.Validation
{
    public class PostValidation : ValidationEngine<Post>, IPostValidation
    {
        public PostValidation()
        {
            this.AddRule(new PostTitleIsRequiredRule());
            this.AddRule(new PostTitleMaximumLengthIs70Rule());
            this.AddRule(new PostBodyIsRequiredRule());
            this.AddRule(new PostAuthorIsRequiredRule());            
        }
    }
}
