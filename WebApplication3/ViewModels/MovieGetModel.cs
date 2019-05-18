using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
    public class MovieGetModel
    {

        public string Title { get; set; }
        public int Duration { get; set; }
        public int Rating { get; set; }
        public int NumberOfComments { get; set; }

        public static MovieGetModel FromMovie(Movie movie)
        {
            return new MovieGetModel
            {
                Title = movie.Title,
                Duration = movie.Duration,
                Rating = movie.Rating,
                NumberOfComments = movie.Comments.Count
            };
        }
    }
}
