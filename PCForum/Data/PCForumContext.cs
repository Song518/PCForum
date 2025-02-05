using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCForum.Models;

namespace PCForum.Data
{
    public class PCForumContext : DbContext
    {
        public PCForumContext (DbContextOptions<PCForumContext> options)
            : base(options)
        {
        }

        public DbSet<PCForum.Models.Comment> Comment { get; set; } = default!;
        public DbSet<PCForum.Models.Discussion> Discussion { get; set; } = default!;
    }
}
