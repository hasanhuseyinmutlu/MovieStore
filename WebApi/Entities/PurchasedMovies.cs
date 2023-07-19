namespace WebApi.Entities
{
    public class PurchasedMovies
    {
        public int Id { get; set; }
        public bool MovieStatus { get; set; }
        public DateTime PurchasedTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        
    }

}