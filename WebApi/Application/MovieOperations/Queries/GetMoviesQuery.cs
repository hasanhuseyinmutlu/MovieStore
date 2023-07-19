using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetMoviesQuery(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<MoviesViewModel> Handle()
        {
            var movies = _dbContext.Movies.OrderBy(x => x.Id).ToList<Movie>();

            List<MoviesViewModel> obj = _mapper.Map<List<MoviesViewModel>>(movies);

            return obj;
        }

        public class MoviesViewModel
        {
            public string Title { get; set; }

            public decimal Price { get; set; }

            public string ReleaseDate { get; set; }

        }
    }
}