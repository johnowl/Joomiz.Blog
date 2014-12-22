using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.Infrastructure.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Joomiz.Blog.Infrastructure.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public Comment GetById(int id)
        {
            var procedure = new ProcedureSql("Get_Comment_By_Id");

            procedure.Parameters.AddWithValue("@Id", id);

            return procedure.Get<Comment>(FillComment);            
        }

        public PagedList<Comment> GetByPostId(int postId, int pageNumber = 1, int pageSize = 50)
        {
            var procedure = new ProcedureSql("List_Comment_By_PostId");

            procedure.Parameters.AddWithValue("@PostId", postId);

            return procedure.GetPagedList<Comment>(this.FillComment, pageNumber, pageSize);            
        }

        public void Add(Comment obj)
        {
            var procedure = new ProcedureSql("Add_Comment");

            procedure.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

            procedure.Parameters.AddWithValue("@PostId", obj.PostId);
            procedure.Parameters.AddWithValue("@Name", obj.Name);
            procedure.Parameters.AddWithValue("@Email", obj.Email);
            procedure.Parameters.AddWithValue("@Url", obj.Url);
            procedure.Parameters.AddWithValue("@Body", obj.Body);
            procedure.Parameters.AddWithValue("@Status", obj.Status);
            procedure.Parameters.AddWithValue("@DateCreated", obj.DateCreated);

            obj.Id = procedure.Insert();
        }

        public void Update(Comment obj)
        {
            var procedure = new ProcedureSql("Update_Comment");

            procedure.Parameters.AddWithValue("@Id", obj.Id);
            procedure.Parameters.AddWithValue("@PostId", obj.PostId);
            procedure.Parameters.AddWithValue("@Name", obj.Name);
            procedure.Parameters.AddWithValue("@Email", obj.Email);
            procedure.Parameters.AddWithValue("@Url", obj.Url);
            procedure.Parameters.AddWithValue("@Body", obj.Body);
            procedure.Parameters.AddWithValue("@Status", obj.Status);
            procedure.Parameters.AddWithValue("@DateCreated", obj.DateCreated);

            procedure.Execute();
        }

        public void Delete(int id)
        {
            var procedure = new ProcedureSql("Delete_Comment");

            procedure.Parameters.AddWithValue("@Id", id);

            procedure.Execute();           
        }

        private Comment FillComment(SqlDataReader reader)
        {
            var comment = new Comment();
            comment.Id = reader.GetInt32(0);
            comment.PostId = reader.GetInt32(1);
            comment.Name = reader.GetString(2);
            comment.Email = reader.GetValueOrDefault<string>(3);
            comment.Url = reader.GetValueOrDefault<string>(4);
            comment.Body = reader.GetString(5);
            comment.Status = (CommentStatus)reader.GetInt32(6);
            comment.DateCreated = reader.GetDateTime(7);

            return comment;
        }

        public PagedList<Comment> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new System.NotImplementedException();
        }       
    }
}
