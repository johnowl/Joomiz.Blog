using Joomiz.Blog.Domain.Entities;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IAutenticationAppService
    {
        Author Login(string name, string password);        
    }
}
