using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.PostSpecs
{
    public class PostTitleIsRequiredSpec : ISpecification<Post>
    {
        public bool IsSatisfiedBy(Post obj)
        {
            return string.IsNullOrWhiteSpace(obj.Title) == false;
        }
    }
}
