
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
    class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25).IsRequired(true);
            builder.Property(x => x.LanguageId).IsRequired(true);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
            builder.Property(x => x.ModifiedAt).HasDefaultValue(DateTime.UtcNow.AddHours(4));
        }
    }
}
