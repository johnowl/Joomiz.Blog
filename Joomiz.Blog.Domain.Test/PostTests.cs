using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Domain.Services;
using Joomiz.Blog.Domain.Validation;
using Joomiz.Blog.Domain.Contracts.Repositories;
using System.Collections.Generic;
using Joomiz.Blog.Domain.Common;

namespace Joomiz.Blog.Domain.Test
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void Shoud_Not_Add_Post_Without_Author()
        {
            var post = new Post();
            post.Title = "Post Title";
            post.Body = "Post body.";
            post.IsPublished = true;

            var postValidation = new PostValidation();
            var postRepository = new FakePostRepository();
            var postService = new PostService(postRepository, postValidation);

            var result = postService.Add(post);
                        
            Assert.IsFalse(result.IsValid);
            Assert.IsTrue(result.Errors.Count == 1);
            Assert.IsTrue(result.Errors[0].PropertyName == "Author.Id");
            
        }

        private class FakePostRepository : IPostRepository
        {
            public List<Post> Posts { get; set; }

            public FakePostRepository()
            {
                this.Posts = new List<Post>();
            }

            public Post GetById(int id)
            {
                return this.Posts.Find(x => x.Id == id);
            }

            public PagedList<Post> GetAll(int pageNumber = 1, int pageSize = 50)
            {
                throw new NotImplementedException();
            }

            public IEnumerable<Post> GetAll()
            {
                throw new NotImplementedException();
            }

            public void Add(Post obj)
            {
                this.Posts.Add(obj);
            }

            public void Update(Post obj)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }
        }
    }
}
