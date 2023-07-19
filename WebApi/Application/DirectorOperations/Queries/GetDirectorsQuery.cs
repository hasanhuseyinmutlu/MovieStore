using AutoMapper;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<GetDirectorsQueryViewModel> Handle()
        {
            List<Director> director = _dbContext.Directors.OrderBy(x => x.Id).ToList();
            List<GetDirectorsQueryViewModel> vm = _mapper.Map<List<GetDirectorsQueryViewModel>>(director);

            return vm;
        }
    }
    public class GetDirectorsQueryViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}