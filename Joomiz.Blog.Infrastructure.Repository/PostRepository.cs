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
            Post item = null;

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Get_Post_By_Id";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    item = FillPost(reader);
                }
            }

            return item;
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
            var list = new PagedList<Post>();

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "List_Post";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@PageNumber", pageNumber);
                command.Parameters.AddWithValue("@PageSize", pageSize);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(FillPost(reader));
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

        public void Add(Post obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Add_Post";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.Parameters.AddWithValue("@AuthorId", obj.Author.Id);
                command.Parameters.AddWithValue("@Title", obj.Title);
                command.Parameters.AddWithValue("@Body", obj.Body);
                command.Parameters.AddWithValue("@IsPublished", obj.IsPublished);
                command.Parameters.AddWithValue("@DateCreated", obj.DateCreated);

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
                command.Parameters.AddWithValue("@Categories", categories).SqlDbType = SqlDbType.Structured;

                command.ExecuteNonQuery();

                obj.Id = Convert.ToInt32(command.Parameters["Id"].Value);
            }
        }

        public void Update(Post obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Update_Post";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", obj.Id);
                command.Parameters.AddWithValue("@AuthorId", obj.Author.Id);
                command.Parameters.AddWithValue("@Title", obj.Title);
                command.Parameters.AddWithValue("@Body", obj.Body);
                command.Parameters.AddWithValue("@IsPublished", obj.IsPublished);
                command.Parameters.AddWithValue("@DateCreated", obj.DateCreated);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Delete_Post";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
