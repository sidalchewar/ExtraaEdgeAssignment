using ExtraaEdgeAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdgeAssignment.DBContext
{
    public class MobileDbContext : DbContext
    {

            public MobileDbContext(DbContextOptions<MobileDbContext> options) : base(options)
            {

            }

            // create category table with categories name inside data base
            public DbSet<MobileBrand> MobileBrands { get; set; }
            public DbSet<Mobile> Mobiles { get; set; }
            public DbSet<ExtraaEdgeAssignment.Models.MobileSales> MobileSales { get; set; } = default!;

    }
}
