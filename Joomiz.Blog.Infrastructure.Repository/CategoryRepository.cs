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
    public class CategoryRepository : ICategoryRepository
    {
        public Category GetById(int id)
        {
            var procedure = new ProcedureSql("Get_Category_By_Id");

            procedure.AddParameter("@Id", id);

            return procedure.Get<Category>(this.FillCategory);           
        }

        public IEnumerable<Category> GetAll()
        {
            var procedure = new ProcedureSql("List_Category");
            return procedure.GetList<Category>(FillCategory);            
        }

        public void Add(Category obj)
        {
            var procedure = new ProcedureSql("Add_Category");

            procedure.AddParameter("@Id", SqlDbType.Int, ParameterDirection.Output);
            procedure.AddParameter("@Name", obj.Name);
            procedure.AddParameter("@DateCreated", obj.DateCreated);

            obj.Id = procedure.Insert();            
        }

        public void Update(Category obj)
        {
            var procedure = new ProcedureSql("Update_Category");

            procedure.AddParameter("@Id", obj.Id);
            procedure.AddParameter("@Name", obj.Name);

            procedure.Execute();
        }

        public void Delete(int id)
        {
            var procedure = new ProcedureSql("Delete_Category");
            procedure.AddParameter("@Id", id);
            procedure.Execute();            
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

        public IEnumerable<Category> GetByPostId(int postId)
        {
            var procedure = new ProcedureSql("List_Category_By_PostId");
            procedure.AddParameter("@PostId", postId);
            return procedure.GetList<Category>(FillCategory);            
        }


        public Category GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
