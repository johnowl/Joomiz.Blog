using System;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Validation;

namespace Joomiz.Blog.Domain.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IValidation<Comment> commentValidation;

        public CommentService(ICommentRepository commentRepository, IValidation<Comment> validation)
        {
            this.commentRepository = commentRepository;
            this.commentValidation = validation;
        }
       
        public Comment GetById(int id)
        {
            return this.commentRepository.GetById(id);
        }

        public PagedList<Comment> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return this.commentRepository.GetAll(pageNumber, pageSize);
        }

        public bool Add(Comment obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            obj.DateCreated = DateTime.UtcNow;

            if (!this.commentValidation.Validate(obj))
                return false;            

            this.commentRepository.Add(obj);

            return true;
        }

        public bool Update(Comment obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            if (!this.commentValidation.Validate(obj))
                return false;

            this.commentRepository.Update(obj);

            return true;
        }

        public void Delete(int id)
        {
            this.commentRepository.Delete(id);
        }

        public PagedList<Comment> GetByPostId(int postId, int pageNumber = 1, int pageSize = 50)
        {
            return this.commentRepository.GetByPostId(postId, pageNumber, pageSize);
        }

        public void Approve(int commentId)
        {
            Comment comment = this.GetById(commentId);

            if (comment == null)
                throw new ArgumentNullException("Comment not found.");

            comment.Status = CommentStatus.Approved;

            this.Update(comment);
        }

        public void Reject(int commentId)
        {
            Comment comment = this.GetById(commentId);

            if (comment == null)
                throw new ArgumentNullException("Comment not found.");

            comment.Status = CommentStatus.Rejected;

            this.Update(comment);
        }
    }
}
