using AutoMapper;
using WebApi.DbOperation;

namespace WebApi.Application.FavoriteGenreOperations.Command
{
    public class UpdateFavoriteGenresCommand
    {
        public int Id;
        public UpdateFavoriteGenresModel Model;
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateFavoriteGenresCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var favoriteGenres = _dbContext.FavoriteGenres.SingleOrDefault(s => s.Id == Id);
            var customerFavoriteGenreList = _dbContext.FavoriteGenres.Where(s => s.Id == favoriteGenres.CustomerId);
            bool checkGenre = false;

            foreach (var item in customerFavoriteGenreList)
            {
                var result = item.FavoriteGenreId;
                checkGenre = result == Model.favoritegenreId ? true: false;
            }

            if (checkGenre)
                throw new InvalidOperationException("genre already exist");
            else if (favoriteGenres is null)
                throw new InvalidOperationException("favorite genre not exist");
            favoriteGenres.FavoriteGenreId = Model.favoritegenreId == default ? favoriteGenres.FavoriteGenreId : Model.favoritegenreId;

            _dbContext.FavoriteGenres.Update(favoriteGenres);
            _dbContext.SaveChanges();
        }

        public class UpdateFavoriteGenresModel
        {
            public int favoritegenreId { get; set; }
        }
    }
}