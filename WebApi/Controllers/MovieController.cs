using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MovieOperations.Command;
using WebApi.Application.MovieOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.MovieOperations.Command.CreateMovieCommand;
using static WebApi.Application.MovieOperations.Command.UpdateMovieCommand;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : Controller
    {
        private readonly IMovieStoreDbContext _context;

        private readonly IMapper _mapper;

        public MovieController(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMoviesQuery query = new GetMoviesQuery(_mapper,_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieModel newMovie)
        {
            CreateMovieCommand command = new CreateMovieCommand(_mapper,_context);
            CreateMovieValidator valid = new
            CreateMovieValidator();
            command.Model = newMovie;
            valid.ValidateAndThrow(command);
            command.Handle();
            return Ok(newMovie);
        }

        [HttpPut("id")]
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieModel updateMovie)
        {
            UpdateMovieCommand command = new UpdateMovieCommand(_context);
            command.Model = updateMovie;
            command.MovieId = id;

            UpdateMovieValidator valid = new UpdateMovieValidator();
            
            valid.ValidateAndThrow(command);
            command.Handle();
            return Ok();

        }

        [HttpDelete("id")]

        public IActionResult DeleteMovie(int id)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);

            command.MovieId = id;

            command.Handle();
            return Ok();
        }
    }
}