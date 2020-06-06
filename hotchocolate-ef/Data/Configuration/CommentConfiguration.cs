using hotchocolate_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotchocolate_ef.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Content).IsRequired();
            builder.Property(e => e.CreatedAtUtc).HasColumnType("datetime");
            builder.Property(e => e.Username).HasMaxLength(64);
            builder.HasOne(d => d.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId);
            // .HasConstraintName("FK_Comment_Post");
        }
    }
}