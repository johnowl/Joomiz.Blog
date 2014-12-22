using Joomiz.Blog.Domain.Entities;
using System;


namespace Joomiz.Blog.Domain.Contracts.Repositories
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        Author GetByNameByPassword(string name, string password);
    }
}
