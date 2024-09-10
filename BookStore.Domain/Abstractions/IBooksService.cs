using BookStore.Domain.Models;

namespace BookStore.BLL.Services
{
    public interface IBooksService
    {
        Task<int> CreateBook(Book book);
        Task<string> DeleteBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<string> UpdateBook(int id, string title, string description, double rating, decimal price);
    }
}