using WebApi.DbOperation;

namespace WebApi.Application.DirectorOperations.Command
{
    public class DeleteDirectorCommand
    {
        public int directorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(d => d.Id == directorId);
            if (director is null )
                throw new InvalidOperationException("Director not exist ");
            _dbContext.Directors.Remove(director);
            _dbContext.SaveChanges();
        }
    }
}