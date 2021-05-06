using Microsoft.EntityFrameworkCore;

namespace WebProject.Data
{
    public class ETURContext : DbContext
    {
        public ETURContext(DbContextOptions<ETURContext> options) : base(options) { }


        public DbSet<WebProject.Models.UstMenu> UstMenu { get; set; }
    }
}