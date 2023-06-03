using Lasmart.Models;
using Microsoft.EntityFrameworkCore;

namespace Lasmart.Data
{
    public class ApplicationContext : DbContext
    {
        private string dataSource = @"DESKTOP-O98QPDO\SQLEXPRESS";
        private string dataBase = "Lasmart";
        private string userName = "DESKTOP-O98QPDO\\User";
        private string connectionString;
        public DbSet<Point> Points { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.connectionString = @"Data Source=" + dataSource + ";Initial Catalog="
                        + dataBase + ";Persist Security Info=True;User ID=" + userName + ";Trusted_Connection=True;" + ";TrustServerCertificate=True;" + "Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasKey(c => new { c.PointId, c.CommentID });
            modelBuilder.Entity<Point>().HasMany(p => p.Comments).WithOne(c => c.Point).HasForeignKey(c => c.PointId);
        }
    }
}
