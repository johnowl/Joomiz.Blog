using Dapper;
using Joomiz.Blog.Domain.Contracts.Repositories;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.Repository.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Joomiz.Blog.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        public Author GetById(int id)
        {
            Author author = null;

            using (var connection = SqlHelper.GetConnection())
            {
                string sql = @"SELECT Id, Name, Email, IsActive, DateCreated FROM Author WHERE Id = @Id";
                author = connection.Query<Author>(sql, new { Id = id }).First();                
            }

            return author;
        }

        public IEnumerable<Author> GetAll()
        {            
            using (var connection = SqlHelper.GetConnection())
            {
                string sql = @"SELECT Id, Name, Email, IsActive, DateCreated FROM Author ORDER BY Name";
                return connection.Query<Author>(sql).ToList();
            }
        }

        public void Add(Author obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                string sql = @"INSERT INTO Author(Name, Email, Password, IsActive, DateCreated) VALUES(@Name, @Email, @Password, @IsActive, @DateCreated)";
                connection.Execute(sql, obj);
            }
        }

        public void Update(Author obj)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                string sql = @"UPDATE Author SET Name = @Name, Email = @Email, Password = @Password, IsActive = @IsActive WHERE Id = @Id";
                connection.Execute(sql, obj);
            }
        }

        public void Delete(int id)
        {
            using (var connection = SqlHelper.GetConnection())
            {
                string sql = @"DELETE FROM Author WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        public PagedList<Author> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            throw new NotImplementedException();
        }
    }
}
