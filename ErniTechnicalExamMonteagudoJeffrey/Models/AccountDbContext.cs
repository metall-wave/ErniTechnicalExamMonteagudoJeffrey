using Microsoft.EntityFrameworkCore;

namespace ErniTechnicalExamMonteagudoJeffrey.Models
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext()
        {
        }

        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("data source=DESKTOP-KFEOOR5\\SQLEXPRESS;initial catalog=ErniDB;trusted_connection=true;TrustServerCertificate=True");
    }
}
