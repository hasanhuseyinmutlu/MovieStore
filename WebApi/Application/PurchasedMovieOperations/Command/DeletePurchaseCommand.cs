using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.PurchasedMovieOperations.Command
{
    public class DeletePurchaseCommand
    {
        public int Id;
        private readonly IMovieStoreDbContext _dbCotnext;

        public DeletePurchaseCommand(IMovieStoreDbContext dbCotnext)
        {
            _dbCotnext = dbCotnext;
        }
        public void Handle()
        {
            PurchasedMovies purchasedMovies = _dbCotnext.PurchasedMovies.SingleOrDefault(s => s.Id == Id);
            if (purchasedMovies is null)
                throw new InvalidOperationException("there is no purchased movie");
            purchasedMovies.MovieStatus = false;
            _dbCotnext.PurchasedMovies.Update(purchasedMovies);
            _dbCotnext.SaveChanges();
        }
    }
}