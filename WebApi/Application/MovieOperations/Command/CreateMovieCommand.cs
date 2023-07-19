using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Command
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
       private readonly IMovieStoreDbContext _dbContext;

       private readonly IMapper _mapper;

        public CreateMovieCommand(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Title == Model.Title);

            if (movie is not null)
                throw new InvalidOperationException("Movie already exist");

            movie = _mapper.Map<Movie>(Model);

            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        public class CreateMovieModel
        {
            public string Title { get; set; }

            public int GenreId { get; set; }

            public decimal Price { get; set; }

            public DateTime ReleaseDate { get; set; }
        }
    }
}