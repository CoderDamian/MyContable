using System.ComponentModel.DataAnnotations;

namespace MyCTB.Catalogo.BusinessDomain
{
    internal class TipoAsiento : MyEntity
    {
        internal string Nombre { get; private set; } = string.Empty;
        internal string Abreviatura { get; private set; } = string.Empty;
        internal bool EsActiva { get; private set; }
        public ICollection<Secuencial> SecuencialesTiposAsientos { get; set; }

        public TipoAsiento()
        {
            this.SecuencialesTiposAsientos = new List<Secuencial>();
        }

        public TipoAsiento(string nombre, string abreviatura, bool esActiva = true)
        {
            Set_Nombre(nombre);
            Set_Abreviatura(abreviatura);
            Set_EsActiva(esActiva);

            this.SecuencialesTiposAsientos = new List<Secuencial>();
        }

        public void Set_Abreviatura(string value)
        {
            this.Abreviatura = value;
        }

        public void Set_EsActiva(bool value)
        {
            this.EsActiva = value;
        }

        public void Set_Nombre(string value)
        {
            this.Nombre = value;
        }
    }
}