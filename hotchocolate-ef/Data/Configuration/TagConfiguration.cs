using hotchocolate_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotchocolate_ef.Data.Configuration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(32);
            builder.Property(e => e.NormalizedName).HasMaxLength(32);
        }
    }
}