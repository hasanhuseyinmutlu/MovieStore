using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.DirectorOperations.Command;
using WebApi.Application.DirectorOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.DirectorOperations.Command.CreateDirectorCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : Controller
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectorsQuery query = new GetDirectorsQuery(_mapper,_context);
            var result = query.Handle();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddDirector([FromBody] CreateDirectorModel newDirector)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(_mapper,_context);

            command.model = newDirector;
            command.Handle();
            
            return Ok(newDirector);   
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id,[FromBody]
        UpdateDirectorModel directorModel)
        {
            UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
            command.model = directorModel;
            command.directorId = id;
            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.directorId = id;
            command.Handle();
            return Ok();
        } 

    }
}