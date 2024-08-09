using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.DataPersistence.Mappings
{
    internal class SecuencialMap : IEntityTypeConfiguration<Secuencial>
    {
        public void Configure(EntityTypeBuilder<Secuencial> builder)
        {
            builder.ToTable("PERIODOS_TIPOS_ASIENTOS", "CTB");

            builder.Property(p => p.Id)
                .HasColumnName("PERIODO_TIPO_ASIENTO_ID");

            builder.Property(p => p.PeriodoFk)
                .HasColumnName("PERIODO_FK");

            builder.Property(p => p.TipoAsientoFk)
                .HasColumnName("TIPO_ASIENTO_FK");

            builder.Property(p => p.Secuencia)
                .HasColumnName("NUMERO_TIPO_ASIENTO");

            builder.Property(p => p.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.Property(p => p.UpdatedDate)
                .HasColumnName("UPDATED_DATE");

            builder.HasOne(s => s.Periodo).WithMany(p => p.SecuencialesTiposAsientos)
                .HasForeignKey(s => s.PeriodoFk);

            builder.HasOne(s => s.TipoAsiento).WithMany(t => t.SecuencialesTiposAsientos)
                .HasForeignKey(s => s.TipoAsientoFk);
        }
    }
}
