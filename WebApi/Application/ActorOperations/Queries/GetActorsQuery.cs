using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _dbContex;
        private readonly IMapper _mapper;

        public GetActorsQuery(IMapper mapper, IMovieStoreDbContext dbContex)
        {
            _mapper = mapper;
            _dbContex = dbContex;
        }

        public List<GetActorsQueryViewModel> Handle()
        {
            List<Actor> actors = _dbContex.Actors.OrderBy(x => x.Id).ToList();
            List<GetActorsQueryViewModel> vm = _mapper.Map<List<GetActorsQueryViewModel>>(actors);

            return vm;
        }
    }
    public class GetActorsQueryViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}