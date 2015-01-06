using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Entities;

namespace Joomiz.Blog.WebApplication.ViewModels.Blog
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            this.Posts = new PagedList<Post>();
        }

        public PagedList<Post> Posts { get; set; }

        public bool IsEmpty()
        {
            return this.Posts.Count == 0;
        }
    }
}