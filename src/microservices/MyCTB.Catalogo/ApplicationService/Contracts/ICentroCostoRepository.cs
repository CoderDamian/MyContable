using MyCTB.Catalogo.BusinessDomain;

namespace MyCTB.Catalogo.ApplicationService
{
    internal interface ICentroCostoRepository
    {
        Task Add_Async(int centroCostoPadreId, string nombre, string userName);

        Task Delete_Async(int id, string updatedBy, DateTime? concurrency_token);
        
        Task<IEnumerable<CentroCosto>> GetAllAsync();
        
        Task<CentroCosto?> Get_By_Id_Async(int id);
        
        void Update(CentroCosto centroCosto);
    }
}