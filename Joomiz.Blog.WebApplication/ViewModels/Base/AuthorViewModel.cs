using System;
using System.ComponentModel.DataAnnotations;

namespace Joomiz.Blog.WebApplication.ViewModels.Base
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
    }
}