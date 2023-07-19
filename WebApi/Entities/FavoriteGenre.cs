namespace WebApi.Entities
{
    public class FavoriteGenre
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int FavoriteGenreId { get; set; }
    }
}