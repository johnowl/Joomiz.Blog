using System;
using System.ComponentModel.DataAnnotations;

namespace Joomiz.Blog.WebApplication.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Url { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Body { get; set; }
        public bool IsApproved { get; set; }
    }
}