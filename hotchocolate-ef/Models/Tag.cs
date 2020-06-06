using System.Collections.Generic;

namespace hotchocolate_ef.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public ICollection<PostTag> PostTag { get; set; }
    }
}