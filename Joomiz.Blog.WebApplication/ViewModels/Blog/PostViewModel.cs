using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Model;

namespace Joomiz.Blog.WebApplication.ViewModels.Blog
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            this.post = new Post();
            this.Post.Comments = new PagedList<Comment>();
            this.NewComment = new Comment();
        }

        public Comment NewComment { get; set; }

        private Post post;
        public Post Post
        {
            get
            {
                return this.post;
            }
            set
            {
                this.post = value;
                this.NewComment.PostId = this.post.Id;
            }
        }

        public bool PostHasNoComments()
        {
            return this.Post.Comments.Count == 0;
        }
    }
}