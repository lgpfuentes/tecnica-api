using Microsoft.AspNetCore.Mvc;
using BookApi.Services;
using BookApi.Models;

namespace BookApi.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET /book
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var response = await _bookService.getBooks();
            return Ok(response);
        }

        // GET /book/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await _bookService.getBook(id);
            return Ok(response);
        }

        // POST /book
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            try
            {
                var response = await _bookService.addBook(book);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT /book
        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromBody] Book book)
        {
            try
            {
                var response = await _bookService.updateBook(book);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE /book/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            try
            {
                var response = await _bookService.deleteBook(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
