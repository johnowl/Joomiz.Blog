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
        private readonly ICommentValidation commentValidation;

        public CommentService(ICommentRepository commentRepository, ICommentValidation validation)
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

        public IValidationResult Add(Comment obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            obj.DateCreated = DateTime.UtcNow;

            var validationResult = this.commentValidation.Validate(obj);
            
            if(validationResult.IsValid)
                this.commentRepository.Add(obj);

            return validationResult;
        }

        public IValidationResult Update(Comment obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            var validationResult = this.commentValidation.Validate(obj);

            if (validationResult.IsValid)
                this.commentRepository.Update(obj);

            return validationResult;
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

        public int CountPendingComments()
        {
            return this.commentRepository.CountPendingComments();
        }
    }
}
