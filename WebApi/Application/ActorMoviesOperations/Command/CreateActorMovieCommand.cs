using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.ActorMoviesOperations.Command
{
    public class CreateActorMovieCommand
    {
        public CreateActorMovieModel model;
        private readonly IMovieStoreDbContext _dbContext;

        public readonly IMapper _mapper;

        public CreateActorMovieCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(s => s.Id == model.ActorId);

            var movie = _dbContext.Movies.SingleOrDefault(s => s.Id == model.MovieId);

            var actorMovies = _dbContext.ActorMovies.SingleOrDefault(s => s.ActorId == model.ActorId && s.MovieId == model.MovieId);

            if (actor is null)
                throw new InvalidOperationException("Actor has not found!");
            else if (movie is null)
                throw new InvalidOperationException("Movie not found !");
            else if (actorMovies is not null)
                throw new InvalidOperationException("actormovies is not null");

            ActorMovies result = _mapper.Map<ActorMovies>(model);

            _dbContext.ActorMovies.Add(result);
            _dbContext.SaveChanges();
        }

        public class CreateActorMovieModel
        {
            public int MovieId { get; set; }
            public int ActorId { get; set; }
        }
    }

}