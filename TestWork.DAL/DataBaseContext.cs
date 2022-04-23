using TestWork.DAL.Configurations;
using TestWork.Domain;
using Microsoft.EntityFrameworkCore;

namespace TestWork.DAL
{
    /// <summary>
    /// Контекст доступа к данным
    /// </summary>
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DesignObjectEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ObjectEntityConfiguration());
        }

        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<DesignObjectEntity> DesignObjects { get; set; }
        public DbSet<ObjectEntity> Objects { get; set; }
    }
}
