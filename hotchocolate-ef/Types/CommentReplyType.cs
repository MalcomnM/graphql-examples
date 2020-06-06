using HotChocolate.Types;
using hotchocolate_ef.Models;

namespace hotchocolate_ef.Types
{
    public class CommentReplyType
        : ObjectType<CommentReply>
    {
        protected override void Configure(IObjectTypeDescriptor<CommentReply> descriptor)
        {
        }
    }
}