using System;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Repositories;

namespace Joomiz.Blog.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void Approve(Comment comment, Author author)
        {
            this.commentRepository.Approve(comment, author);
        }

        public void Reject(Comment comment, Author author)
        {
            this.commentRepository.Reject(comment, author);
        }

        public Comment GetById(int id)
        {
            return this.commentRepository.GetById(id);
        }

        public PagedList<Comment> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return this.commentRepository.GetAll(pageNumber, pageSize);
        }

        public void Add(Comment obj)
        {
            this.commentRepository.Add(obj);
        }

        public void Update(Comment obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            this.commentRepository.Delete(id);
        }
    }
}
