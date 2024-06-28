namespace MyCTB.Catalogo.BusinessDomain
{
    public class CodigoContable
    {
        public string Value { get; init; } = string.Empty;

        public CodigoContable()
        {
            
        }

        public CodigoContable(string value)
        {
            if (IsValueValid(value))
            {
                this.Value = value;
            }
            else
            {
                throw new ApplicationException(MyMessages.cuenta_contable_no_valida);
            }
        }

        private bool IsValueValid(string value)
        {
            return true;
        }
    }
}
