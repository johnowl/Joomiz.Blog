using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.PostSpecs;

namespace Joomiz.Blog.Domain.Validation
{
    public class PostValidation : Validation<Post>, IPostValidation
    {
        public PostValidation()
        {
            this.AddRule(new PostTitleIsRequiredSpec(), new ValidationError("Title", ErrorMessage.PostTitleIsRequired));
            this.AddRule(new PostTitleMaximumLengthIs70Spec(), new ValidationError("Title", ErrorMessage.PostTitleMaximumLengthIs70));
            this.AddRule(new PostBodyIsRequiredSpec(), new ValidationError("Body", ErrorMessage.PostBodyIsRequired));
            this.AddRule(new PostAuthorIsRequiredSpec(), new ValidationError("Author.Id", ErrorMessage.PostAuthorIsRequired)); 
        }
    }
}
