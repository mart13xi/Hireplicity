using Microsoft.EntityFrameworkCore;

namespace Hireplicity.CodeChallenge.Api.Data
{
    public class HirepilicityDbContext : DbContext
    {
        public static readonly string Schema = "codechallenge";

        public HirepilicityDbContext(DbContextOptions<HirepilicityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schema);
        }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
