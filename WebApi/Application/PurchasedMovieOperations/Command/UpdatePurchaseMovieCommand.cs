using WebApi.DbOperation;
using WebApi.Entities;
using static WebApi.Application.PurchasedMovieOperations.Command.CreatePurchaseMovieCommand;

namespace WebApi.Application.PurchasedMovieOperations.Command
{
    public class UpdatePurchaseMovieCommand
    {
        public int Id { get; set; }
        public PurchasedMovieModel model;
        private readonly IMovieStoreDbContext _dbContext;

        public UpdatePurchaseMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

         public void Handle()
        {
            Customer customer = _dbContext.Customers.SingleOrDefault(s => s.Id == model.CustomerId);

            Movie movies = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);

            PurchasedMovies checkPurchasedMovie  = _dbContext.PurchasedMovies.Single(s => s.CustomerId == model.CustomerId && s.MovieId == model.MovieId);

            PurchasedMovies purchasedMovies = _dbContext.PurchasedMovies.SingleOrDefault(s => s.Id == Id);

            if (customer is null)
                throw new InvalidOperationException("Müşteri bulunamadı!");
            else if (movies is null)
                throw new InvalidOperationException("Film bulunamadı!");
            else if (checkPurchasedMovie is not null)
                throw new InvalidOperationException("Müşteri, daha önce bu filmi satın almış!");
            else if(purchasedMovies is null)
                throw new InvalidOperationException("ilgili kayda ait veri bulunamadı.");

            purchasedMovies.CustomerId = model.CustomerId == default ? purchasedMovies.CustomerId : model.CustomerId;
            
            purchasedMovies.MovieId = model.MovieId == default ? purchasedMovies.MovieId : model.MovieId;

            _dbContext.PurchasedMovies.Update(purchasedMovies);
            _dbContext.SaveChanges();
        }
    }
}