using System.Collections.Generic;

namespace Joomiz.Blog.WebApplication.ViewModels.Base
{
    public class PagedViewModel<T> where T : class
    {
        public List<T> Items { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage
        {
            get
            {
                return CurrentPage < TotalPages;
            }
        }
        public bool HasPreviousPage
        {
            get
            {
                return CurrentPage > 1;
            }
        }
        public bool IsEmpty
        {
            get
            {
                if (this.Items == null)
                    return true;

                return this.Items.Count == 0;
            }
        }
    }
}