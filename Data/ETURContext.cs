using Microsoft.EntityFrameworkCore;

namespace WebProject.Data
{
    public class ETURContext : DbContext
    {
        public ETURContext(DbContextOptions<ETURContext> options) : base(options) { }


        public DbSet<WebProject.Models.TopMenu> TopMenu { get; set; }
        public DbSet<WebProject.Models.Slider> Slider { get; set; }
        public DbSet<WebProject.Models.GenSetting> GenSetting { get; set; }
        public DbSet<WebProject.Models.News> News { get; set; }
        public DbSet<WebProject.Models.Announcement> Announcements { get; set; }
        public DbSet<WebProject.Models.FooterMenu> FooterMenu { get; set; }
        public DbSet<WebProject.Models.Management> Management { get; set; }
        public DbSet<WebProject.Models.Substructure> Substructure { get; set; }
        public DbSet<WebProject.Models.Articles> Articles { get; set; }
        public DbSet<WebProject.Models.Notification> Notification { get; set; }
        public DbSet<WebProject.Models.Project> Projects { get; set; }
        public DbSet<WebProject.Models.Users> Users { get; set; }
        public DbSet<WebProject.Models.Role> Role { get; set; }
        public DbSet<WebProject.Models.Language> Language { get; set; }
        public DbSet<WebProject.Models.Labs> Labs { get; set; }


    }
}