using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Joomiz.Blog.WebApplication.ViewModels.Base
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }        
        public PagedViewModel<CommentViewModel> Comments { get; set; }
    }
}