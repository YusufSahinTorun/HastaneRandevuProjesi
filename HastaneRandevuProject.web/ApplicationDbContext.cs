using HastaneRandevuProject.web.Data;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<AnaBilimDali> AnaBilimDali { get; set; }
    public DbSet<Doktorlar> Doktorlar { get; set; }
    public DbSet<Kullanici> Kullanici { get; set;}
}