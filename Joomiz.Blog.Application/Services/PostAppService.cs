using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joomiz.Blog.Application.Services
{
    public class PostAppService : IPostAppService
    {
        private readonly IPostService postService;
        private readonly ICommentService commentService;
        private readonly ICategoryService categoryService;
        private readonly IPostValidation postValidation;

        public PostAppService(IPostService postService, ICommentService commentService, ICategoryService categoryService, IPostValidation postValidation)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.categoryService = categoryService;
            this.postValidation = postValidation;
        }

        public PostAppService()
        {
            this.postValidation = ValidationFactory.GetPostValidation();
            this.postService = ServiceFactory.GetPostService(RepositoryFactory.GetPostRepository(), this.postValidation);
            this.commentService = ServiceFactory.GetCommentService(RepositoryFactory.GetCommentRepository(), null);
            this.categoryService = ServiceFactory.GetCategoryService(RepositoryFactory.GetCategoryRepository(), null);
        }

        public IEnumerable<IValidationError> GetValidationErrors()
        {
            return this.postValidation.GetErrors();
        }  

        public Post GetById(int id)
        {
            Post post = this.postService.GetById(id);
            post.Categories = this.categoryService.GetByPostId(id);

            return post;
        }

        public Post GetById(int id, int commentsPageNumber = 1, int commentsPageSize = 150)
        {
            Post post = this.postService.GetById(id);
            post.Categories = this.categoryService.GetByPostId(id);
            post.Comments = this.commentService.GetByPostId(id, commentsPageNumber, commentsPageSize);
            
            return post;
        }

        public PagedList<Post> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return this.postService.GetAll(pageNumber, pageSize);
        }

        public bool Add(Post obj)
        {            
            return this.postService.Add(obj);
        }

        public bool Update(Post obj)
        {
            return this.postService.Update(obj);
        }

        public void Delete(int id)
        {
            this.postService.Delete(id);
        }
    }
}
