using Joomiz.Blog.Domain.Common;
using Joomiz.Blog.Domain.Entities;
using Joomiz.Blog.WebApplication.ViewModels.Base;
using System;
using System.Collections.Generic;

namespace Joomiz.Blog.WebApplication.ViewModels.Maps
{
    public static class MapToViewModel
    {
        public static CommentViewModel From(Comment comment)
        {
            var viewModel = new CommentViewModel();
            viewModel.Id = comment.Id;
            viewModel.Name = comment.Name;
            viewModel.Url = comment.Url;
            viewModel.Email = comment.Email;
            viewModel.Body = comment.Body;
            viewModel.DateCreated = comment.DateCreated;
            viewModel.IsApproved = comment.IsApproved;

            return viewModel;
        }

        public static AuthorViewModel From(Author author)
        {
            var viewModel = new AuthorViewModel();
            viewModel.Id = author.Id;
            viewModel.Name = author.Name;
            viewModel.Email = author.Email;

            return viewModel;
        }

        public static PostViewModel From(Post post)
        {
            var viewModel = new PostViewModel();

            viewModel.Id = post.Id;
            viewModel.Title = post.Title;
            viewModel.Body = post.Body;

            if (post.Author != null)
            {
                viewModel.AuthorId = post.Author.Id;
                viewModel.Author = MapToViewModel.From(post.Author);
            }

            if (post.Comments != null)
            {
                viewModel.Comments = MapToViewModel.From(post.Comments);
            }

            return viewModel;
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

        public static PagedViewModel<CommentViewModel> From(PagedList<Comment> commentList)
        {
            var viewModel = new PagedViewModel<CommentViewModel>();
            viewModel.Items = new List<CommentViewModel>();

            foreach (Comment comment in commentList)
            {
                viewModel.Items.Add(MapToViewModel.From(comment));
            }

            if (commentList.PageNumber > 0 && commentList.PageSize > 0)
            {
                viewModel.CurrentPage = commentList.PageNumber;
                viewModel.TotalPages = (int)Math.Floor((decimal)(commentList.ItemsTotal / commentList.PageSize));
            }

            return viewModel;
        }
    }
}