using Microsoft.EntityFrameworkCore;

namespace BankBranchesMiniProject.Models
{

    public class BankContext : DbContext
    {
        public DbSet<BankBranch> BankBranches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=bank.dp");
    }
}
