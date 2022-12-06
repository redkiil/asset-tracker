using FleetApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace FleetApi.Data.EntitiesConfiguration
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            var options = new JsonSerializerOptions{};
            var converterPosition = new ValueConverter<Position, string>(
                v => JsonSerializer.Serialize<Position>(v, options),
                v => JsonSerializer.Deserialize<Position>(v, options)
             );
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Model).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ModelYear).IsRequired();
            builder.Property(p => p.EquipType).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Position).HasConversion(converterPosition).HasColumnType("JSON");
            builder.Property(p => p.Lastime).HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.EmployeeBadge).HasDefaultValue(9999);
            builder.Property(p => p.Data).HasColumnType("JSON");
            builder.HasOne<Employee>(e => e.Employee).WithMany(e => e.equipment);
            builder.HasOne<Group>(e => e.Group).WithMany(e => e.equipment);

        }
    }
}