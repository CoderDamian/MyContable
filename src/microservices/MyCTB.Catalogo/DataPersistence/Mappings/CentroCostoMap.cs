using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.DataPersistence.Mappings
{
    internal class CentroCostoMap : IEntityTypeConfiguration<CentroCosto>
    {
        public void Configure(EntityTypeBuilder<CentroCosto> builder)
        {
            builder.ToTable("CENTRO_COSTOS", "CTB");

            builder.Property(p => p.Id)
                .HasColumnName("CENTRO_COSTO_ID");

            builder.Property(p => p.PadreId)
                .HasColumnName("CENTRO_COSTO_FK");

            builder.Property(p => p.Nombre)
                .HasColumnName("NOMBRE");

            builder.Property(p => p.EsAuxiliar)
                .HasColumnName("ES_AUXILIAR");

            builder.Property(p => p.Updated_Date)
                .HasColumnName("UPDATED_DATE");

            builder.Property(p => p.Updated_By)
                .HasColumnName("UPDATED_BY");
        }
    }
}
