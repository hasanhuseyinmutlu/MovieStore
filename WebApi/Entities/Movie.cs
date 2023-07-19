using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
         public int DirectorId { get; set; }
         public int ActorId  { get; set; }
         public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }



    }
}