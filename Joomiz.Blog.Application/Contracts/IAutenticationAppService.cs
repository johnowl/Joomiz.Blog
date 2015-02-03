using Joomiz.Blog.Domain.Model;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IAutenticationAppService : IAppService
    {
        Author Login(string name, string password);        
    }
}
