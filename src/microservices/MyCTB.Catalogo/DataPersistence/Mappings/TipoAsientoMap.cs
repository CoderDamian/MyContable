using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.DataPersistence.Mappings
{
    internal class TipoAsientoMap : IEntityTypeConfiguration<TipoAsiento>
    {
        public void Configure(EntityTypeBuilder<TipoAsiento> builder)
        {
            builder.ToTable("TIPOS_ASIENTOS", "CTB");

            builder.Property(p => p.Id)
                .HasColumnName("TIPO_ASIENTO_ID");

            builder.Property(p => p.Nombre)
                .HasColumnName("NOMBRE");

            builder.Property(p => p.Abreviatura)
                .HasColumnName("ABREVIATURA");

            builder.Property(p => p.EsActiva)
                .HasColumnName("ES_ACTIVA");

            builder.Property(p => p.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.Property(p => p.UpdatedBy)
                .HasColumnName("UPDATED_BY");

            builder.Property(p => p.UpdatedDate)
                .HasColumnName("UPDATED_DATE");
        }
    }
}
