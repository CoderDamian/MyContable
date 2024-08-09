
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class Cuenta : MyEntity
    {
        internal CodigoContable? CodigoContable { get; private set; }
        internal string Nombre { get; private set; } = string.Empty;
        internal CodigoContable? CodigoContablePadre { get; private set; }
        internal bool EsActiva { get; private set; } = true;
        internal bool EsAuxiliar { get; private set; }
        internal Categoria? Categoria { get; private set; }

        protected Cuenta()
        {
            
        }

        public Cuenta(int id, CodigoContable codigo_Contable, string nombre, bool es_Auxiliar)
        {
            Set_Id(id);
            this.CodigoContable = codigo_Contable;
            this.Nombre = nombre;
            this.EsAuxiliar = es_Auxiliar;
        }

        public string Get_Next_Cuenta_Contable(string codigoContable)
        {
            bool sucess = Int32.TryParse(codigoContable.Replace(".", string.Empty), out int codigo);

            if (sucess)
            {
                codigo += 1;
            }

            return codigo.ToString();
        }

        public void Set_Codigo_Contable(string value)
        {
            var codigoContable = new CodigoContable(value);
            this.CodigoContable = codigoContable;
        }

        public void Set_Codigo_Contable_Padre(string value)
        {
            var codigoContable = new CodigoContable(value);
            this.CodigoContablePadre = codigoContable;
        }

        public void Set_Es_Auxiliar(bool value)
            => this.EsAuxiliar = value;
    }
}