using FleetApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FleetApi.Data.EntitiesConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(p => p.Badge);
            builder.HasAlternateKey(p => p.Id);
            builder.Property(p => p.Badge).ValueGeneratedNever();
            builder.Property(p => p.Name).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}