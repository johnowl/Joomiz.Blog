using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Contracts.Services
{
    public interface IAuthorService : IServiceBase<Author>
    {
        Author GetByNameByPassword(string name, string password);
    }
}
