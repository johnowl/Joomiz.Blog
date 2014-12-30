using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Entities;
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

        public PostAppService(IPostService postService, ICommentService commentService, ICategoryService categoryService)
        {
            this.postService = postService;
            this.commentService = commentService;
            this.categoryService = categoryService;
        }

        public PostAppService()
        {
            this.postService = ServiceFactory.GetPostService();
            this.commentService = ServiceFactory.GetCommentService();
            this.categoryService = ServiceFactory.GetCategoryService();
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
            post.Comments = this.commentService.GetByPostId(commentsPageNumber, commentsPageSize);
            
            return post;
        }

        public PagedList<Post> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return this.postService.GetAll(pageNumber, pageSize);
        }

        public void Add(Post obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            this.postService.Add(obj);
        }

        public void Update(Post obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");            

            this.postService.Update(obj);
        }

        public void Delete(int id)
        {
            this.postService.Delete(id);
        }
    }
}
