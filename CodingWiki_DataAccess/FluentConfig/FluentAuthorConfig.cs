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
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> modelBuilder)
        {
            modelBuilder.HasKey(r => r.Author_Id);
            modelBuilder.Property(p => p.FirstName).HasMaxLength(50);
            modelBuilder.Property(p => p.FirstName).IsRequired();
            modelBuilder.Property(p => p.LastName).IsRequired();
            modelBuilder.Ignore(p => p.FullName);
        }
    }
}
