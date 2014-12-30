using Joomiz.Blog.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Joomiz.Blog.WebApplication.ViewModels.Maps
{
    public static class MapToViewModel
    {
        public static CommentViewModel From(Comment comment)
        {
            throw new NotImplementedException();
        }

        public static AuthorViewModel From(Author author)
        {
            var authorViewModel = new AuthorViewModel();
            authorViewModel.Id = author.Id;
            authorViewModel.Name = author.Name;
            authorViewModel.Email = author.Email;

            return authorViewModel;
        }

        public static PostViewModel From(Post post)
        {
            var postViewModel = new PostViewModel();

            postViewModel.Id = post.Id;
            postViewModel.Title = post.Title;
            postViewModel.Body = post.Body;

            if (post.Author != null)
            {
                postViewModel.AuthorId = post.Author.Id;
                postViewModel.Author = MapToViewModel.From(post.Author);
            }

            return postViewModel;
        }

        public static PagedViewModel<PostViewModel> From(PagedList<Post> postList)
        {
            var viewModel = new PagedViewModel<PostViewModel>();
            viewModel.Items = new List<PostViewModel>();

            foreach (Post post in postList)
            {
                viewModel.Items.Add(MapToViewModel.From(post));
            }
            
            if (postList.PageNumber > 0 && postList.PageSize > 0)
            {
                viewModel.CurrentPage = postList.PageNumber;
                viewModel.TotalPages = (int)Math.Floor((decimal)(postList.ItemsTotal / postList.PageSize));
            }

            return viewModel;
        }
    }
}