using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PCForum.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageFilename { get; set; }

        [Display(Name = "Created")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public ICollection<Comment> Comments { get; set; }
    }
}
