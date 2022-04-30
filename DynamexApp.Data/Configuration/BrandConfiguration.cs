using DynamexApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Configuration
{
    class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Image).IsRequired(true);
            builder.Property(x => x.Link).IsRequired(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.ModifiedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
        }
    }
}
