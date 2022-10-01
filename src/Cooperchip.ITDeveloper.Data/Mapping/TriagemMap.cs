using Cooperchip.ITDeveloper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cooperchip.ITDeveloper.Data.Mapping
{
    public class TriagemMap : IEntityTypeConfiguration<Triagem>
    {
        public void Configure(EntityTypeBuilder<Triagem> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(x => x.CodigoPaciente).IsRequired();
            builder.Property(x => x.NomePaciente).IsRequired().HasMaxLength(90).HasColumnType("varchar(90)");
            builder.Property(x => x.DataNotificacao).IsRequired();
            builder.Property(x => x.Mensagem).IsRequired().HasMaxLength(90).HasColumnType("varchar(90)");
        }
    }
}
