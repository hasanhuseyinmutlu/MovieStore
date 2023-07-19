using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Command
{
    public class UpdateCutomerCommand
    {
        public int Id;
        private readonly IMovieStoreDbContext _context;

        public UpdateCutomerCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            Customer customer = _context.Customers.SingleOrDefault(x => x.Id == Id);

            if (customer is null)
                throw new InvalidCastException("there is no customer for delete");
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}