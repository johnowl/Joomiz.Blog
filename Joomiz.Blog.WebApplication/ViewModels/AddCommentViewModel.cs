using System;
using System.ComponentModel.DataAnnotations;

namespace Joomiz.Blog.WebApplication.ViewModels
{
    public class AddCommentViewModel
    {
        [Required]
        public int PostId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Url { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Body { get; set; }
    }
}