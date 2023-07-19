using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.FavoriteGenreOperations.Command;
using WebApi.Application.FavoriteGenreOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.FavoriteGenreOperations.Command.CreateFavoriteGenresCommand;
using static WebApi.Application.FavoriteGenreOperations.Command.UpdateFavoriteGenresCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class FavoriteGenreController : Controller
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public FavoriteGenreController(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult getFavoriteGenre()
        {
            GetFavoriteGenresQuery query = new GetFavoriteGenresQuery(_mapper,_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult createFavoriteGenre([FromBody] FavoriteGenreModel createModel)
        {
            CreateFavoriteGenresCommand command = new CreateFavoriteGenresCommand(_mapper,_context);

            command.model = createModel;
            command.Handle();
            
            return Ok(createModel);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateFavoriteGenre([FromBody] UpdateFavoriteGenresModel UpdateFavoriteGenresModel ,int id)
        {
            UpdateFavoriteGenresCommand command = new UpdateFavoriteGenresCommand(_mapper,_context);
            command.Model = UpdateFavoriteGenresModel;
            command.Id = id;

            command.Handle();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFavoriteGenre(int id)
        {
            DeleteFavoriteGenresCommand command = new DeleteFavoriteGenresCommand(_context);
            command.Id = id;
            command.Handle();
            
            return Ok();
        }
    }
}