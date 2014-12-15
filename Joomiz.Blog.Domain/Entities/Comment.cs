using System;

namespace Joomiz.Blog.Domain.Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public CommentStatus Status { get; set; }
        public bool IsApproved
        {
            get
            {
                return this.Status == CommentStatus.Approved;
            }
        }
        public bool IsRejected
        {
            get
            {
                return this.Status == CommentStatus.Rejected;
            }
        }
        public bool IsPending
        {
            get
            {
                return this.Status == CommentStatus.Pending;
            }
        }
    }    
}
