using hotchocolate_ef.Data.Configuration;
using hotchocolate_ef.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace hotchocolate_ef.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext() { }

        public BlogDbContext(DbContextOptions options)
            : base(options)
        {
        }


        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentReply> CommentReplies { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PostTag> PostTag { get; set; }

        // log to cosole
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(databaseName: "blogDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new CommentReplyConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new PostTagConfiguration());
        }

    }
}