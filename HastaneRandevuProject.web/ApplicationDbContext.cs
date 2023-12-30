using HastaneRandevuProject.web.Data;
using HastaneRandevuProject.web.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Poliklinikler> Poliklinikler { get; set; }
    public DbSet<Randevu> Randevular { get; set; }
    public DbSet<Hasta> Hastalar { get; set; }
    public DbSet<CalismaGunleriVardiyalar> CalismaGunleriVardiyalar { get; set; }
    public DbSet<AnaBilimDali> AnaBilimDali { get; set; }
    public DbSet<Doktorlar> Doktorlar { get; set; }
    public DbSet<Kullanici> Kullanici { get; set;}
}