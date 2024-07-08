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

            builder.Property(p => p.Periodo_Fk)
                .HasColumnName("PERIODO_FK");

            builder.Property(p => p.TipoAsiento_Fk)
                .HasColumnName("TIPO_ASIENTO_FK");

            builder.Property(p => p.Secuencia)
                .HasColumnName("NUMERO_TIPO_ASIENTO");

            builder.Property(p => p.Created_By)
                .HasColumnName("CREATED_BY");

            builder.Property(p => p.Updated_Date)
                .HasColumnName("UPDATED_DATE");

            builder.HasOne(s => s.Periodo).WithMany(p => p.SecuencialesTiposAsientos)
                .HasForeignKey(s => s.Periodo_Fk);

            builder.HasOne(s => s.TipoAsiento).WithMany(t => t.SecuencialesTiposAsientos)
                .HasForeignKey(s => s.TipoAsiento_Fk);
        }
    }
}
