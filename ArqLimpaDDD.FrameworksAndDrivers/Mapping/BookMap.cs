using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ArqLimpaDDD.Domain.Entities;

namespace ArqLimpaDDD.FrameWrkDrivers.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("book");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.title)
                .IsRequired(false)
                .HasColumnType("longtext");

            builder.HasOne(x => x.CreatedBy)
                .WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
