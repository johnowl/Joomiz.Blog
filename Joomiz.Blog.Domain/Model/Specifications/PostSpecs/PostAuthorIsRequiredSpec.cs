using Joomiz.Blog.Domain.Contracts.Specification;

namespace Joomiz.Blog.Domain.Model.Specifications.PostSpecs
{
    public class PostAuthorIsRequiredSpec : ISpecification<Post>
    {
        public bool IsSatisfiedBy(Post obj)
        {
            return obj.Author != null && obj.Author.Id > 0;
        }
    }
}
