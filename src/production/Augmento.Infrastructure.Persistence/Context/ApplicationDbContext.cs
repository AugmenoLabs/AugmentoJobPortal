using Agumento.Core.Application.Interfaces;
using Agumento.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Augmento.Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<CandidateProfile> CandidateProfiles { get; set; }
        public DbSet<OpenPosition> OpenPositions { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<CandidateInterview> CandidateInterviews { get; set; }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
