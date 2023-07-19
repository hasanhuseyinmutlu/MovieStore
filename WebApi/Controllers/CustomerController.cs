using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations;
using WebApi.Application.CustomerOperations.Command;
using WebApi.Application.CustomerOperations.Queries;
using WebApi.Application.TokenOperations;
using WebApi.DbOperation;
using WebApi.TokenOperations;
using static WebApi.Application.CustomerOperations.CreateCustomerCommand;
using static WebApi.Application.TokenOperations.CreateTokenCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : Controller
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        private readonly IConfiguration _configuration;

        public CustomerController(IMapper mapper, IMovieStoreDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult getCustomer()
        {
            GetCustomerQuey query = new GetCustomerQuey(_mapper,_context);
            var result = query.Handle();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult addCustomer([FromBody] CustomerModel createModel) 
        {
            CreateCustomerCommand command = new CreateCustomerCommand(_mapper,_context);
            command.Model = createModel;

            command.Handle();

            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer([FromBody]CustomerModel updateModel, int id)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context);
            command.Model = updateModel;
            command.Id = id;

            command.Handle();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            UpdateCutomerCommand command = new UpdateCutomerCommand(_context);
            command.Id = id;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login )
        {
            CreateTokenCommand command = new CreateTokenCommand(_configuration,_context);

            command.model = login;

            var token = command.Handle();

            return token;
        }
        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromBody] string token)
        {
            RefreshTokenCommand command = new RefreshTokenCommand(_configuration,_context);
            command.RefreshToken = token;
            var resultToken = command.Handle();
            return resultToken;
        }
    }
    
}