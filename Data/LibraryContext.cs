using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;

namespace LibraryAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book { Id = 1, Title = "A Tale of Two Cities", Author = "Charles Dickens", Copies = 20, AvailableCopies = 17 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 2, Title = "The Little Prince (Le Petit Prince)", Author = "Antoine de Saint-Exupéry", Copies = 20, AvailableCopies = 14 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 3, Title = "The Alchemist (O Alquimista)", Author = "Paulo Coelho", Copies = 15, AvailableCopies = 11 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 4, Title = "Harry Potter and the Philosopher's Stone", Author = "J. K. Rowling", Copies = 12, AvailableCopies = 6 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 5, Title = "And Then There Were None", Author = "Agatha Christie", Copies = 10, AvailableCopies = 6 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 6, Title = "Dream of the Red Chamber", Author = "Cao Xueqin", Copies = 10, AvailableCopies = 9 });
            modelBuilder.Entity<Book>().HasData(new Book { Id = 7, Title = "The Hobbit", Author = "J. R. R. Tolkien", Copies = 10, AvailableCopies = 8 });
        }
    }


}
