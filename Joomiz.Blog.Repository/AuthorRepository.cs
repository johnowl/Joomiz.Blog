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

        public PagedList<Author> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            var list = new PagedList<Author>();            

            using (var connection = SqlHelper.GetConnection())
            {
                string sql = @"SELECT Id, Name, Email, IsActive, DateCreated FROM Author ORDER BY Name";
                list = connection.Query<Author>(sql) as PagedList<Author>;
            }

            return list;
        }

        public void Add(Author obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Author obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
