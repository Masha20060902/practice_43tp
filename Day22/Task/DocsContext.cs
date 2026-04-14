using Microsoft.EntityFrameworkCore;
namespace Task
{
    public class DocsContext : DbContext
    {
        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<VersionEntity> Versions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=docs.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DocumentEntity>()
                .ToTable("Documents");

            modelBuilder.Entity<VersionEntity>()
                .ToTable("Versions")
                .HasOne(v => v.Document)
                .WithMany(d => d.Versions)
                .HasForeignKey(v => v.DocumentId);
        }
    }
}
