using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public ICollection<PurchasedMovies> PurchasedMovies { get; set; }
        public ICollection<FavoriteGenre> FavoriteGenres { get; set; }
    }
}