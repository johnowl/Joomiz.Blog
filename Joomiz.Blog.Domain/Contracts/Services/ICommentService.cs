using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Contracts.Services
{
    public interface ICommentService : IServiceBase<Comment>
    {
        void Approve(Comment comment, Author author);
        void Reject(Comment comment, Author author);
    }
}
