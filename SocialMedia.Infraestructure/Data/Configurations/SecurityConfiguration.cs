﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("Seguridad");

            builder.Property(e => e.Id)
                    .HasColumnName("IdSeguridad");

            builder.Property(e => e.User)
                .HasColumnName("Usuario")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.UserName)
                .HasColumnName("NombreUsuario")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("Contrasena")
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Role)
                    .HasColumnName("Rol")
                    .HasMaxLength(15)
                    .IsRequired()
                    .HasConversion(x=> x.ToString(),
                                   x=> (RoleType)Enum.Parse(typeof(RoleType), x));
        }
    }
}
