
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class Partida : MyEntity
    {
        internal int CentroCosto_FK { get; private set; }
        internal int CodigoContable_FK { get; private set; }
        internal string Glosa { get; private set; } = string.Empty;
        internal bool EsDebe  { get; private set; }
        internal double Monto { get; private set; }

        public Partida()
        {
            
        }

        public Partida(int codigoContable, string glosa, bool esDebe, double monto, int centroCostoFk)
        {
            Set_CodigoContable(codigoContable);
            Set_Glosa(glosa);
            Set_EsDebe(esDebe);
            Set_Monto(monto);
            Set_CentroCosto(centroCostoFk);
        }

        #region Setters
        public void Set_CentroCosto(int value)
        {
            this.CentroCosto_FK = value;
        }

        public void Set_CodigoContable(int value)
        {
            this.CodigoContable_FK = value;
        }

        public void Set_EsDebe(bool value)
        {
            this.EsDebe = value;
        }

        public void Set_Glosa(string glosa)
        {
            this.Glosa = glosa;
        }

        public void Set_Monto(double value)
        {
            this.Monto = value;
        }
        #endregion
    }
}