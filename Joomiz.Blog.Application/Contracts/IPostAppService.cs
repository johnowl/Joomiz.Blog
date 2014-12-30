using Joomiz.Blog.Domain.Entities;

namespace Joomiz.Blog.Application.Contracts
{
    public interface IPostAppService : IAppServiceBase<Post>
    {
        Post GetById(int id, int commentsPageNumber = 1, int commentsPageSize = 150);
    }
}
