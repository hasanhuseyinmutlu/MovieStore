using WebApi.DbOperation;

namespace WebApi.Application.ActorMoviesOperations.Command
{
    public class DeleteActorMovieCommand
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteActorMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actorMovie = _dbContext.ActorMovies.SingleOrDefault(x => x.Id == Id);

            if (actorMovie is null)
                throw new InvalidOperationException("actormovie not exist");

            _dbContext.ActorMovies.Remove(actorMovie);
            _dbContext.SaveChanges();
        }
    }
}