using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System;

namespace Joomiz.Blog.Domain.Contracts.Services
{
    public interface IAuthorService : IServiceBase<Author>
    {
        Author GetByName(string name);
        Author GetByNameByPassword(string name, string password);
        IValidationResult ChangePassword(string name, string password, string newPassword);
    }
}
