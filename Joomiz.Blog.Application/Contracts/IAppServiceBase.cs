using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System.Collections.Generic;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IAppServiceBase<T> where T : IEntity
    {
        T GetById(int id);
        PagedList<T> GetAll(int pageNumber = 1, int pageSize = 50);
        IValidationResult Add(T obj);
        IValidationResult Update(T obj);
        void Delete(int id);
    }
}
