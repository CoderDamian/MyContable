using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCTB.Catalogo.BusinessDomain;

namespace MyContabilidad.DataPersistence.Mappings
{
    internal class CuentaMap : IEntityTypeConfiguration<Cuenta>
    {
        public void Configure(EntityTypeBuilder<Cuenta> builder)
        {
            builder.ToTable("CUENTAS_CONTABLES", "CTB");

            builder.Property(p => p.Id)
                .HasColumnName("CUENTA_CONTABLE_ID");

            // Setting the value object
            builder.OwnsOne(p => p.Codigo_Contable)
                .Property(p => p.Value).HasColumnName("CODIGO_CONTABLE");

            builder.OwnsOne(p => p.Codigo_Contable_Padre)
                .Property(p => p.Value).HasColumnName("CODIGO_CONTABLE_PADRE");

            builder.Property(p => p.Nombre)
                .HasColumnName("NOMBRE");

            builder.Property(p => p.Es_Activa)
                .HasColumnName("ES_ACTIVA");

            builder.Property(p => p.Es_Auxiliar)
                .HasColumnName("ES_AUXILIAR");
        }
    }
}