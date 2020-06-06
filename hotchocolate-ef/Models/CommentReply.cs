using System;

namespace hotchocolate_ef.Models
{
    public class CommentReply
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public DateTime CreateAt { get; set; }

        public Comment Comment { get; set; }
        public int? CommentId { get; set; }
    }
}