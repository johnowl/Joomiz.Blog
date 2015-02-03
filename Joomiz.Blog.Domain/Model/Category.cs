using System;

namespace Joomiz.Blog.Domain.Model
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
