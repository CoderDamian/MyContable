
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class Categoria : MyEntity
    {
        internal UInt32 CategoriaPadreID { get; private set; }
        internal string Nombre { get; private set; } = string.Empty;

        protected Categoria()
        {
            
        }

        public Categoria(UInt32 categoriaPadre, string nombre)
        {
            this.CategoriaPadreID = categoriaPadre;
            this.Nombre = nombre;
        }
    }
}