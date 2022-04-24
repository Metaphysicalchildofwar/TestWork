using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWork.Domain;

namespace TestWork.DAL.Configurations
{
    /// <summary>
    /// Конфигуратор набора данных для объектов проектирования
    /// </summary>
    public class DesignObjectEntityConfiguration : IEntityTypeConfiguration<DesignObjectEntity>
    {
        /// <summary>
        /// Конфигуратор набора данных
        /// </summary>
        /// <param name="entityTypeBuilder">Конструктор набора данных</param>
        public void Configure(EntityTypeBuilder<DesignObjectEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("DesignObjectTable");

            entityTypeBuilder.HasKey(m => m.Id);
            entityTypeBuilder.Property(m => m.Id).HasColumnName("DesignObjectId").IsRequired();

            entityTypeBuilder.Property(m => m.Name).HasColumnName("Name").IsRequired().HasMaxLength(20);
            entityTypeBuilder.Property(m => m.DateCreate).HasColumnName("DateCreate").IsRequired();
            entityTypeBuilder.Property(m => m.DateUpdate).HasColumnName("DateUpdate").IsRequired();

            entityTypeBuilder.Property(m => m.ProjectId).HasColumnName("ProjectId").IsRequired(false).HasDefaultValue(0);
            entityTypeBuilder.HasOne(m => m.Project).WithMany(m => m.DesignObjectEntity).HasForeignKey(k => k.ProjectId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
