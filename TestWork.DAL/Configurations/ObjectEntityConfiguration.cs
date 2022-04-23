using TestWork.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestWork.DAL.Configurations
{
    /// <summary>
    /// Конфигуратор набора данных для объектов
    /// </summary>
    public class ObjectEntityConfiguration : IEntityTypeConfiguration<ObjectEntity>
    {
        /// <summary>
        /// Конфигуратор набора данных
        /// </summary>
        /// <param name="entityTypeBuilder">Конструктор набора данных</param>
        public void Configure(EntityTypeBuilder<ObjectEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Object");

            entityTypeBuilder.HasKey(m => m.Id);
            entityTypeBuilder.Property(m => m.Id).HasColumnName("ObjectId").IsRequired();

            entityTypeBuilder.Property(m => m.Name).HasColumnName("Name").IsRequired().HasMaxLength(20);
            entityTypeBuilder.Property(m => m.DateCreate).HasColumnName("DateCreate").IsRequired();
            entityTypeBuilder.Property(m => m.DateUpdate).HasColumnName("DateUpdate").IsRequired();

            entityTypeBuilder.Property(m => m.DesignObjectId).HasColumnName("ObjectId").IsRequired(false).HasDefaultValue(0);
            entityTypeBuilder.HasOne(m => m.DesignObject).WithMany(m => m.ObjectEntity).HasForeignKey(k => k.DesignObjectId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
