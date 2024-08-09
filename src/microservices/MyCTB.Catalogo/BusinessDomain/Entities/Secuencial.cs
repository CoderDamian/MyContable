
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class Secuencial : MyEntity
    {
        internal int PeriodoFk { get; private set; }
        internal int TipoAsientoFk { get; private set; }
        internal int Secuencia { get; private set; }
        internal Periodo Periodo { get; set; } = null!;
        internal TipoAsiento TipoAsiento { get; set; } = null!;

        public Secuencial()
        {
            
        }

        public Secuencial(int peridoFk, int tipoAsientoFk, int secuencial)
        {
            this.PeriodoFk = peridoFk;
            this.TipoAsientoFk = tipoAsientoFk;
            this.Secuencia = secuencial;
        }
    }
}