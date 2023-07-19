using WebApi.DbOperation;

namespace WebApi.Application.MovieOperations.Command
{
    public class UpdateMovieCommand
    {
        private readonly IMovieStoreDbContext _dbContext;
        public UpdateMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int MovieId { get; set; }

        public UpdateMovieModel Model {get; set;}

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("Movie not exist");

            movie.Title = Model.Title.Trim() != default
            ?movie.Title
            : Model.Title;

            movie.GenreId = Model.GenreId != default
            ? Model.GenreId
            : movie.GenreId;

            movie.Price = Model.Price != default
            ? Model.Price
            : movie.Price;

            movie.ReleaseDate = Model.ReleaseDate != default
            ? Model.ReleaseDate
            : movie.ReleaseDate;
            
            _dbContext.Movies.Update(movie);
            _dbContext.SaveChanges(); 
        }

        public class UpdateMovieModel
        {
            public string Title { get; set; }

            public int GenreId { get; set; }

            public decimal Price { get; set; }

            public DateTime ReleaseDate { get; set; }
        }
    }   
}