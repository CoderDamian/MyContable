
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class CentroCosto : MyEntity
    {
        internal int? PadreId { get; private set; }
        internal string Nombre { get; private set; } = string.Empty;
        internal bool EsAuxiliar { get; private set; }
        
        public CentroCosto()
        {
            
        }

        public CentroCosto(int centroCostoPadre, string nombre, bool esAuxiliar)
        {
            Set_Centro_Costo_Padre(centroCostoPadre);
            Set_Nombre(nombre);
            Set_Es_Auxiliar(esAuxiliar);
        }

        public void Set_Centro_Costo_Padre(int value)
        {
            this.PadreId = value;
        }

        public void Set_Nombre(string value)
        {
            this.Nombre = value;
        }

        public void Set_Es_Auxiliar(bool value)
        {
            this.EsAuxiliar = value;
        }
    }
}