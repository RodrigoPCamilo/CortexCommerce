using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CortexCommerce.Repositorio.Configuracoes
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios").HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").HasMaxLength(150).IsRequired();
            builder.Property(u => u.SenhaHash).HasColumnName("SenhaHash").HasMaxLength(150).IsRequired();
            builder.Property(u => u.CategoriaFavorita).HasColumnName("CategoriaFavorita").HasMaxLength(200);
            builder.Property(u => u.LojaPreferida).HasColumnName("LojaPreferida").HasMaxLength(200);
            builder.Property(u => u.OrcamentoMedio).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(u => u.DataCriacao).HasColumnName("DataCriacao").IsRequired();

            builder.HasMany(u => u.HistoricoPesquisa)
                   .WithOne(h => h.Usuario)
                   .HasForeignKey(h => h.UsuarioId);

        }
    }
}