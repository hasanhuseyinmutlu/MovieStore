using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.FavoriteGenreOperations.Command;
using WebApi.Application.FavoriteGenreOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.FavoriteGenreOperations.Command.CreateFavoriteGenresCommand;

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
    }
}