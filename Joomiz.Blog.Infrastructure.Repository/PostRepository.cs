using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.Infrastructure.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace Joomiz.Blog.Infrastructure.Repository
{
    public class PostRepository : IPostRepository
    {
        public Post GetById(int id)
        {
            var procedure = new ProcedureSql("Get_Post_By_Id");

            procedure.AddParameter("@Id", id);

            return procedure.Get<Post>(this.FillPost);            
        }

        private Post FillPost(SqlDataReader reader)
        {
            var post = new Post();

            post.Id = reader.GetInt32(0);
            post.Author = new Author();
            post.Author.Id = reader.GetInt32(1);
            post.Title = reader.GetValueOrDefault<string>(2);
            post.Body = reader.GetValueOrDefault<string>(3);
            post.IsPublished = reader.GetBoolean(4);
            post.DateCreated = reader.GetDateTime(5);

            return post;
        }

        public PagedList<Post> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            var procedure = new ProcedureSql("List_Post");            

            return procedure.GetPagedList<Post>(this.FillPost, pageNumber, pageSize);              
        }

        public void Add(Post obj)
        {
            var procedure = new ProcedureSql("Add_Post");
            procedure.AddParameter("@Id", SqlDbType.Int, ParameterDirection.Output);
            procedure.AddParameter("@AuthorId", obj.Author.Id);
            procedure.AddParameter("@Title", obj.Title);
            procedure.AddParameter("@Body", obj.Body);
            procedure.AddParameter("@IsPublished", obj.IsPublished);
            procedure.AddParameter("@DateCreated", obj.DateCreated);

            // Sql Server 2008 compatible
            // http://www.mssqltips.com/sqlservertip/2112/table-value-parameters-in-sql-server-2008-and-net-c/
            var categories = new DataTable();
            categories.Columns.Add("Id", typeof(Int32));
            if (obj.Categories != null)
            {
                foreach (Category category in obj.Categories)
                {
                    categories.Rows.Add(category.Id);
                }
            }
            procedure.AddParameter("@Categories", categories, SqlDbType.Structured);

            obj.Id = procedure.Insert();            
        }

        public void Update(Post obj)
        {
            var procedure = new ProcedureSql("Update_Post");

            procedure.AddParameter("@Id", obj.Id);
            procedure.AddParameter("@AuthorId", obj.Author.Id);
            procedure.AddParameter("@Title", obj.Title);
            procedure.AddParameter("@Body", obj.Body);
            procedure.AddParameter("@IsPublished", obj.IsPublished);

            // Sql Server 2008 compatible
            // http://www.mssqltips.com/sqlservertip/2112/table-value-parameters-in-sql-server-2008-and-net-c/
            var categories = new DataTable();
            categories.Columns.Add("Id", typeof(Int32));
            if (obj.Categories != null)
            {
                foreach (Category category in obj.Categories)
                {
                    categories.Rows.Add(category.Id);
                }
            }
            procedure.AddParameter("@Categories", categories, SqlDbType.Structured);

            procedure.Execute();            
        }

        public void Delete(int id)
        {
            var procedure = new ProcedureSql("Update_Post");
            procedure.AddParameter("@Id", id);
            procedure.Execute();            
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
