using Joomiz.Blog.Domain.Entities;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IAppServiceBase<T> where T : IEntity
    {
        T GetById(int id);
        PagedList<T> GetAll(int pageNumber = 1, int pageSize = 50);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
