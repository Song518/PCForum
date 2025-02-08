using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCForum.Models
{
    public class Discussion
    {
        [Key]
        public int DiscussionId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; } = string.Empty;

        public string ImageFilename { get; set; } = string.Empty; 

        [NotMapped] 
        public IFormFile? ImageFile { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}

