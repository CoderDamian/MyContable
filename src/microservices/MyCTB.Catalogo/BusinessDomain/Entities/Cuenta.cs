
namespace MyCTB.Catalogo.BusinessDomain
{
    internal class Cuenta : MyEntity
    {
        internal CodigoContable? Codigo_Contable { get; private set; }
        internal string Nombre { get; private set; } = string.Empty;
        internal CodigoContable? Codigo_Contable_Padre { get; private set; }
        internal bool Es_Activa { get; private set; } = true;
        internal bool Es_Auxiliar { get; private set; }
        internal Categoria? Categoria { get; private set; }

        protected Cuenta()
        {
            
        }

        public Cuenta(int id, CodigoContable codigo_Contable, string nombre, bool es_Auxiliar)
        {
            Set_Id(id);
            this.Codigo_Contable = codigo_Contable;
            this.Nombre = nombre;
            this.Es_Auxiliar = es_Auxiliar;
        }

        public string Get_Next_CuentaContable(string codigoContable)
        {
            bool sucess = Int32.TryParse(codigoContable.Replace(".", string.Empty), out int codigo);

            if (sucess)
            {
                codigo += 1;
            }

            return codigo.ToString();
        }

        public void Set_CodigoContable(string value)
        {
            var codigoContable = new CodigoContable(value);
            this.Codigo_Contable = codigoContable;
        }

        public void Set_CodigoContablePadre(string value)
        {
            var codigoContable = new CodigoContable(value);
            this.Codigo_Contable_Padre = codigoContable;
        }

        public void Set_EsAuxiliar(bool value)
            => this.Es_Auxiliar = value;
    }
}