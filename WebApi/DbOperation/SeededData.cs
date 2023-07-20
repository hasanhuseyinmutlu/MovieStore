using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperation
{
    public class SeededData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

               context.Movies.AddRange(
                    new Movie
                    {
                        Title = "Opennheimer",
                        DirectorId = 3,                       
                        ActorId = 1,
                        GenreId = 2,
                        Price = 200,
                        ReleaseDate = new DateTime(1999, 08, 28),
                    },
                    new Movie
                    {
                        Title = "Mission Impossible",
                        DirectorId = 2,                       
                        ActorId = 1,
                        GenreId = 9,
                        Price = 200,
                        ReleaseDate = new DateTime(1999, 08, 28),
                    },
                    new Movie
                    {
                        Title = "Shining",
                        DirectorId = 4,      
                        ActorId = 3,
                        GenreId = 3,
                        Price = 300,
                        ReleaseDate = new DateTime(2022, 05, 01),
                    },
                    new Movie
                    {
                        Title = "Göktürk",
                        DirectorId = 1,                        
                        ActorId = 4,
                        GenreId = 3,
                        Price = 300,
                        ReleaseDate = new DateTime(2022, 05, 01),
                    }
                );

                context.Actors.AddRange(
                    new Actor
                    {
                        Name = "Cillian",
                        Surname = "Murphy",                        

                    },
                    new Actor
                    {
                        Name = "Robert",
                        Surname = "Downey Jr",                        
                    },
                    new Actor
                    {
                        Name = "Tom",
                        Surname = "Cruise",                        
                    },
                    new Actor
                    {
                        Name = "Nicole",
                        Surname = "Kidman",                        
                    }
                );

                context.ActorMovies.AddRange(
                    new ActorMovies
                    {
                        ActorId = 1,
                        MovieId = 3
                    },
                    new ActorMovies
                    {
                        ActorId = 1,
                        MovieId = 2
                    },
                    new ActorMovies
                    {
                        ActorId = 2,
                        MovieId = 3
                    },
                    new ActorMovies
                    {
                        ActorId = 1,
                        MovieId = 3
                    },
                    new ActorMovies
                    {
                        ActorId = 3,
                        MovieId = 1
                    },
                    new ActorMovies
                    {
                        ActorId = 4,
                        MovieId = 4
                    }
                );

                context.Directors.AddRange(
                    new Director
                    {
                        Name = "Alper",
                        Surname = "Caglar",                        

                    },
                    new Director
                    {
                        Name = "Tony",
                        Surname = "Scott",                        
                    },
                    new Director
                    {
                        Name = "Christopher",
                        Surname = "Nolan",                        
                    },
                    new Director
                    {
                        Name = "Stanley",
                        Surname = "Kubrick",                        
                    }
                );

                context.DirectorMovies.AddRange(
                    new DirectorMovie
                    {
                        DirectorId = 1,
                        MovieId = 1
                    },
                    new DirectorMovie
                    {
                        DirectorId = 2,
                        MovieId = 2
                    },
                    new DirectorMovie
                    {
                        DirectorId = 3,
                        MovieId = 3
                    },
                    new DirectorMovie
                    {
                        DirectorId = 4,
                        MovieId = 4
                    }

                );

                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Hasan",
                        LastName = "Mutlu",    
                        Email = "hhm@mail.com",
                        Password = "1"                    
                    },
                    new Customer
                    {
                        Name = "Yasin",
                        LastName = "Mutlu",  
                        Email = "ysn@mail.com",
                        Password = "2"                           
                    },
                    new Customer() 
                    { 
                        Name = "testName", 
                        LastName = "testSurname" , 
                        Email = "test@gmail.com", 
                        Password = "test"
                    }
                );

                context.PurchasedMovies.AddRange(
                    new PurchasedMovies
                    {
                        MovieStatus = true,
                        PurchasedTime = new DateTime(2022,01,5),
                        CustomerId = 1,
                        MovieId = 1
                    },
                    new PurchasedMovies
                    {
                        MovieStatus = true,
                        PurchasedTime = new DateTime(2022,05,2),
                        CustomerId = 1,
                        MovieId = 2
                    },
                    new PurchasedMovies
                    {
                        MovieStatus = true,
                        PurchasedTime = new DateTime(2022,03,7),
                        CustomerId = 1,
                        MovieId = 3
                    },
                    new PurchasedMovies
                    {
                        MovieStatus = true,
                        PurchasedTime = new DateTime(2019,05,4),
                        CustomerId = 2,
                        MovieId = 4
                    },
                    new PurchasedMovies
                    {
                        MovieStatus = false,
                        PurchasedTime = new DateTime(2020,02,6),
                        CustomerId = 2,
                        MovieId = 1
                    },
                    new PurchasedMovies
                    {
                        MovieStatus = true,
                        PurchasedTime = new DateTime(2020,02,6),
                        CustomerId = 3,
                        MovieId = 4
                    }
                );

                context.FavoriteGenres.AddRange(
                    new FavoriteGenre
                    {
                        CustomerId = 1,
                        FavoriteGenreId = 1
                    },
                    new FavoriteGenre
                    {
                        CustomerId = 1,
                        FavoriteGenreId = 2
                    },
                    new FavoriteGenre
                    {
                        CustomerId = 1,
                        FavoriteGenreId = 3
                    },
                    new FavoriteGenre
                    {
                        CustomerId = 2,
                        FavoriteGenreId = 4
                    },
                    new FavoriteGenre
                    {
                        CustomerId = 2,
                        FavoriteGenreId = 1
                    }
                );

                context.SaveChanges();

            }
        }
    }
}
