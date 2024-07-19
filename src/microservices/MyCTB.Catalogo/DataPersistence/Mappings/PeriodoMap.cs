using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.DataPersistence.Mappings
{
    internal class PeriodoMap : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.ToTable("PERIODOS", "CTB");

            builder.Property(p => p.Id)
                .HasColumnName("PERIODO_ID");

            builder.Property(p => p.Nombre)
                .HasColumnName("NOMBRE");

            builder.Property(p => p.FechaInicial)
                .HasColumnName("FECHA_INICIAL");

            builder.Property(p => p.EsCerrado)
                .HasColumnName("ES_CERRADO");

            builder.Property(p => p.UpdatedDate)
                .HasColumnName("UPDATED_DATE");
        }
    }
}
