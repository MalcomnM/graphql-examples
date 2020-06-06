using hotchocolate_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotchocolate_ef.Data.Configuration
{
    public class CommentReplyConfiguration : IEntityTypeConfiguration<CommentReply>
    {
        public void Configure(EntityTypeBuilder<CommentReply> builder)
        {
            // builder.Property(e => e.Id).ValueGeneratedNever();
            // builder.Property(e => e.Id);
            builder.HasKey(e => e.Id);
            builder.Property(e => e.CreateAt).HasColumnType("datetime");
            builder.Property(e => e.Username).HasMaxLength(64);
            builder.HasOne(d => d.Comment)
                .WithMany(p => p.CommentReplies)
                .HasForeignKey(d => d.CommentId);
        }
    }
}