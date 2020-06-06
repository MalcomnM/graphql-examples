using HotChocolate.Types;

namespace hotchocolate_ef.Types
{
    public class QueryType
        : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {

            descriptor
                .Field(t => t.GetPosts(default))
                .Type<NonNullType<ListType<PostType>>>()
                .UseSelection(); //UseSelection with IQueryable

            // The order when appling attributes
            // [UsePaging]
            // [UseSelection]
            // [UseFiltering]
            // [UseSorting]
        }
    }
}