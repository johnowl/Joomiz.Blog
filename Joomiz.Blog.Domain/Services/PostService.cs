using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Entities;
using System;

namespace Joomiz.Blog.Domain.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public Post GetById(int id)
        {
            return this.postRepository.GetById(id);
        }

        public PagedList<Post> GetAll(int pageNumber, int pageSize)
        {
            return this.postRepository.GetAll(pageNumber, pageSize);
        }

        public void Add(Post obj)
        {
            this.postRepository.Add(obj);
        }

        public void Update(Post obj)
        {
            this.postRepository.Update(obj);
        }

        public void Delete(int id)
        {
            this.postRepository.Delete(id);
        }
    }
}
