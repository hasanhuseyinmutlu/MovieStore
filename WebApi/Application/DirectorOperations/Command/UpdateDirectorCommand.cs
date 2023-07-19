using AutoMapper;
using WebApi.DbOperation;

namespace WebApi.Application.DirectorOperations.Command
{
    public class UpdateDirectorCommand
    {
        public int directorId;
        public UpdateDirectorModel model;
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateDirectorCommand( IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(d => d.Id == directorId);
            if (director is null)
                throw new InvalidOperationException("Director not exist ");

            director.Name = model.Name.Trim() == default
            ? director.Name
            : model.Name;

            director.Surname = model.Surname.Trim() == default
            ? director.Name
            : model.Surname;

            _dbContext.Directors.Update(director);
            _dbContext.SaveChanges();
            
        }

    }
    public class UpdateDirectorModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}