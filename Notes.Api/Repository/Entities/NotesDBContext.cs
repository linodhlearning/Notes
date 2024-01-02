
using Microsoft.EntityFrameworkCore;
namespace Notes.Api.Repository.Entities
{
    public sealed class NotesDBContext : DbContext
    {
        public NotesDBContext(DbContextOptions<NotesDBContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            { 
                modelBuilder.Entity(entityType.Name).Property<DateTimeOffset>("CreatedDate"); 
                modelBuilder.Entity(entityType.Name).Property<DateTimeOffset>("UpdatedDate");
            }

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Note> Notes { get; set; }

        public override int SaveChanges()
        {
            var now = DateTimeOffset.Now;

            foreach (var changedEntity in ChangeTracker.Entries()
                         .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        changedEntity.Property("CreatedDate").CurrentValue = now;
                        changedEntity.Property("UpdatedDate").CurrentValue = now;
                        break;

                    case EntityState.Modified:
                        changedEntity.Property("UpdatedDate").CurrentValue = now;
                        break;
                }
            }

            int result = base.SaveChanges();

            foreach (var entity in ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }

            return result;
        }
    }
}
