using Domain.Entities;
using Domain.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class VisitBookerDbContext : IdentityDbContext<ApplicationUser>
    {
        public VisitBookerDbContext(DbContextOptions<VisitBookerDbContext> options) : base(options)
        {
        }

        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitType> VisitTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VisitBookerDbContext).Assembly);
        }
    }
}
