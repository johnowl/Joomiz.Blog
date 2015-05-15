using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
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

        public IValidationResult Add(Post obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            obj.DateCreated = DateTime.UtcNow;

            var validationResult = this.postValidation.Validate(obj);

            if (validationResult.IsValid)
                this.postRepository.Add(obj);

            return validationResult;
        }

        public IValidationResult Update(Post obj)
        {
            if (obj == null)
                throw new NullReferenceException("obj");

            var validationResult = this.postValidation.Validate(obj);

            if (validationResult.IsValid)
                this.postRepository.Update(obj);

            return validationResult;
        }

        public void Delete(int id)
        {
            this.postRepository.Delete(id);
        }
    }
}
