using Joomiz.Blog.Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Joomiz.Blog.Domain.Entities
{
    public class Post : IEntity
    {
        public Post()
        {
            this.Author = new Author();
            this.Categories = new Collection<Category>();
            this.Comments = new PagedList<Comment>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public Author Author { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public DateTime DateCreated { get; set; }
        public PagedList<Comment> Comments { get; set; }
        public bool IsPublished { get; set; }
    }
}
