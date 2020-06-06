using hotchocolate_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotchocolate_ef.Data.Configuration
{
    public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(e => new { e.PostId, e.TagId });

            builder.HasOne(d => d.Post)
                   .WithMany(p => p.PostTag)
                   .HasForeignKey(d => d.PostId);
            //.HasConstraintName("FK_PostTag_Post");

            builder.HasOne(d => d.Tag)
                   .WithMany(p => p.PostTag)
                   .HasForeignKey(d => d.TagId);
            //.HasConstraintName("FK_PostTag_Tag");
        }
    }
}