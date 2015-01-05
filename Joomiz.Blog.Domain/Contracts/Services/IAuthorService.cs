using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Contracts.Services
{
    public interface IAuthorService : IServiceBase<Author>
    {
        Author GetByName(string name);
        void ChangePassword(string name, string password, string newPassword);
    }
}
