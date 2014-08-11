using System.Data.Entity;

namespace Billboards.Models.EF
{
    public class BillboardContext : DbContext
    {
        public DbSet<BillboardE> Billboards { get; set; }
    }
}