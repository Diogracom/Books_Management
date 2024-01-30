using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder context)
        {
            context.UseSqlServer("Server=OB-IT-23; Database=BooksManagement; Encrypt=false; TrustServerCertificate=true; User Id = sa");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider without Duty", ISBN = "123812", Price = (double)10.99m },
                new Book { BookId = 2, Title = "Fortune of Time", ISBN = "12113822", Price = (double)11.99m }
                );

            var books = new Book[]
            {
              new Book{  BookId = 3, Title = "Fake Sunday", ISBN = "725229", Price = (double)20.99m },
              new Book{ BookId = 4, Title = "Cookie Jar", ISBN = "4352319", Price = (double)25.99m},
              new Book{ BookId = 5, Title = "Cloudy ", ISBN = "4123319", Price = (double)40.99m},

            };
            modelBuilder.Entity<Book>().HasData(books);
        }

    }
}
