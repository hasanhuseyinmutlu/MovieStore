using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperation
{
    public interface IMovieStoreDbContext
    {
        DbSet<Movie> Movies {get; set;}
        DbSet<Actor> Actors {get; set;}
        DbSet<ActorMovies> ActorMovies {get; set;}
        DbSet<Director> Directors {get; set;}
        DbSet<DirectorMovie> DirectorMovies {get; set;}
        DbSet<Customer> Customers {get; set;}
        DbSet<PurchasedMovies> PurchasedMovies {get; set;}
        DbSet<FavoriteGenre> FavoriteGenres {get; set;}
        int SaveChanges();
    }
}