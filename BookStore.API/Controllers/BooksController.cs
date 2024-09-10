using BookStore.API.Contracts;
using BookStore.BLL.Services;
using BookStore.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }


        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetAllBooks()
        {
            var books = await _booksService.GetAllBooks();

            var response = books
                .Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Rating, b.Price, b.DateAdded));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateBook([FromBody] BooksRequest bookRequest)
        {
            var (book, error) = Book.Create(
                0,
                bookRequest.Title,
                bookRequest.Description,
                bookRequest.Rating,
                bookRequest.Price
            );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var bookId = await _booksService.CreateBook(book);

            return Ok(bookId);
        }
    }
}
