using MyCTB.Catalogo.BusinessDomain;

namespace MyCTB.Catalogo.ApplicationService
{
    internal interface ICuentaRepository
    {
        Task Add_Cuenta_Async(string codigoContablePadre, string nombre, string createdBy);

        Task<IEnumerable<Cuenta>> Get_PlanCuentas_Async(int offset = 0, int fetch = 50);
    }
}