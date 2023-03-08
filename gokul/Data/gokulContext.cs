using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using gokul.Models;

namespace gokul.Data
{
    public class gokulContext : DbContext
    {
        public gokulContext (DbContextOptions<gokulContext> options)
            : base(options)
        {
        }

        public DbSet<gokul.Models.executive> executive { get; set; } = default!;

        public DbSet<gokul.Models.customer> customer { get; set; } = default!;

        public DbSet<gokul.Models.order> order { get; set; } = default!;
    }
}
