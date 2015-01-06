using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Entities;
using System.Collections.Generic;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IAppServiceBase<T> where T : IEntity
    {
        T GetById(int id);
        PagedList<T> GetAll(int pageNumber = 1, int pageSize = 50);
        bool Add(T obj);
        bool Update(T obj);
        void Delete(int id);
        Dictionary<string, string> GetValidationErrors();
    }
}
