using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Contracts.Validation;
using Joomiz.Blog.Domain.Model;
using System;
using System.Collections.Generic;

namespace Joomiz.Blog.Domain.Validation
{
    public class AuthorValidation : IAuthorValidation
    {
        private readonly IAuthorRepository authorRepository;

        protected Dictionary<string, string> ErrorList { get; private set; }

        public AuthorValidation(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public bool Validate(Author obj)
        {
            this.ErrorList = new Dictionary<string, string>();

            // Name
            if (string.IsNullOrWhiteSpace(obj.Name))
                this.ErrorList.Add("Name", "Name is required.");
            else if (obj.Name != null && obj.Name.Length > 70)
                this.ErrorList.Add("Name", "Name must be lower than 70 characters.");
            else if (this.ErrorList.Count == 0) // if there are no errors name
            {
                Author existingAuthor = this.authorRepository.GetByName(obj.Name);

                if (existingAuthor != null && obj.Id != existingAuthor.Id)
                {
                    this.ErrorList.Add("Name", "This Name is already in use.");
                }
            }

            // Email
            if (string.IsNullOrWhiteSpace(obj.Email))
                this.ErrorList.Add("Email", "E-mail is required.");
            else  if (obj.Email.Length > 70)
                this.ErrorList.Add("Email", "E-mail must be lower than 70 characters.");

            // Password
            if (string.IsNullOrWhiteSpace(obj.Password))
                this.ErrorList.Add("Password", "Password is required.");
            else if (obj.Password.Length < 6)
                this.ErrorList.Add("Password", "Password must be greater than ou equal to 6 characters.");

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
