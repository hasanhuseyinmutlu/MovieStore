using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.PurchasedMovieOperations.Command;
using WebApi.Application.PurchasedMovieOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.PurchasedMovieOperations.Command.CreatePurchaseMovieCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class PurchaseMovieController : Controller
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public PurchaseMovieController(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult getPurchaseMovie()
        {
            GetPurchasedMovieQuery query = new GetPurchasedMovieQuery(_mapper,_context);

            var result = query.Handle();

            return Ok(result);
        }
        [HttpPost]
        public IActionResult createPurchaseMovie([FromBody] PurchasedMovieModel createModel)
        {
                CreatePurchaseMovieCommand command = new CreatePurchaseMovieCommand(_mapper,_context);

                command.model = createModel;
                command.Handle();
                return Ok(createModel);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePurchaseMovie(int id,PurchasedMovieModel updateModel )
        {
            UpdatePurchaseMovieCommand command = new UpdatePurchaseMovieCommand(_context);
            command.model = updateModel;
            command.Id = id;

            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePurchaseMovie(int id)
        {
            DeletePurchaseCommand command = new DeletePurchaseCommand(_context);

            command.Id = id;
            command.Handle();
            return Ok();
        }
    }
}