using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperation;

namespace WebApi.Application.DirectorMoviesOperations.Queries
{
    public class GetDirectorMovieQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorMovieQuery(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<GetDirectorMovieViewModel> Handle()
        {
            var directors = _dbContext.Directors.Include(i => i.DirectorMovies).ThenInclude(m => m.Movie).OrderBy(x => x.Id).ToList();

            List<GetDirectorMovieViewModel> vm = _mapper.Map<List<GetDirectorMovieViewModel>>(directors);
            
            return vm;
        }
    }
    public class GetDirectorMovieViewModel
    {
        public string NameAndSurname { get; set; }

        public IReadOnlyList<string> Movies {get; set;}
    }
}