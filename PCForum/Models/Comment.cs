using System.ComponentModel.DataAnnotations;

namespace PCForum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int DiscussionId { get; set; }

        
        public Discussion Discussion { get; set; }
    }
}
