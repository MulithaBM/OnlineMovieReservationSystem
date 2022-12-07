using Microsoft.AspNetCore.Mvc;
using OnlineMovieReservationSystem.Data;
using OnlineMovieReservationSystem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineMovieReservationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieDB movieDB = new();

        // GET: api/<MovieController>
        [HttpGet]
        public ServiceResponse<List<Movie>> Get()
        {
            var response = new ServiceResponse<List<Movie>>();

            response.Data = movieDB.GetAllMovies();

            return response;
        }

        // GET api/<MovieController>/1
        [HttpGet("{id}")]
        public ServiceResponse<Movie> Get(int id)
        {
            var response = new ServiceResponse<Movie>();
            try
            {
                Movie movie = movieDB.GetSingleMovie(id);

                if(movie == null)
                {
                    response.Data = null;
                    response.Success= false;
                    response.Message = "Movie not found";
                }
                else
                {
                    response.Data = movie;
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        // POST api/<MovieController>
        [HttpPost]
        public ServiceResponse<List<Movie>> Post(Movie movie)
        {
            Console.WriteLine("Add movie");
            Console.WriteLine(movie.Name);
            var response = new ServiceResponse<List<Movie>>();

            try
            {
                response.Data = movieDB.AddMovie(movie);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        // PUT api/<MovieController>/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        //[HttpDelete("{id}")]
        /*public List<Movie> Delete(int id)
        {
            
        }*/
    }
}
