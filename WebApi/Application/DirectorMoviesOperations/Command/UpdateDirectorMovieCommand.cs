using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.DirectorMoviesOperations.Command
{
    public class UpdateDirectorMovieCommand
    {
        public UpdateDirectorMovieModel model;
        public int directorMovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateDirectorMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == model.DirectorId);

            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == model.MovieId);

            var directorMovie = _dbContext.DirectorMovies.SingleOrDefault(x => x.Id == directorMovieId);

            if (director is null)
                throw new InvalidOperationException("director not faund");
            if (movie is null)
                throw new InvalidOperationException("movie not faund");
            if (directorMovie is null)
                throw new InvalidOperationException("directorMovie is not faund");

            directorMovie.DirectorId = model.DirectorId == default
            ? directorMovie.DirectorId
            : model.DirectorId;

            directorMovie.MovieId = model.MovieId == default
            ? directorMovie.MovieId
            : model.MovieId;

            _dbContext.DirectorMovies.Update(directorMovie);
            _dbContext.SaveChanges();
        }
        public class UpdateDirectorMovieModel
        {
            public int MovieId { get; set; }
            public int DirectorId { get; set; } 
        }
    }

    
}