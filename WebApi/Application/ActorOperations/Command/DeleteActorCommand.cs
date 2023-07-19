using WebApi.DbOperation;

namespace WebApi.Application.ActorOperations.Command
{
    public class DeleteActorCommand
    {
        public int actorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(a => a.Id == actorId);
            if (actor is null)
                throw new InvalidOperationException("actor is not exist");
                
            _dbContext.Actors.Remove(actor);
            _dbContext.SaveChanges();
        }

    }
}