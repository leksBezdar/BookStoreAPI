namespace BookStore.DAL.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; } = 0.0;
        public decimal Price { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
