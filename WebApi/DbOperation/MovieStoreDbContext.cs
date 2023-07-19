using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperation
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MovieStoreDB");
        }   
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext>options) : base(options){}
        public DbSet<Movie> Movies {get; set;}
        
        public DbSet<Actor> Actors {get; set;}
        public DbSet<ActorMovies> ActorMovies {get; set;}
        public DbSet<Director> Directors {get; set;}
        public DbSet<DirectorMovie> DirectorMovies {get; set;}
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}