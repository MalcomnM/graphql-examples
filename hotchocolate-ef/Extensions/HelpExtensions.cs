using System;
using System.Collections.Generic;
using hotchocolate_ef.Data;
using hotchocolate_ef.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace hotchocolate_ef.Extensions
{
    public static class HelpExtensions
    {
        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            var context = serviceScope.ServiceProvider.GetRequiredService<BlogDbContext>();
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<BlogDbContext>>();

            if (context.Database.EnsureCreated())
            {
                logger.LogInformation($"Seeding {nameof(BlogDbContext)} database...");

                var posts = new List<Post>
                {
                    new Post
                    {
                        Content = "My first post",
                        CreatedAtUtc = DateTime.UtcNow.AddDays(-7),
                        IsCommentingEnabled = true
                    },
                    new Post
                    {
                        Content = "My second post",
                        CreatedAtUtc = DateTime.UtcNow.AddDays(-6),
                        IsCommentingEnabled = false
                    },
                    new Post
                    {
                        Content = "My third post",
                        CreatedAtUtc = DateTime.UtcNow.AddDays(-5),
                        IsCommentingEnabled = true
                    }
                };

                context.Posts.AddRange(posts);

                var tags = new List<Tag>
                {
                    new Tag { Name = "dotnet", NormalizedName = "DOTNET" },
                    new Tag { Name = "react", NormalizedName = "REACT" },
                    new Tag { Name = "sql", NormalizedName = "SQL" },
                    new Tag { Name = "vscode", NormalizedName = "VSCODE" }
                };

                context.Tags.AddRange(tags);

                var postTags = new List<PostTag>
                {
                    new PostTag { Post = posts[0], PostId = posts[0].Id, Tag = tags[0], TagId = tags[0].Id},
                    new PostTag { Post = posts[0], PostId = posts[0].Id, Tag = tags[3], TagId = tags[3].Id},
                    new PostTag { Post = posts[1], PostId = posts[1].Id, Tag = tags[2], TagId = tags[2].Id},
                    new PostTag { Post = posts[2], PostId = posts[2].Id, Tag = tags[1], TagId = tags[1].Id},
                    new PostTag { Post = posts[2], PostId = posts[2].Id, Tag = tags[3], TagId = tags[3].Id},
                };

                context.PostTag.AddRange(postTags);

                var comments = new List<Comment>
                {
                    new Comment { Username = "Dawid", Content = "Comment number one", CreatedAtUtc = DateTime.UtcNow, Post = posts[0], PostId = posts[0].Id },
                    new Comment { Username = "Alice", Content = "Comment number two", CreatedAtUtc = DateTime.UtcNow, Post = posts[0], PostId = posts[0].Id },
                    new Comment { Username = "Ola", Content = "Comment number three", CreatedAtUtc = DateTime.UtcNow, Post = posts[2], PostId = posts[2].Id },
                    new Comment { Username = "Jurek", Content = "Comment number four", CreatedAtUtc = DateTime.UtcNow, Post = posts[2], PostId = posts[2].Id }
                };

                context.Comments.AddRange(comments);

                var commentReplies = new List<CommentReply>
                {
                    new CommentReply {Username = "User1", Content = "Reply number one", CreateAt = DateTime.UtcNow, Comment = comments[0], CommentId = comments[0].Id },
                    new CommentReply {Username = "User2", Content = "Reply number two", CreateAt = DateTime.UtcNow, Comment = comments[2], CommentId = comments[2].Id },
                    new CommentReply {Username = "User1", Content = "Reply number three", CreateAt = DateTime.UtcNow, Comment = comments[1], CommentId = comments[1].Id },
                    new CommentReply {Username = "User2", Content = "Reply number four", CreateAt = DateTime.UtcNow, Comment = comments[1], CommentId = comments[1].Id },
                    new CommentReply {Username = "User3", Content = "Reply number five", CreateAt = DateTime.UtcNow, Comment = comments[0], CommentId = comments[0].Id }
                };

                context.CommentReplies.AddRange(commentReplies);

                context.SaveChanges();

                logger.LogInformation($"Database initialized.");
            }
            else
            {
                logger.LogInformation($"Database already populated.");
            }

            return app;
        }
    }
}