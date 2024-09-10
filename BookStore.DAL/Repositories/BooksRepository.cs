using BookStore.Domain.Models;
using BookStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _context;
        public BooksRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAsync()
        {
            var bookEntities = await _context.Books.AsNoTracking().ToListAsync();

            var books = bookEntities
                .Select(b => Book.Create(b.Id, b.Title, b.Description, b.Rating, b.Price).Book)
                .ToList();

            return books;
        }

        public async Task<int> CreateAsync(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Rating = book.Rating,
                Price = book.Price,
                DateAdded = book.DateAdded,
            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<string> UpdateAsync(int id, string title, string description, double rating, decimal price)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Title, b => title)
                    .SetProperty(b => b.Description, b => description)
                    .SetProperty(b => b.Rating, b => rating)
                    .SetProperty(b => b.Price, b => price));

            return "Book was updated successfully";
        }

        public async Task<string> DeleteAsync(int id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            return "Book was deleted successfully";
        }
    }
}
