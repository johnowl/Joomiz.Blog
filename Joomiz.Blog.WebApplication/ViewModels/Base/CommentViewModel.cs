using System;
using System.ComponentModel.DataAnnotations;

namespace Joomiz.Blog.WebApplication.ViewModels.Base
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
        public bool IsApproved { get; set; }
        public DateTime DateCreated { get; set; }
    }
}