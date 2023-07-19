using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Director
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public virtual ICollection<DirectorMovie> DirectorMovies { get; set; }

    }
}