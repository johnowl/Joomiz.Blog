using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.WebApplication.ViewModels.Base;
using Joomiz.Blog.WebApplication.ViewModels.Maps;
using System.Collections.Generic;

namespace Joomiz.Blog.WebApplication.ViewModels
{
    public class PostListViewModel : PagedViewModel<PostViewModel>
    {        
        public PostListViewModel()
        {

        }

        public PostListViewModel(PagedList<Post> posts)
        {
            var pagedViewModel = MapToViewModel.From(posts);

            this.Items = pagedViewModel.Items;
            this.TotalPages = pagedViewModel.TotalPages;
            this.CurrentPage = pagedViewModel.CurrentPage;
        }
    }
}