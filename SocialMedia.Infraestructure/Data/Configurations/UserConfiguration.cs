using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;


namespace SocialMedia.Infraestructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Usuario");

            builder.Property(e => e.Id)
                    .HasColumnName("IdUsuario");

            builder.Property(e => e.Apellidos)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.FechaNacimiento).HasColumnType("date");

            builder.Property(e => e.Nombres)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
