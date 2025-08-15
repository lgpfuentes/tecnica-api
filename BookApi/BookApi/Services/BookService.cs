using BookApi.Models;
using BookApi.Repository;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Response> getBooks()
        {
            try
            {
                var books = await _bookRepository.getBooks();
                return new Response(true, "Lista de libros obtenida con éxito");
            }
            catch (Exception ex)
            {
                return new Response(false, ex.Message);
            }
        }

        public async Task<Response> getBook(int id)
        {
            try
            {
                var book = await _bookRepository.getBook(id);
                if (book == null)
                    return new Response(false, "Libro no encontrado");

                return new Response(true, "Libro obtenido con éxito");
            }
            catch (Exception ex)
            {
                return new Response(false, ex.Message);
            }
        }

        public async Task<Response> addBook(Book book)
        {
            try
            {
                var added = await _bookRepository.addBook(book);
                if (!added)
                    return new Response(false, "Error al registrar el libro");

                return new Response(true, "Libro agregado con éxito");
            }
            catch (Exception ex)
            {
                return new Response(false, ex.Message);
            }
        }

        public async Task<Response> updateBook(Book book)
        {
            try
            {
                var updated = await _bookRepository.updateBook(book);
                if (!updated)
                    return new Response(false, "Error al actualizar el libro");

                return new Response(true, "Libro actualizado con éxito");
            }
            catch (Exception ex)
            {
                return new Response(false, ex.Message);
            }
        }

        public async Task<Response> deleteBook(int id)
        {
            try
            {
                var deleted = await _bookRepository.deleteBook(id);
                if (!deleted)
                    return new Response(false, "Error al eliminar el libro");

                return new Response(true, "Libro eliminado con éxito");
            }
            catch (Exception ex)
            {
                return new Response(false, ex.Message);
            }
        }
    }
}
