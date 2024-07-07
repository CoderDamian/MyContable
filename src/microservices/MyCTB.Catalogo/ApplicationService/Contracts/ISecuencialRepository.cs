using MyCTB.Catalogo.BusinessDomain;
using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    internal interface ISecuencialRepository
    {
        Task Add_Async(Secuencial secuencial);

        Task<IEnumerable<ListSecuencialDTO>> Gell_All_Async();
    }
}