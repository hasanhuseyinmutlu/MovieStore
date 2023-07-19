using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.FavoriteGenreOperations.Command
{
    public class CreateFavoriteGenresCommand
    {
        public FavoriteGenreModel model;
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateFavoriteGenresCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == model.CustomerId);

            var favoriteGenre = _dbContext.FavoriteGenres.SingleOrDefault(f => f.CustomerId == model.CustomerId && f.FavoriteGenreId == model.FavoritesGenreId);

            if (customer is null)
                throw new InvalidOperationException("customer not faund");
            else if (favoriteGenre is not null)
                throw new InvalidOperationException("genre already in favorites");

            FavoriteGenre result = _mapper.Map<FavoriteGenre>(model); 

            _dbContext.FavoriteGenres.Add(result);
            _dbContext.SaveChanges();


        }
        public class FavoriteGenreModel
        {
            public int FavoritesGenreId { get; set; }
            public int CustomerId { get; set; }
        }
        
        
    }
}