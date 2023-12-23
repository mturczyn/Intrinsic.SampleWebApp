using Microsoft.EntityFrameworkCore;

namespace Intrinsic.SampleWebApp.DAL;

public class IntrinsicWebAppDbContext : DbContext
{
    public IntrinsicWebAppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Feedback> Feedbacks { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entity in ChangeTracker.Entries<Feedback>())
        {
            if (entity.State == EntityState.Added)
            {
                entity.Entity.Created = DateTimeOffset.UtcNow;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}