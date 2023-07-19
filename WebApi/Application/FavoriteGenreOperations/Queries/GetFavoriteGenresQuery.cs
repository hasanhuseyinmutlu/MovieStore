using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.FavoriteGenreOperations.Queries
{
    public class GetFavoriteGenresQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFavoriteGenresQuery(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public List<FavoriteGenreQueryViewModel> Handle()
        {
            List<Customer> list = _dbContext.Customers.Include(i => i.FavoriteGenres).OrderBy(x => x.Id).ToList();
            List<FavoriteGenreQueryViewModel> vm = _mapper.Map<List<FavoriteGenreQueryViewModel>>(list);
            return vm;
        }
        public class FavoriteGenreQueryViewModel
        {
            public string NameSurname { get; set; }
            public IReadOnlyList<string> Genre { get; set; }
        }
    }    
}