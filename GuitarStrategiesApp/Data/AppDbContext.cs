using Microsoft.EntityFrameworkCore;
using GuitarStrategiesApp.Models;
using GuitarStrategiesApp.ViewModels;

namespace GuitarStrategiesApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<LessonNote> LessonNotes { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=guitarstrategies.db");
        }
    }
}