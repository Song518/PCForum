using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCForum.Data;
using PCForum.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PCForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly PCForumContext _context;

        public CommentsController(PCForumContext context)
        {
            _context = context;
        }

        // GET: Comments for a specific DiscussionId
        public async Task<IActionResult> Index(int discussionId)
        {
            var comments = await _context.Comment
                .Where(c => c.DiscussionId == discussionId) // Filter by DiscussionId
                .Include(c => c.Discussion)
                .OrderByDescending(c => c.CreateDate)
                .ToListAsync();

            ViewBag.DiscussionId = discussionId; // Store DiscussionId for back button
            return View(comments);
        }

        // GET: Comments/Create
        public IActionResult Create(int discussionId)
        {
            if (discussionId == 0)
            {
                return NotFound();
            }

            var comment = new Comment
            {
                DiscussionId = discussionId
            };

            return View(comment);
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,DiscussionId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                if (comment.DiscussionId == 0)
                {
                    return BadRequest("Discussion ID is required.");
                }

                comment.CreateDate = DateTime.Now;
                _context.Add(comment);
                await _context.SaveChangesAsync();

                // Redirect back to Comments page instead of GetDiscussion
                return RedirectToAction("Index", "Comments", new { discussionId = comment.DiscussionId });
            }

            return View(comment);
        }
    }
 }
