using Joomiz.Blog.Application.Contracts;
using Joomiz.Blog.Application.Factories;
using Joomiz.Blog.Domain.Contracts.Services;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.Domain.Services;

namespace Joomiz.Blog.Application.Services
{
    public class AuthorAppService : IAuthorAppService
    {
        private readonly IAuthorService authorService;

        public AuthorAppService(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        public AuthorAppService()
        {
            this.authorService = ServiceFactory.GetAuthorService();
        }

        public Author GetById(int id)
        {
            return authorService.GetById(id);
        }

        public PagedList<Author> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            return authorService.GetAll(pageNumber, pageSize);
        }

        public void Add(Author obj)
        {
            authorService.Add(obj);
        }

        public void Update(Author obj)
        {
            authorService.Update(obj);
        }

        public void Delete(int id)
        {
            authorService.Delete(id);
        }
    }
}
