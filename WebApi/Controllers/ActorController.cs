using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ActorOperations.Command;
using WebApi.Application.ActorOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.ActorOperations.Command.UpdateActorCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : Controller
    {
        private readonly IMovieStoreDbContext _context;

        private readonly IMapper _mapper;

        public ActorController(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetActors()
        {
            GetActorsQuery query = new GetActorsQuery(_mapper,_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddActor([FromBody]CreateActorModel newAuthor)
        {
            CreateActorCommand command = new CreateActorCommand(_mapper,_context);

            command.model = newAuthor;
            command.Handle();

            return Ok(newAuthor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] UpdateActorModel actorModel)
        {
            UpdateActorCommand command = new UpdateActorCommand(_context);

            command.model = actorModel;
            command.actorId = id;

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.actorId = id;

            command.Handle();
            
            return Ok();
        }

    }
}