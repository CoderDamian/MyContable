
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class Secuencial : MyEntity
    {
        internal int Periodo_Fk { get; private set; }
        internal int TipoAsiento_Fk { get; private set; }
        internal int Secuencia { get; private set; }
        internal Periodo Periodo { get; set; } = null!;
        internal TipoAsiento TipoAsiento { get; set; } = null!;

        public Secuencial()
        {
            
        }

        public Secuencial(int peridoFk, int tipoAsientoFk, int secuencial)
        {
            this.Periodo_Fk = peridoFk;
            this.TipoAsiento_Fk = tipoAsientoFk;
            this.Secuencia = secuencial;
        }
    }
}