using Microsoft.EntityFrameworkCore;
using BandHub.Persistence.Entities;

namespace BandHub.Persistence;

public partial class BandHubContext : DbContext
{
    public BandHubContext(DbContextOptions<BandHubContext> options)
        : base(options)
    { }

    public virtual required DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasQueryFilter(entity => entity.DateDeleted == null);
    }
}
