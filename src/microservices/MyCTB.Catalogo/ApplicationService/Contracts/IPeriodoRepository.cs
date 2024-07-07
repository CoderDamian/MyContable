using MyDTO.MyContabilidad;

namespace MyCTB.Catalogo.ApplicationService
{
    public interface IPeriodoRepository
    {
        Task Add_Async(string nombre, DateTime fechaInicial, Int16 numeroPeriodos, char longitud, string userName);

#warning los repositorios deben devolver entities o dtos ?       
        Task<IEnumerable<ListPeriodoDTO>> Get_All_Async();
    }
}