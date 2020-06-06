using hotchocolate_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotchocolate_ef.Data.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // builder.Property(e => e.Id).ValueGeneratedNever();
            // builder.Property(e => e.Id);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.IsCommentingEnabled);
            builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime");
            builder.Property(e => e.Content);
        }
    }
}