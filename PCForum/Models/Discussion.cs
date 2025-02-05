using System.Xml.Linq;

namespace PCForum.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageFilename { get; set; }
        public DateTime CreateDate { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
