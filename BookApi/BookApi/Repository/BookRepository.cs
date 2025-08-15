using BookApi.Models;
using BookApi.Repository;

namespace BookApi.Repositories
    {
        public class BookRepository : IBookRepository
    {
            // Lista en memoria para simular la BD
            private readonly List<Book> _books;

            public BookRepository()
            {
                _books = new List<Book>
            {
                new Book { Id = 1, Title = "El Principito", Author = "Antoine de Saint-Exupéry", ISBN = "978-0156013987", PublishedDate = new DateTime(1943, 4, 6), Summary = "Un pequeño príncipe viaja por el universo aprendiendo lecciones de vida." },
                new Book { Id = 2, Title = "Cien años de soledad", Author = "Gabriel García Márquez", ISBN = "978-0307474728", PublishedDate = new DateTime(1967, 6, 5), Summary = "Historia de la familia Buendía a lo largo de varias generaciones en Macondo." },
                new Book { Id = 3, Title = "Don Quijote de la Mancha", Author = "Miguel de Cervantes", ISBN = "978-8491050295", PublishedDate = new DateTime(1605, 1, 16), Summary = "Un caballero loco y su fiel escudero recorren España en busca de aventuras." }
            };
            }

            public Task<List<Book>> getBooks()
            {
                return Task.FromResult(_books);
            }

            public Task<Book> getBook(int id)
            {
                var book = _books.FirstOrDefault(b => b.Id == id);
                return Task.FromResult(book);
            }

            public Task<bool> addBook(Book book)
            {
                // Generar Id automáticamente
                book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
                _books.Add(book);
                return Task.FromResult(true);
            }

            public Task<bool> updateBook(Book book)
            {
                var existing = _books.FirstOrDefault(b => b.Id == book.Id);
                if (existing == null)
                    return Task.FromResult(false);

                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.ISBN = book.ISBN;
                existing.PublishedDate = book.PublishedDate;
                existing.Summary = book.Summary;

                return Task.FromResult(true);
            }

            public Task<bool> deleteBook(int id)
            {
                var book = _books.FirstOrDefault(b => b.Id == id);
                if (book == null)
                    return Task.FromResult(false);

                _books.Remove(book);
                return Task.FromResult(true);
            }
        }
    }
