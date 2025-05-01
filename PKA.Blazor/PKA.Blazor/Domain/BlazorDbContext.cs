using Microsoft.EntityFrameworkCore;
using PKA.Blazor.Domain.EntityModels;
using PKA.Blazor.Domain.EntityModels.Base;

namespace PKA.Blazor.Domain
{
    public class BlazorDbContext(DbContextOptions<BlazorDbContext> options) : DbContext(options)
    {
        public DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlazorDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // add createdOn default value
            ChangeTracker
                .Entries()
                .Where(e => e is { Entity: BaseEntity<Guid>, State: EntityState.Added })
                .ToList().ForEach(entry =>
                {
                    (entry.Entity as BaseEntity<Guid>)!.CreatedOn = DateTime.Now;
                });

            // add deletedOn default value
            ChangeTracker
                .Entries()
                .Where(e => e is { Entity: BaseEntity<Guid>, State: EntityState.Modified })
                .ToList().ForEach(entry =>
                {
                    if ((entry.Entity as BaseEntity<Guid>)!.IsDeleted)
                    {
                        (entry.Entity as BaseEntity<Guid>)!.DeletedOn = DateTime.Now;
                    }
                });

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
