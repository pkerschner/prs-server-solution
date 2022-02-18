using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prs_server_project.Models {

    public class PrsDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }

        public PrsDbContext(DbContextOptions<PrsDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<User>(e => {
                e.HasIndex(p => p.Username).IsUnique(true);
            });
        }
    }
}
