using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperation;

namespace WebApi.Application.ActorMoviesOperations.Queries
{
    public class GetActorMovieQuery
    {
        private readonly IMovieStoreDbContext _dbContex;

        private readonly IMapper _mapper;

        public GetActorMovieQuery(IMapper mapper, IMovieStoreDbContext dbContex)
        {
            _mapper = mapper;
            _dbContex = dbContex;
        }
        public List<GetActorMovieViewModel> Handle()
        {
            var actors = _dbContex.Actors.Include(i => i.ActorMovies).ThenInclude(m => m.Movie).OrderBy(x => x.Id).ToList();

            List<GetActorMovieViewModel> vm = _mapper.Map<List<GetActorMovieViewModel>>(actors);
            
            return vm;
        }
        
    }

    public class GetActorMovieViewModel
    {
        public string NameSurName {get; set;}
        public IReadOnlyList<string> Movies {get; set;}
    }
}