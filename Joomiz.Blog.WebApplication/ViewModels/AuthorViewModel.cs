using System.ComponentModel.DataAnnotations;

namespace Joomiz.Blog.WebApplication.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

    }
}