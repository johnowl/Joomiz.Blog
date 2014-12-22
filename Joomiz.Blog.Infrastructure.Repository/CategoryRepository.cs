using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.Infrastructure.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Joomiz.Blog.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category GetById(int id)
        {
            Category author = null;

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Get_Category_By_Id";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    author = FillCategory(reader);
                }
            }

            return author;
        }

        public IEnumerable<Category> GetAll()
        {
            var list = new List<Category>();

            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "List_Category";
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(FillCategory(reader));
                }
            }

            return list;
        }

        public void Add(Category obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Add_Category";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.Parameters.AddWithValue("@Name", obj.Name);                
                command.Parameters.AddWithValue("@DateCreated", obj.DateCreated);

                command.ExecuteNonQuery();

                obj.Id = Convert.ToInt32(command.Parameters["Id"].Value);
            }
        }

        public void Update(Category obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Update_Category";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", obj.Id);
                command.Parameters.AddWithValue("@Name", obj.Name);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Delete_Category";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        private Category FillCategory(SqlDataReader reader)
        {
            var author = new Category();
            author.Id = reader.GetInt32(0);
            author.Name = reader.GetString(1);           
            author.DateCreated = reader.GetDateTime(2);

            return author;
        }

        public PagedList<Category> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            throw new System.NotImplementedException();
        }
    }
}
