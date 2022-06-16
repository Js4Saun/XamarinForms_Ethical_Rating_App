using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BeepBopAPI.Models;

namespace BeepBopAPI.Data
{
    public class BeepBopAPIContext : DbContext
    {
        public BeepBopAPIContext (DbContextOptions<BeepBopAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BeepBopAPI.Models.User> User { get; set; }

        public DbSet<BeepBopAPI.Models.Items> Items { get; set; }

        public DbSet<BeepBopAPI.Models.Review> Review { get; set; }
        public DbSet<BeepBopAPI.Models.ImageFile> ImageFile { get; set; }

    }
}
