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
                        Title = "İnception",
                        ActorId = 1,
                        DirectorId = 1, 
                        GenreId = 1,
                        Price = 10,
                        ReleaseDate = new DateTime(2010, 1, 1)
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
