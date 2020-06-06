using System.Linq;
using HotChocolate.Types;
using hotchocolate_ef.Data;
using hotchocolate_ef.Models;

namespace hotchocolate_ef.Types
{
    public class CommentType
        : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            // descriptor.Field(t => t.CommentReplies)
            //     // Add resolver within type config
            //     .Resolver(context =>
            //         context.Service<BlogDbContext>().CommentReplies
            //             .Where(c => c.CommentId == context.Parent<Comment>().Id)
            //             .ToList());
        }
    }
}