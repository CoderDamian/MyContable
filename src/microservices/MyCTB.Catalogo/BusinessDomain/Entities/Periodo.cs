
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class Periodo : MyEntity
    {
        internal string Nombre { get; private set; } = string.Empty;
        internal DateTime FechaInicial { get; private set; }
        internal DateTime FechaFinal { get; private set; }
        internal bool EsCerrado { get; private set; }
        internal int EjercicioContableFk { get; private set; }
        internal ICollection<Secuencial> SecuencialesTiposAsientos { get; set; }

        public Periodo()
        {
            this.SecuencialesTiposAsientos = new List<Secuencial>();
        }

        public Periodo(string nombre, DateTime fechaInicial, DateTime fechaFinal, bool esCerrado)
        {
            Set_Nombre(nombre);
            Set_Fechas(fechaInicial, fechaFinal);
            Set_EsCerrado(esCerrado);

            this.SecuencialesTiposAsientos = new List<Secuencial>();
        }

        public void Set_EjercicioContable_Fk(int value)
            => this.EjercicioContableFk = value;

        public void Set_EsCerrado(bool value)
            => this.EsCerrado = value;

        public void Set_Fechas(DateTime fechaInicial, DateTime fechaFinal)
        {
            if (fechaFinal < fechaInicial)
            {
                throw new ApplicationException(MyMessages.periodo_fecha_final_menor_fecha_inicial);
            }
            else
            {
                this.FechaInicial = fechaInicial;
                this.FechaFinal = fechaFinal;
            }
        }

        public void Set_Nombre(string value)
            => this.Nombre = value;
    }
}