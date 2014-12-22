using Joomiz.Blog.Domain.Entities;

namespace Joomiz.Blog.Application.Contracts
{
    public interface ICommentAppService : IAppServiceBase<Comment>
    {
        void Approve(int commentId, int authorId);
        void Reject(int commentId, int authorId);
    }
}
