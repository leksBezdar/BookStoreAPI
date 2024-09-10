namespace BookStore.Domain.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 128;

        private Book(
            int id,
            string? title,
            string? description,
            double rating,
            decimal price,
            DateTime dateAdded)
        {
            Id = id;
            Title = title;
            Description = description;
            Rating = rating;
            Price = price;
            DateAdded = dateAdded;
        }

        public int Id { get; }
        public string? Title { get; }
        public string? Description { get; }
        public double Rating { get; } = 0.0;
        public decimal Price { get; }
        public DateTime DateAdded { get; }

        public static (Book Book, string Error) Create(
            int id,
            string? title,
            string? description,
            double rating,
            decimal price,
            DateTime dateAdded)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Title cannot be null, empty, or longer than {MAX_TITLE_LENGTH} characters.";
            }

            var book = new Book(id, title, description, rating, price, dateAdded);
            return (book, error);
        }
    }
}
