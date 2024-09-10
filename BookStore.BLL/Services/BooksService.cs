using BookStore.Domain.Models;
using BookStore.DAL.Repositories;

namespace BookStore.BLL.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _booksRepository.GetAsync();
        }

        public async Task<int> CreateBook(Book book)
        {
            return await _booksRepository.CreateAsync(book);
        }

        public async Task<string> UpdateBook(int id, string title, string description, double rating, decimal price)
        {
            return await _booksRepository.UpdateAsync(id, title, description, rating, price);
        }

        public async Task<string> DeleteBook(int id)
        {
            return await _booksRepository.DeleteAsync(id);
        }

    }
}
