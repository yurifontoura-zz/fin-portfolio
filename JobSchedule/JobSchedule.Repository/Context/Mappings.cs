using JobSchedule.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSchedule.Repository.Context
{
    public static class Mappings
    {
        public static void Shop(EntityTypeBuilder<Shop> map)
        {
            map.ToTable("Shop");
            map.HasKey("ID");

            map.Property(s => s.ID).HasColumnName("ID").HasColumnType("int").IsRequired();
            map.Property(s => s.ID).HasColumnName("Name").HasColumnType("string").IsRequired();
            map.Property(s => s.ID).HasColumnName("Telephone").HasColumnType("string");
            map.Property(s => s.ID).HasColumnName("Address").HasColumnType("string");
        }
    }
}
