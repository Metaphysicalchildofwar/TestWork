using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestWork.Domain;

namespace TestWork.DAL.Configurations
{
    /// <summary>
    /// Конфигуратор набора данных для проектов
    /// </summary>
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        /// <summary>
        /// Конфигуратор набора данных
        /// </summary>
        /// <param name="entityTypeBuilder">Конструктор набора данных</param>
        public void Configure(EntityTypeBuilder<ProjectEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("ProjectTable");

            entityTypeBuilder.HasKey(m => m.Id);
            entityTypeBuilder.Property(m => m.Id).HasColumnName("ProjectId").IsRequired();

            entityTypeBuilder.Property(m => m.Name).HasColumnName("Name").IsRequired().HasMaxLength(20);
            entityTypeBuilder.Property(m => m.DateCreate).HasColumnName("DateCreate").IsRequired();
            entityTypeBuilder.Property(m => m.DateUpdate).HasColumnName("DateUpdate").IsRequired();
        }
    }
}
