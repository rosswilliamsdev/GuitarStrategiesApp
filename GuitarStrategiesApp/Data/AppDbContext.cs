using Microsoft.EntityFrameworkCore;
using GuitarStrategiesApp.Models;

public class AppDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=guitarstrategies.db");
    }
}