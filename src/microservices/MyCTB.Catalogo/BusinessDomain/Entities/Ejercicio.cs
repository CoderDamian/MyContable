
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class Ejercicio : MyEntity
    {
        internal string Nombre { get; private set; } = string.Empty;
        internal bool? EsCerrado { get; private set; }

        public Ejercicio()
        {
            
        }

        public Ejercicio(string nombre)
        {
            Set_Nombre(nombre);
        }

        public void Set_Nombre(string value)
        {
            this.Nombre = value;
        }
    }
}
