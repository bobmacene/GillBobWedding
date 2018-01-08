using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GillBobWedding.Models
{
    public class GillBobWeddingContext : DbContext
    {
        public GillBobWeddingContext (DbContextOptions<GillBobWeddingContext> options)
            : base(options)
        {
        }

        public DbSet<RoleCall> RoleCall { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("ConnectionStrings:GillBobWeddingConString");
            optionsBuilder.UseSqlServer("ConnectionStrings:GillBobWeddingConString");
        }
    }
}
