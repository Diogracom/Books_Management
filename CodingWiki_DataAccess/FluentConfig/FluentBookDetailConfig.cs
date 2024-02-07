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
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_BookDetails");
            modelBuilder.Property(u => u.NumberOfChapters).HasColumnName("NoOfChapters");
            modelBuilder.HasKey(x => x.BookDetail_Id);
            modelBuilder.Property(n => n.NumberOfChapters).IsRequired();
            modelBuilder.HasOne(p => p.Fluent_BookRef).WithOne(p => p.Fluent_BookDetailRef)
                .HasForeignKey<Fluent_BookDetail>(u => u.Book_Id);
        }
    }
}
