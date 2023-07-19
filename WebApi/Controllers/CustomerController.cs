using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.CustomerOperations;
using WebApi.Application.CustomerOperations.Queries;
using WebApi.DbOperation;
using static WebApi.Application.CustomerOperations.CreateCustomerCommand;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class CustomerController : Controller
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper, IMovieStoreDbContext context)
        {
            _mapper = mapper;
            _context = context;
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
    }
    
}