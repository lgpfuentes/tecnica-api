using BookApi.Models;

namespace BookApi.Services
{
    public interface IBookService
    {
        Task<Response> getBooks();
        Task<Response> getBook(int id);
        Task<Response> addBook(Book book);
        Task<Response> updateBook(Book book);
        Task<Response> deleteBook(int id);
    }
}
