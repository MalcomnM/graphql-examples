using System.Linq;
using HotChocolate;
using hotchocolate_ef.Data;
using hotchocolate_ef.Models;

namespace hotchocolate_ef
{
    public class Query
    {
        public IQueryable<Post> GetPosts([Service] BlogDbContext context) => context.Posts;

        public IQueryable<Comment> GetComments([Service] BlogDbContext context) => context.Comments;

        public IQueryable<Tag> GetTags([Service] BlogDbContext context) => context.Tags;
    }
}