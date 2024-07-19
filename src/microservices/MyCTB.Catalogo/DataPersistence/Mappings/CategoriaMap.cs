using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCTB.Catalogo.BusinessDomain;

namespace DataPersistence.Mappings
{
    internal class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIAS", "CTB");

            builder.Property(p => p.Id)
                .HasColumnName("CATEGORIA_ID");

            builder.Property(p => p.Nombre)
                .HasColumnName("NOMBRE");

            builder.Property(p => p.UpdatedDate)
                .HasColumnName("UPDATED_DATE");

            builder.Property(p => p.UpdatedBy)
                .HasColumnName("UPDATED_BY");
        }
    }
}
