using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.HasKey(r => r.BookId);
            modelBuilder.Property(p => p.ISBN).IsRequired();
            modelBuilder.Property(p => p.ISBN).HasMaxLength(50);
            modelBuilder.Ignore(p => p.PriceRange);
            modelBuilder.HasOne(u => u.Fluent_PublisherRef).WithMany(u => u.Fluent_Books).HasForeignKey(u => u.Publisher_Id);

        }
    }
}
