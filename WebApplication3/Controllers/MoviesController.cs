using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using WebApplication3.Services;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private IMovieService movieService;
        public MoviesController(IMovieService movieService)
        {
            this.movieService = movieService;
        }
        /// <summary>
        /// Get all the movies
        /// </summary>
        /// <param name="from">date</param>
        /// <param name="to">date</param>
        /// <returns>list of movies</returns>
        [HttpGet]
        // ? permite unui struct sa ia si valoare null
        public IEnumerable<MovieGetModel> Get([FromQuery]DateTime? from, [FromQuery]DateTime? to)
        {
            return movieService.GetAll();
        }


        // GET: api/Movies/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var found = movieService.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }

        /// <summary>
        /// 
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /movies
        ///  {
        ///   "title": "Test",
        ///   "description": "Description of the movie",
        ///  "duration": 120,
        ///  "genre": 0,
        ///  "releaseYear": 2018,
        ///  "dateAdded": "2019-05-10T09:10:00",
        ///  "director": "Corina",
        ///  "rating": 8,
        ///  "watched": true,
        ///  "comments": [
        /// 	{"text":"comment",
        /// 	"important":true,
        ///    }
        ///	  ]
        ///  }
        ///</remarks>
        /// </summary>
        /// <param name="movie"></param>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] MoviePostModel movie)
        {
            movieService.Create(movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movie movie)
        {
            var result = movieService.Upsert(id, movie);
            return Ok(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = movieService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
