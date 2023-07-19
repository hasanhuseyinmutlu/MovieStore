using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.PurchasedMovieOperations.Command
{
    public class CreatePurchaseMovieCommand
    {
        public PurchasedMovieModel model;
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePurchaseMovieCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(s => s.Id == model.CustomerId);
            var movie = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            var purchasedMovie = _dbContext.PurchasedMovies.SingleOrDefault(s => s.CustomerId == model.CustomerId && s.MovieId == model.MovieId);
            if (customer is null)
                throw new InvalidOperationException("customer not faund");
            else if (movie is null)
                throw new InvalidOperationException("movie not faund");
            else if (purchasedMovie is not null)
                throw new InvalidOperationException("customer already purchased movie");

            PurchasedMovies result = _mapper.Map<PurchasedMovies>(model);

            result.PurchasedTime = DateTime.Now;
            result.MovieStatus = true;
            
            

            _dbContext.PurchasedMovies.Add(result);
            _dbContext.SaveChanges();
        }
        public class PurchasedMovieModel
        {
            public int MovieId { get; set; }

            public int CustomerId { get; set; }
            DateTime PurchasedTime = DateTime.Now;
            bool MovieStatus = true;
        }

    }
}