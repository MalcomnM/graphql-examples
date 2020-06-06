using HotChocolate.Types;
using hotchocolate_ef.Models;

namespace hotchocolate_ef.Types
{
    public class PostType
        : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
        }
    }
}