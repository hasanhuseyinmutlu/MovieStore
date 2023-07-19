using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations
{
    public class CreateCustomerCommand
    {
        public CustomerModel Model;
        private readonly IMovieStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var user = _dbContext.Customers.SingleOrDefault(c => c.Email.ToLower() == Model.Email.ToLower());
            if (user is not null)
                throw new InvalidOperationException("User already exist");

            user = _mapper.Map<Customer>(Model);

            _dbContext.Customers.Add(user);
            _dbContext.SaveChanges();
        }

        public class CustomerModel
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}