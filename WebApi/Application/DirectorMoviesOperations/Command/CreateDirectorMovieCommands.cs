using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.DirectorMoviesOperations.Command
{
    
    public class CreateDirectorMovieCommands
    {
        public CreateDirectorMovieModel model;
        private readonly IMovieStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public CreateDirectorMovieCommands(IMapper mapper, IMovieStoreDbContext dbContext = null)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == model.DirectorId );

            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == model.MovieId);

            var directorMovies = _dbContext.DirectorMovies.SingleOrDefault(d => d.DirectorId == model.DirectorId && d.MovieId == model.MovieId);

            if (director is null)
                throw new InvalidOperationException("Diractor has not found");
            else if (movie is null)
                throw new InvalidOperationException("Movie has not found");
            else if (directorMovies is not null)
                throw new InvalidOperationException("directormovies is not null");

            DirectorMovie result = _mapper.Map<DirectorMovie>(model);
            
            _dbContext.DirectorMovies.Add(result);
            _dbContext.SaveChanges();
        }
    }
    public class CreateDirectorMovieModel
    {
        public int MovieId { get; set; }
        public int DirectorId { get; set; }
    }
}