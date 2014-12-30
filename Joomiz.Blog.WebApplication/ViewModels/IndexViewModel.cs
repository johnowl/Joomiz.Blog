using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.WebApplication.ViewModels.Maps;
using System.Collections.Generic;

namespace Joomiz.Blog.WebApplication.ViewModels
{
    public class IndexViewModel : PagedViewModel<PostViewModel>
    {
        public IndexViewModel()
        {

        }

        public IndexViewModel(PagedList<Post> posts)
        {
            var pagedViewModel = MapToViewModel.From(posts);

            this.Items = pagedViewModel.Items;
            this.TotalPages = pagedViewModel.TotalPages;
            this.CurrentPage = pagedViewModel.CurrentPage;
        }
    }
}