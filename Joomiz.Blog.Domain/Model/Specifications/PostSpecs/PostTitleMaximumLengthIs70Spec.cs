using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.PostSpecs
{
    public class PostTitleMaximumLengthIs70Spec : ISpecification<Post>
    {
        public bool IsSatisfiedBy(Post obj)
        {
            return obj.Title.Length <= 70;
        }
    }
}
