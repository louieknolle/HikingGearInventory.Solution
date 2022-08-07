using Microsoft.EntityFrameworkCore;

namespace HikingGear.Models
{
  public class HikingGearContext : DbContext
  {
    public DbSet<Category> Categories { get; set; }
    public DbSet<Gear> Gears { get; set; }
    public DbSet<CategoryGear> CategoryGear { get; set; }

    public HikingGearContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
