using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.DataPersistence.Mappings
{
    internal class EjercicioMap : IEntityTypeConfiguration<Ejercicio> 
    {
        public void Configure(EntityTypeBuilder<Ejercicio> builder)
        {
            builder.ToTable("EJERCICIOS_CONTABLES", "CTB");

            builder.Property(p => p.Id)
                .HasColumnName("EJERCICIO_CONTABLE_ID");

            builder.Property(p => p.Nombre)
                .HasColumnName("NOMBRE");

            builder.Property(p => p.Es_Cerrado)
                .HasColumnName("ES_CERRADO");

            builder.Property(p => p.CreatedBy)
                .HasColumnName("CREATED_BY");

            builder.Property(p => p.UpdatedDate)
                .HasColumnName("UPDATED_DATE");
        }
    }
}