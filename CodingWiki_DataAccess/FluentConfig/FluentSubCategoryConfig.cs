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
    public class FluentSubCategoryConfig : IEntityTypeConfiguration<Fluent_SubCategory>
    {
        public void Configure(EntityTypeBuilder<Fluent_SubCategory> modelBuilder)
        {
            modelBuilder.HasKey(r => r.SubCategory_Id);
            modelBuilder.Property(p => p.Name).HasMaxLength(50);
            modelBuilder.Property(p => p.Name).IsRequired();
        }
    }
}
