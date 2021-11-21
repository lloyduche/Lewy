using Lewy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lewy.Infrastructure
{
    public class LewyContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public LewyContext(DbContextOptions options) : base(options)
        {
        }
    }
}
