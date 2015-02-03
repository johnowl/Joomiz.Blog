using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Model;
using Joomiz.Blog.Infrastructure.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Joomiz.Blog.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public Author GetById(int id)
        {
            var procedure = new ProcedureSql("Get_Author_By_Id");

            procedure.AddParameter("@Id", id);

            return procedure.Get<Author>(this.FillAuthor);            
        }

        public Author GetByName(string name)
        {
            var procedure = new ProcedureSql("Get_Author_By_Name");

            procedure.AddParameter("@Name", name);

            return procedure.Get<Author>(this.FillAuthor);            
        }

        public IEnumerable<Author> GetAll()
        {
            var procedure = new ProcedureSql("List_Author");

            return procedure.GetList<Author>(this.FillAuthor);            
        }

        public void Add(Author obj)
        {
            var procedure = new ProcedureSql("Add_Author");

            procedure.AddParameter("@Id", SqlDbType.Int, ParameterDirection.Output);
            procedure.AddParameter("@Name", obj.Name);
            procedure.AddParameter("@Email", obj.Email);
            procedure.AddParameter("@Password", obj.Password);
            procedure.AddParameter("@IsActive", obj.IsActive);
            procedure.AddParameter("@DateCreated", obj.DateCreated);

            obj.Id = procedure.Insert();            
        }

        public void Update(Author obj)
        {
            var procedure = new ProcedureSql("Update_Author");

            procedure.AddParameter("@Id", obj.Id);
            procedure.AddParameter("@Name", obj.Name);
            procedure.AddParameter("@Email", obj.Email);
            procedure.AddParameter("@Password", obj.Password);
            procedure.AddParameter("@IsActive", obj.IsActive);

            procedure.Execute();          
        }

        public void Delete(int id)
        {
            var procedure = new ProcedureSql("Delete_Author");
            procedure.AddParameter("@Id", id);
            procedure.Execute();            
        }

        private Author FillAuthor(SqlDataReader reader)
        {
            var author = new Author();
            author.Id = reader.GetInt32(0);
            author.Name = reader.GetString(1);
            author.Email = reader.GetString(2);
            author.Password = reader.GetString(3);
            author.IsActive = reader.GetBoolean(4);
            author.DateCreated = reader.GetDateTime(5);

            return author;
        }

        public PagedList<Author> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            throw new NotImplementedException();
        }
    }
}
