using System;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Entities
{
    public class Post : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Author Author { get; set; }
        public ICollection<Category> Categories { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
