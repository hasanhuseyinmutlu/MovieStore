using WebApi.DbOperation;

namespace WebApi.Application.DirectorMoviesOperations.Command
{
    public class DeleteDirectorMovieCommand
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteDirectorMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var directorMovie = _dbContext.DirectorMovies.SingleOrDefault(d => d.Id == Id);

            if(directorMovie is null)
                throw new InvalidOperationException("directorMovie not faund");

            _dbContext.DirectorMovies.Remove(directorMovie);
            _dbContext.SaveChanges();
        }
    }

}