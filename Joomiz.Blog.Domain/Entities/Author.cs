using System;

namespace Joomiz.Blog.Domain.Entities
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
