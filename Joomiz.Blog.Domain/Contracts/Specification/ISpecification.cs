using Joomiz.Blog.Domain.Model;

namespace Joomiz.Blog.Domain.Contracts.Specification
{
    public interface ISpecification<T> where T : IEntity
    {
        bool IsSatisfiedBy(T obj);
    }
}
