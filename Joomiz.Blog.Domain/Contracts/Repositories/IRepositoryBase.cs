using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Joomiz.Blog.Domain.Entities;

namespace Joomiz.Blog.Domain.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T : IEntity
    {
        T GetById(int id);
        PagedList<T> GetAll(int pageNumber = 1, int pageSize = 50);
        IEnumerable<T> GetAll();
        void Add(T obj);
        void Update(T obj);
        void Delete(int id);
    }
}
