using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DirectorMoviesOperations.Command;
using WebApi.Application.DirectorMoviesOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.DirectorMoviesOperations.Command.UpdateDirectorMovieCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorMovieController : Controller
    {
        private readonly IMovieStoreDbContext _context;

        private readonly IMapper _mapper;

        public DirectorMovieController(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDirectorMovie()
        {
            GetDirectorMovieQuery query = new GetDirectorMovieQuery(_mapper,_context);

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost]

        public IActionResult CreateDirectorMovie([FromBody] CreateDirectorMovieModel newDirectorMovie)
        {
            CreateDirectorMovieCommands commamnd = new CreateDirectorMovieCommands(_mapper,_context);

            commamnd.model = newDirectorMovie;
            commamnd.Handle();

            return Ok(newDirectorMovie);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirectorMovie(int id, [FromBody] UpdateDirectorMovieModel updateDirectorMovie)
        {
            UpdateDirectorMovieCommand command = new UpdateDirectorMovieCommand(_context);

            command.directorMovieId = id;
            command.model = updateDirectorMovie;

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDirectorMovie(int id)
        {
            DeleteDirectorMovieCommand command = new DeleteDirectorMovieCommand(_context);

            command.Id = id;

            command.Handle();
            
            return Ok();
        }

    }
}