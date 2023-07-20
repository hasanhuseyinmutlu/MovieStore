using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorMoviesOperations.Command;
using WebApi.Application.ActorMoviesOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.ActorMoviesOperations.Command.CreateActorMovieCommand;
using static WebApi.Application.ActorMoviesOperations.Command.UpdateActorMovieCommand;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class ActorMovieController : Controller
    {
        private readonly IMovieStoreDbContext _context;

        private readonly IMapper _mapper;

        public ActorMovieController(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetActorMovie()
        {
            GetActorMovieQuery query = new GetActorMovieQuery(_mapper, _context);
            var result = query.Handle();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateActorMovie([FromBody] CreateActorMovieModel newActorMovie)
        {
            CreateActorMovieCommand command = new CreateActorMovieCommand(_mapper,_context);

            command.model = newActorMovie;
            command.Handle();

            return Ok(newActorMovie);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateActorMovie(int id,[FromBody] UpdateActorMovieModel updateActorMovie)
        {
            UpdateActorMovieCommand command = new UpdateActorMovieCommand(_context);
            command.model = updateActorMovie;
            command.Id = id;
            
            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActorMovie(int id)
        {
            DeleteActorMovieCommand command = new DeleteActorMovieCommand(_context);
            
            command.Id = id ;

            command.Handle();

            return Ok();
        }
    }
}