using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.CommentSpecs
{
    public class CommentPostIdIsRequiredSpec : ISpecification<Comment>
    {
        public bool IsSatisfiedBy(Comment obj)
        {
            return obj.PostId > 0;
        }
    }
}
