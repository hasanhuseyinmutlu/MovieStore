using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
   public class ActorMovies
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie {get; set;}

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}