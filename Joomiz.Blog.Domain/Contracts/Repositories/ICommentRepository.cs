using Joomiz.Blog.Domain.Entities;
using System;


namespace Joomiz.Blog.Domain.Contracts.Repositories
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {
        void Approve(Comment comment, Author author);
        void Reject(Comment comment, Author author);
    }
}
