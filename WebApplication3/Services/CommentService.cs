using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Services
{
    public interface ICommentService
    {
        IEnumerable<CommentGetModel> GetAll(string filter);
    }
    public class CommentService : ICommentService
    {
        private MoviesDbContext context;
        public CommentService(MoviesDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<CommentGetModel> GetAll(string filter)
        {
            if (filter == null)
            {
                IQueryable<CommentGetModel> allComments = context.Comments.Select(c => new CommentGetModel
                {
                    Text = c.Text,
                    Important = c.Important,
                    MovieId = c.Id
                });
                return allComments;
            }
            IQueryable<CommentGetModel> comments = context.Comments.Where(c => c.Text.Contains(filter))
                .Select(c => new CommentGetModel {
                    Text=c.Text,
                    Important=c.Important,
                    MovieId=c.Id
                });
            return comments;
        }
    }
}
