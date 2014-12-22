using Joomiz.Blog.Application.Contracts;
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


        public Post GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PagedList<Post> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            throw new NotImplementedException();
        }

        public void Add(Post obj)
        {
            throw new NotImplementedException();
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
