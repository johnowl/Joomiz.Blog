using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.CommentSpecs
{
    public class CommentBodyIsRequiredSpec : ISpecification<Comment>
    {
        public bool IsSatisfiedBy(Comment obj)
        {
            return string.IsNullOrWhiteSpace(obj.Body) == false;
        }
    }
}
