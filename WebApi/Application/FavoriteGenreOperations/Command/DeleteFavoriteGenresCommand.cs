using WebApi.DbOperation;

namespace WebApi.Application.FavoriteGenreOperations.Command
{
    public class DeleteFavoriteGenresCommand
    {
        public int Id;
        private readonly    IMovieStoreDbContext _dbContext;

        public DeleteFavoriteGenresCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var favoriteGenres = _dbContext.FavoriteGenres.SingleOrDefault(x => x.Id == Id);

            if (favoriteGenres is null)
                throw new InvalidOperationException("favoritegenre is null");

            _dbContext.FavoriteGenres.Remove(favoriteGenres);
            _dbContext.SaveChanges();
        }
    }
}