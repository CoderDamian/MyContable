using MyCTB.Catalogo.BusinessDomain;

namespace MyCTB.Catalogo.ApplicationService
{
    internal interface IEjercicioRepository
    {
        Task<IEnumerable<Ejercicio>> Get_All_Async();

        //Task<IEnumerable<(int Id, string nombre)>> Get_Id_Name_Async();

        Task<Ejercicio?> Get_By_Id_Async(int id);

        Task<int> Update_Async(int id, string nombre, string user_name, DateTime? last_updated_date);
    }
}