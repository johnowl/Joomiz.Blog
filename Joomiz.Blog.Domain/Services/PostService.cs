using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IPostValidation postValidation;

        public PostService(IPostRepository postRepository, IPostValidation postValidation)
        {
            this.postRepository = postRepository;
            this.postValidation = postValidation;
        }

        public Post GetById(int id)
        {
            return this.postRepository.GetById(id);
        }

        public PagedList<Post> GetAll(int pageNumber, int pageSize)
        {
            return this.postRepository.GetAll(pageNumber, pageSize);
        }

        public bool Add(Post obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            obj.DateCreated = DateTime.UtcNow;

            if (!this.postValidation.Validate(obj))
                return false;            

            this.postRepository.Add(obj);

            return true;
        }

        public bool Update(Post obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            if (!this.postValidation.Validate(obj))
                return false;

            this.postRepository.Update(obj);

            return true;
        }

        public void Delete(int id)
        {
            this.postRepository.Delete(id);
        }
    }
}
