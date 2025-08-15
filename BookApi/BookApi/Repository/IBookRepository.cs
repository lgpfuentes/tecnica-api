using BookApi.Models;

namespace BookApi.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> getBooks();
        Task<Book> getBook(int id);
        Task<bool> addBook(Book book);
        Task<bool> updateBook(Book book);
        Task<bool> deleteBook(int id);
    }
}
