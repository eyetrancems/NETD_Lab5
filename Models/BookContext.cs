using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Make sure you use the Nu Get package manager to install the Microsoft Entity Framework Core
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace NETD_Lab5.Models
{
    public class BookContext : DbContext
    {
        //Constructor for BookContext
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Dvd> Dvds { get; set; }



        protected override void
            OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
                .HasKey(x => new { x.bookID, x.authorID });
        }



        public DbSet<NETD_Lab5.Models.BookAuthor> BookAuthor { get; set; }
    }
}
