using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.WebApplication.ViewModels.Base;
using Joomiz.Blog.WebApplication.ViewModels.Maps;

namespace Joomiz.Blog.WebApplication.ViewModels
{
    public class PostSingleViewModel
    {
        private PostViewModel post;
        public PostViewModel Post
        {
            get { return this.post; }
            set
            {
                this.post = value;
                
                if (this.NewComment == null)
                    this.NewComment = new AddCommentViewModel();

                this.NewComment.PostId = value.Id;
            }
        }

        public AddCommentViewModel NewComment { get; set; }

        public PostSingleViewModel()
        {
            this.NewComment = new AddCommentViewModel();
            this.Post = new PostViewModel();            
        }

        public PostSingleViewModel(Post post) : this()
        {
            this.Post = MapToViewModel.From(post);
        }
    }
}