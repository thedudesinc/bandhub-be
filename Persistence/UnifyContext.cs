using Microsoft.EntityFrameworkCore;
using UnifyApi.Persistance.Entities;

namespace UnifyApi.Persistence;

public partial class UnifyContext : DbContext
{
    public UnifyContext(DbContextOptions<UnifyContext> options)
        : base(options)
    { }

    public virtual required DbSet<Widget> Widgets { get; set; }
    public virtual required DbSet<WidgetInstance> WidgetInstances { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Widget>().HasQueryFilter(entity => entity.DateDeleted == null);
        modelBuilder.Entity<WidgetInstance>().HasQueryFilter(entity => entity.DateDeleted == null);
    }
}
