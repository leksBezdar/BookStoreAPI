using BookStore.Domain.Models;

namespace BookStore.DAL.Repositories
{
    public interface IBooksRepository
    {
        Task<int> CreateAsync(Book book);
        Task<string> DeleteAsync(int id);
        Task<List<Book>> GetAsync();
        Task<string> UpdateAsync(int id, string title, string description, double rating, decimal price);
    }
}