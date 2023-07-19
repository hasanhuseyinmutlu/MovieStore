using WebApi.DbOperation;

namespace WebApi.Application.ActorOperations.Command
{
    public class UpdateActorCommand
    {
        public int actorId { get; set; }

        public UpdateActorModel model;
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(a => a.Id == actorId);
            if (actor is null)
                throw new InvalidOperationException("actor not exist");
            actor.Name = model.Name.Trim() == default
            ? actor.Name
            : model.Name;

            actor.Surname = model.Surname.Trim() == default
            ? actor.Surname
            : model.Surname;

            _dbContext.Actors.Update(actor);
            _dbContext.SaveChanges();
        }

        public class UpdateActorModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }

    }
}