using Cooperchip.ITDeveloper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperchip.ITDeveloper.Data.Mapping
{
    public class EstadoPacienteMap : IEntityTypeConfiguration<EstadoPaciente>
    {
        public void Configure(EntityTypeBuilder<EstadoPaciente> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Descricao).HasColumnType("varchar(30)")
                .HasColumnName("Descricao");

            // Este relacionamento já foi 
            // estabelecido em PacienteMapping
            builder.HasMany(p => p.Paciente);

            builder.ToTable("EstadoPaciente");

        }
    }
}