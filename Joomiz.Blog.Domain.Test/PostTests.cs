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
        public void Shoud_Not_Add_Post_Without_An_Author()
        {
            var post = new Post();
            post.Title = "Post Title";
            post.Body = "Post body.";
            post.IsPublished = true;

            var postValidation = new PostValidation();
            var postRepository = new FakePostRepository();
            var postService = new PostService(postRepository, postValidation);

            bool result = postService.Add(post);            
            var errors = postValidation.GetErrors();
                        
            Assert.IsFalse(result);
            Assert.IsTrue(errors.Count == 1);
            Assert.IsTrue(errors[0].PropertyName == "Author.Id");
            
        }

        public class FakePostRepository : IPostRepository
        {
            public Post GetById(int id)
            {
                throw new NotImplementedException();
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
