using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CortexCommerce.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CortexCommerce.Repositorio.Configuracoes
{
    public class  HistoricoPesquisaConfiguration : IEntityTypeConfiguration<HistoricoPesquisa>
    {
        public void Configure(EntityTypeBuilder<HistoricoPesquisa> builder)
        {
            builder.ToTable("HistoricoPesquisas").HasKey(h => h.Id);;
            builder.Property(h => h.Pergunta).HasColumnName("Pergunta").HasMaxLength(500).IsRequired();
            builder.Property(h => h.RespostaGerada).HasColumnName("RespostaGerada").IsRequired();
            builder.Property(h => h.Data).HasColumnName("Data").IsRequired();
        }
    }
}