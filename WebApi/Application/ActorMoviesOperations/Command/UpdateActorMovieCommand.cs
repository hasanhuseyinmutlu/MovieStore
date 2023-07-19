using WebApi.DbOperation;

namespace WebApi.Application.ActorMoviesOperations.Command
{
    public class UpdateActorMovieCommand
    {
        public UpdateActorMovieModel model;
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateActorMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(s => s.Id == model.ActorId);
            var movie = _dbContext.Actors.SingleOrDefault(s => s.Id == model.MovieId);
            var actorMovie = _dbContext.ActorMovies.SingleOrDefault(d => d.Id == Id);

            if (actor is null)
                throw new InvalidOperationException("actor not faund");
            else if (movie is null)
                throw new InvalidOperationException("movie not faund");
            else if (actorMovie is null)
                throw new InvalidOperationException("actor movie not faund");
            actorMovie.ActorId = model.ActorId == default 
            ? actorMovie.ActorId
            : model.ActorId;

            actorMovie.MovieId = model.MovieId == default
            ? actorMovie.MovieId
            : model.MovieId;

            _dbContext.ActorMovies.Update(actorMovie);
            _dbContext.SaveChanges();
        }

        public class UpdateActorMovieModel
        {
            public int MovieId { get; set; }

            public int ActorId { get; set; }

        }
    }
}