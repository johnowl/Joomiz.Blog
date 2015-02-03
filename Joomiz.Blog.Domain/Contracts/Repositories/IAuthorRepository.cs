using Joomiz.Blog.Domain.Model;
using System;


namespace Joomiz.Blog.Domain.Contracts.Repositories
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Author GetByName(string name);
    }
}
