using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Joomiz.Blog.Repository
{
    public class CommentRepository : ICommentRepository
    {        

        public Comment GetById(int id)
        {
            Comment author = null;

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Get_Comment_By_Id";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    author = FillComment(reader);
                }
            }

            return author;
        }

        public PagedList<Comment> GetByPostId(int postId, int pageNumber = 1, int pageSize = 50)
        {
            var list = new PagedList<Comment>();            

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "List_Comment_By_PostId";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PostId", postId);
                command.Parameters.AddWithValue("@PageNumber", pageNumber);
                command.Parameters.AddWithValue("@PagSize", pageSize);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(FillComment(reader));
                }

                // get total records for paging
                if (reader.NextResult())
                {
                    if (reader.Read())
                    {
                        list.ItemsTotal = reader.GetInt32(0);
                        list.PageNumber = pageNumber;
                        list.PageSize = pageSize;
                    }
                }
            }

            return list;
        }        

        public void Add(Comment obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Add_Comment";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.Parameters.AddWithValue("@PostId", obj.PostId);
                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@Url", obj.Url);
                command.Parameters.AddWithValue("@Body", obj.Body);
                command.Parameters.AddWithValue("@Status", obj.Status);
                command.Parameters.AddWithValue("@DateCreated", obj.DateCreated);

                command.ExecuteNonQuery();

                obj.Id = Convert.ToInt32(command.Parameters["Id"].Value);
            }
        }

        public void Update(Comment obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Update_Comment";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", obj.Id);
                command.Parameters.AddWithValue("@PostId", obj.PostId);
                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@Url", obj.Url);
                command.Parameters.AddWithValue("@Body", obj.Body);
                command.Parameters.AddWithValue("@Status", obj.Status);
                command.Parameters.AddWithValue("@DateCreated", obj.DateCreated);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Delete_Comment";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
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
