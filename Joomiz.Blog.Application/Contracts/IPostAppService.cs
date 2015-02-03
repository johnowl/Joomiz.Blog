using Joomiz.Blog.Domain.Model;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IPostAppService : IAppServiceBase<Post>, IAppService
    {
        Post GetById(int id, int commentsPageNumber = 1, int commentsPageSize = 150);
    }
}
