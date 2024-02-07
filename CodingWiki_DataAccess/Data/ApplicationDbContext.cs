using CodingWiki_DataAccess.FluentConfig;
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
        public DbSet<BookDetail> BookDetails { get; set; }

        //rename BooDtails
        public DbSet<Fluent_BookDetail> BookDetails_Fluent { get; set; }
        public DbSet<Fluent_Book> Fluent_Books { get; set; }

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder context)
        {
           // context.UseSqlServer("Server=OB-IT-23; Database=BooksManagement; Encrypt=false; TrustServerCertificate=true; User Id = sa");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           // modelBuilder.Entity<BookAuthorMap>().HasKey(u => new {u.Author_Id, u.Book_Id});
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());
            modelBuilder.ApplyConfiguration(new FluentSubCategoryConfig());
           
            

            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Spider without Duty", ISBN = "123812", Price = (double)10.99m , Publisher_Id = 1 },
                new Book { BookId = 2, Title = "Fortune of Time", ISBN = "12113822", Price = (double)11.99m , Publisher_Id = 2 }
                );

            var books = new Book[]
            {
              new Book{  BookId = 3, Title = "Fake Sunday", ISBN = "725229", Price = (double)20.99m, Publisher_Id = 2 },
              new Book{ BookId = 4, Title = "Cookie Jar", ISBN = "4352319", Price = (double)25.99m, Publisher_Id = 3},
              new Book{ BookId = 5, Title = "Cloudy ", ISBN = "4123319", Price = (double)40.99m, Publisher_Id = 1},

            };
            modelBuilder.Entity<Book>().HasData(books);

            var publisher = new Publisher[]
            {
                new Publisher { Publisher_Id = 1, Name = "Marcus Robbens", Location = "London" },
                new Publisher { Publisher_Id = 2, Name = "Roberto Robbens", Location = "New York" },
                new Publisher { Publisher_Id = 3, Name = "Marcus Martines", Location = "United States" },
            };
            modelBuilder.Entity<Publisher>().HasData(publisher);
        }

    }
}
