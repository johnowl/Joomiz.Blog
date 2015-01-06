using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Validation
{
    public class CommentValidation : ICommentValidation
    {
        protected Dictionary<string, string> ErrorList { get; private set; }

        public bool Validate(Comment obj)
        {
            this.ErrorList = new Dictionary<string, string>();

            // Name
            if (string.IsNullOrWhiteSpace(obj.Name))
                this.ErrorList.Add("Name", "Name is required.");
            else if (obj.Name != null && obj.Name.Length > 70)
                this.ErrorList.Add("Name", "Name must be lower than 70 characters.");            

            // Email
            if (string.IsNullOrWhiteSpace(obj.Email))
                this.ErrorList.Add("Email", "E-mail is required.");
            else  if (obj.Email.Length > 70)
                this.ErrorList.Add("Email", "E-mail must be lower than 70 characters.");

            // Body
            if (string.IsNullOrWhiteSpace(obj.Body))
                this.ErrorList.Add("Body", "Comment is required.");

            // PostId
            if (obj.PostId <= 0)
                this.ErrorList.Add("PostId", "PostId is required.");

            // Date Created
            if(obj.DateCreated == DateTime.MinValue)
                this.ErrorList.Add("DateCreated", "DateCreated is required.");

            return this.ErrorList.Count == 0;
        }

        public Dictionary<string, string> GetErrors()
        {
            return this.ErrorList;
        }
    }
}
