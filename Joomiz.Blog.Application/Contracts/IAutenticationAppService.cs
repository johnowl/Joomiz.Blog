using Joomiz.Blog.Domain.Entities;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IAutenticationAppService : IAppService
    {
        Author Login(string name, string password);        
    }
}
