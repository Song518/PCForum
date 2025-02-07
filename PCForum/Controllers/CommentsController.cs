using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PCForum.Data;
using PCForum.Models;

namespace PCForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly PCForumContext _context;

        public CommentsController(PCForumContext context)
        {
            _context = context;
        }

        // GET: Comment/Create
        public IActionResult Create(int discussionId)
        {
            ViewBag.DiscussionId = discussionId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,DiscussionId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreateDate = DateTime.Now;
                _context.Add(comment);
                await _context.SaveChangesAsync();

                // Redirect to the Discussion Details page
                return RedirectToAction("Details", "Discussion", new { id = comment.DiscussionId });
            }

            return View(comment);
        }
    }
}
