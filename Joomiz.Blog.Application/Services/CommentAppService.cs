using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System;
using System.Collections.Generic;

namespace Joomiz.Blog.Application.Services
{
    public class CommentAppService : ICommentAppService
    {
        private readonly ICommentService commentService;
        private readonly IValidation<Comment> commentValidation;

        public CommentAppService()
        {
            this.commentValidation = ValidationFactory.GetCommentValidation();
            this.commentService = ServiceFactory.GetCommentService(RepositoryFactory.GetCommentRepository(), this.commentValidation);
        }

        public CommentAppService(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public IEnumerable<IValidationError> GetValidationErrors()
        {
            return this.commentValidation.GetErrors();
        }   

        public void Approve(int commentId, int authorId)
        {
            // the authorId parameter will be used in near future for logging purposes.

            commentService.Approve(commentId);       
        }

        public void Reject(int commentId, int authorId)
        {
            // the authorId parameter will be used in near future for logging purposes.

            commentService.Reject(commentId);
        }

        public Comment GetById(int id)
        {
            return commentService.GetById(id);
        }

        public PagedList<Comment> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return commentService.GetAll(pageNumber, pageSize);
        }

        public bool Add(Comment obj)
        {
            return commentService.Add(obj);
        }

        public bool Update(Comment obj)
        {
            return commentService.Update(obj);
        }

        public void Delete(int id)
        {
            commentService.Delete(id);
        }
    }
}
