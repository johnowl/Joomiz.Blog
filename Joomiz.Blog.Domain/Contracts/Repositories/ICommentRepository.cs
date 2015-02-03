using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Model;
using System;
using System.Collections.Generic;


namespace Joomiz.Blog.Domain.Contracts.Repositories
{
    public interface ICommentRepository : IRepositoryBase<Comment>
    {        
        PagedList<Comment> GetByPostId(int postId, int pageNumber = 1, int pageSize = 50);        
    }
}
