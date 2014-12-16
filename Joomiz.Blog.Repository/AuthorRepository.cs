using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Joomiz.Blog.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public Author GetById(int id)
        {
            Author author = null;

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Get_Author_By_Id";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    author = FillAuthor(reader);
                }
            }

            return author;
        }        

        public IEnumerable<Author> GetAll()
        {
            var list = new List<Author>();

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "List_Author";
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(FillAuthor(reader));
                }
            }

            return list;
        }

        public void Add(Author obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Add_Author";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@Password", obj.Password);
                command.Parameters.AddWithValue("@IsActive", obj.IsActive);
                command.Parameters.AddWithValue("@DateCreated", obj.DateCreated);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Author obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Update_Author";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", obj.Id);

                command.Parameters.AddWithValue("@Name", obj.Name);
                command.Parameters.AddWithValue("@Email", obj.Email);
                command.Parameters.AddWithValue("@Password", obj.Password);
                command.Parameters.AddWithValue("@IsActive", obj.IsActive);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Delete_Author";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
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
