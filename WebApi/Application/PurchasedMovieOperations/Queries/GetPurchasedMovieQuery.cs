using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperation;
using WebApi.Entities;

namespace WebApi.Application.PurchasedMovieOperations.Queries
{
    public class GetPurchasedMovieQuery
    {
        public PurchasedMovieViewModel model;
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPurchasedMovieQuery(IMapper mapper, IMovieStoreDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public List<PurchasedMovieViewModel> Handle()
        {
            List<Customer> list = _dbContext.Customers.Include(i => i.PurchasedMovies).ThenInclude(t => t.Movie).Where(w => w.PurchasedMovies.Any(a => a.MovieStatus)).OrderBy(x => x.Id).ToList();
            
            List<PurchasedMovieViewModel> vm = _mapper.Map<List<PurchasedMovieViewModel>>(list);

            return vm;
        }
        public class PurchasedMovieViewModel
        {
            public string NameLastName { get; set; }

            public IReadOnlyList<string> Movies {get; set;}
            public IReadOnlyList<string> Price { get; set; }
            public IReadOnlyList<string> PurchasedDate { get; set; }
        }
    }
}