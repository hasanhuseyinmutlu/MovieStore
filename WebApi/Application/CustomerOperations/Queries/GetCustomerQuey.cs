using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Queries
{
    public class GetCustomerQuey
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerQuey(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public List<CustomerQueryViewModel> Handle()
        {
            List<Customer> customers = _dbContext.Customers.OrderBy(x => x.Id).ToList();
            
            List<CustomerQueryViewModel> vm = _mapper.Map<List<CustomerQueryViewModel>>(customers);

            return vm;
        }
        public class CustomerQueryViewModel
        {
            public string  Name { get; set; }
            public string LastName { get; set; }
        }
    }
}