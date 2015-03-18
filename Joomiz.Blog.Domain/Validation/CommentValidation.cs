using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;

namespace Joomiz.Blog.Domain.Validation
{
    public class CommentValidation : Validation<Comment>, ICommentValidation
    {
        public CommentValidation()
        {
            
        }
    }
}
