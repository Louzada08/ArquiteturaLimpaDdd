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

            builder.Property(u => u.UserName)
                .HasColumnType("varchar(50)")
                .IsRequired(false);
            builder.Property(u => u.FullName)
                .HasColumnType("varchar(100)")
                .IsRequired(false);
            builder.Property(u => u.Password)
                .HasColumnType("varchar(max)");
            builder.Property(u => u.RefreshToken)
                .HasColumnType("varchar(max)")
                .IsRequired(false);
            builder.Property(u => u.RefreshTokenExpiryTime)
                .HasColumnType("datetime")
                .IsRequired(true);
            builder.Property(u => u.createdat)
                .HasColumnType("datetime")
                .IsRequired(false);
            builder.Property(u => u.updatedat)
                .HasColumnType("datetime")
                .IsRequired(false);
            builder.Property(u => u.deletedat)
                .HasColumnType("datetime")
                .IsRequired(false);

            //builder.HasOne(x => x.CreatedBy)
            //    .WithMany().OnDelete(DeleteBehavior.NoAction);

        }
    }
}
