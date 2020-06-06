using System;
using System.Collections.Generic;

namespace hotchocolate_ef.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAtUtc { get; set; }

        public ICollection<CommentReply> CommentReplies { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}