namespace BookStore.API.Contracts
{
    public record BooksResponse(
        int Id,
        string Title,
        string Description,
        double Rating,
        decimal Price,
        DateTime DateAdded
        );
}
