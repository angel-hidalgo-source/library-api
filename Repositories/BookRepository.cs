using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task LendBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null && book.AvailableCopies > 0)
            {
                book.AvailableCopies--;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Book not available for lending.");
            }
        }

        public async Task ReturnBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null && book.AvailableCopies < book.Copies)
            {
                book.AvailableCopies++;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("Cannot return book that wasn't lent out.");
            }
        }
    }
}
