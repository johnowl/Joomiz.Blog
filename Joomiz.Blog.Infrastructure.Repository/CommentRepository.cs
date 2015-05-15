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
    public class CommentRepository : ICommentRepository
    {
        public Comment GetById(int id)
        {
            var procedure = new ProcedureSql("Get_Comment_By_Id");

            procedure.AddParameter("@Id", id);

            return procedure.Get<Comment>(FillComment);            
        }

        public PagedList<Comment> GetByPostId(int postId, int pageNumber = 1, int pageSize = 50)
        {
            var procedure = new ProcedureSql("List_Comment_By_PostId");

            procedure.AddParameter("@PostId", postId);

            return procedure.GetPagedList<Comment>(this.FillComment, pageNumber, pageSize);  
        }

        public void Add(Comment obj)
        {
            var procedure = new ProcedureSql("Add_Comment");

            procedure.AddParameter("@Id", SqlDbType.Int, ParameterDirection.Output);
            procedure.AddParameter("@PostId", obj.PostId);
            procedure.AddParameter("@Name", obj.Name);
            procedure.AddParameter("@Email", obj.Email);
            procedure.AddParameter("@Url", obj.Url);
            procedure.AddParameter("@Body", obj.Body);
            procedure.AddParameter("@Status", obj.Status);
            procedure.AddParameter("@DateCreated", obj.DateCreated);

            obj.Id = procedure.Insert();
        }

        public void Update(Comment obj)
        {
            var procedure = new ProcedureSql("Update_Comment");

            procedure.AddParameter("@Id", obj.Id);
            procedure.AddParameter("@PostId", obj.PostId);
            procedure.AddParameter("@Name", obj.Name);
            procedure.AddParameter("@Email", obj.Email);
            procedure.AddParameter("@Url", obj.Url);
            procedure.AddParameter("@Body", obj.Body);
            procedure.AddParameter("@Status", obj.Status);
            procedure.AddParameter("@DateCreated", obj.DateCreated);

            procedure.Execute();
        }

        public void Delete(int id)
        {
            var procedure = new ProcedureSql("Delete_Comment");

            procedure.AddParameter("@Id", id);

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
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public int CountPendingComments()
        {
            throw new NotImplementedException();
        }
    }
}
