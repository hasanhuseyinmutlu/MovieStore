using WebApi.DbOperation;
using WebApi.Entities;
using static WebApi.Application.CustomerOperations.CreateCustomerCommand;

namespace WebApi.Application.CustomerOperations.Command
{
    public class UpdateCustomerCommand
    {
        public int Id;
        public CustomerModel Model;

        private readonly IMovieStoreDbContext _context;

        public UpdateCustomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        
        public void Handle()
        {
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == Id);

            if( customer is null)
                throw new InvalidOperationException("customer not exist");
            customer.Name = Model.Name == default ? customer.Name :Model.Name;
            customer.LastName = Model.LastName == default ? customer.LastName : Model.LastName;
            customer.Email =Model.Email == default ? customer.Email : Model.Email;
            customer.Password = Model.Password == default ? customer.Password : Model.Password;

            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}