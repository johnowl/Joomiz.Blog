using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Contracts.Services
{
    public interface ICommentService : IServiceBase<Comment>
    {
        void Approve(int commentId);
        void Reject(int commentId);
        PagedList<Comment> GetByPostId(int postId, int pageNumber = 1, int pageSize = 50);
    }
}
