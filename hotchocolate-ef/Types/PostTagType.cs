using HotChocolate.Types;
using hotchocolate_ef.Models;

namespace hotchocolate_ef.Types
{
    public class PostTagType
        : ObjectType<PostTag>
    {
        protected override void Configure(IObjectTypeDescriptor<PostTag> descriptor)
        {
        }
    }
}