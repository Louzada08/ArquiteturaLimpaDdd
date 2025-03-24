using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArqLimpaDDD.Domain.Entities;

namespace ArqLimpaDDD.FrameWrkDrivers.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasIndex(u => u.Id)
                .IsUnique();
            builder.HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
