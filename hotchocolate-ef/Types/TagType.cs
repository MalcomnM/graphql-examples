using HotChocolate.Types;
using hotchocolate_ef.Models;

namespace hotchocolate_ef.Types
{
    public class TagType
        : ObjectType<Tag>
    {
        protected override void Configure(IObjectTypeDescriptor<Tag> descriptor)
        {
        }
    }
}