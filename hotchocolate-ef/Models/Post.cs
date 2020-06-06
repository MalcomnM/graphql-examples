using System;
using System.Collections.Generic;

namespace hotchocolate_ef.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public bool IsCommentingEnabled { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostTag> PostTag { get; set; }
    }
}