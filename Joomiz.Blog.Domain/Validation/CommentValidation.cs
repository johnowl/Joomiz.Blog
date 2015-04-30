using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Model.Specifications.CommentSpecs;

namespace Joomiz.Blog.Domain.Validation
{
    public class CommentValidation : Validation<Comment>, ICommentValidation
    {
        public CommentValidation()
        {            
            this.AddRule(new CommentNameIsRequiredSpec(), new ValidationError("Name", ErrorMessage.CommentNameIsRequired));
            this.AddRule(new CommentPostIdIsRequiredSpec(), new ValidationError("PostId", ErrorMessage.CommentPostIdIsRequired));
            this.AddRule(new CommentBodyIsRequiredSpec(), new ValidationError("Body", ErrorMessage.CommentBodyIsRequired));
        }
    }
}
