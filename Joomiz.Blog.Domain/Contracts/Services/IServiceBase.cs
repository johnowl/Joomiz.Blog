using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Contracts.Services
{
    public interface IServiceBase<T> where T : IEntity
    {
        T GetById(int id);
        PagedList<T> GetAll(int pageNumber = 1, int pageSize = 50);
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
