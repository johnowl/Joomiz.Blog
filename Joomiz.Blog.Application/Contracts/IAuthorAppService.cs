using Joomiz.Blog.Domain.Entities;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IAuthorAppService : IAppServiceBase<Author>, IAppService
    {
        void ChangePassword(string name, string password, string newPassword);
    }
}
