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
    }
}