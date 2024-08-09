using MyCTB.Catalogo.BusinessDomain;

namespace MyCTB.Catalogo.ApplicationService
{
    internal interface ITipoAsientoRepository
    {
        Task Add_Async(TipoAsiento tipoAsientoContable);

        Task<int> Delete_Async(int id, string updatedBy, DateTime? concurrencyToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="skip">number of rows to skip</param>
        /// <param name="take">number of rows to return</param>
        /// <returns></returns>
        Task<IEnumerable<TipoAsiento>> Get_All_Async(int skip, int take);
        
        Task<TipoAsiento?> Get_By_Id_Async(int id);

        void Update(TipoAsiento tipoAsientoContable);
    }
}