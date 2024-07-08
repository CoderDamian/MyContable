using Microsoft.EntityFrameworkCore;
using MyCTB.Catalogo.ApplicationService;
using MyCTB.Catalogo.BusinessDomain;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace MyCTB.Catalogo.DataPersistence
{
    internal class EjercicioRepository : IEjercicioRepository
    {
        private readonly MyDbContext _myDbContext;

        public EjercicioRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task<IEnumerable<Ejercicio>> Get_All_Async()
        {
            return await this._myDbContext.EjerciciosContables
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Ejercicio?> Get_By_Id_Async(int id)
        {
            return await this._myDbContext.EjerciciosContables.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<int> Update_Async(int id, string nombre, string user_name, DateTime? last_updated_date)
        {
            var p_id = new OracleParameter("p_id", OracleDbType.Int32, id, ParameterDirection.Input);
            var p_nombre = new OracleParameter("p_nombre", OracleDbType.NVarchar2, nombre, ParameterDirection.Input);
            var p_user_name = new OracleParameter("p_user_name", OracleDbType.NVarchar2, user_name, ParameterDirection.Input);
            var p_last_updated_date = new OracleParameter("p_last_updated_date", OracleDbType.TimeStamp, last_updated_date, ParameterDirection.Input);
            var p_affected_rows = new OracleParameter("p_affected_rows", OracleDbType.Int32, ParameterDirection.Output);

            await this._myDbContext.Database.ExecuteSqlRawAsync("BEGIN ejercicio_contable_pkg.update_ejercicio_contable (:p_id, :p_nombre, :p_user_name, :p_last_updated_date, :p_affected_rows); END;", p_id, p_nombre, p_user_name, p_last_updated_date, p_affected_rows);

            return Convert.ToInt32(p_affected_rows.Value.ToString());
        }
    }
}
