using Microsoft.EntityFrameworkCore;
using MyCTB.Catalogo.ApplicationService;
using MyCTB.Catalogo.BusinessDomain;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Data;

namespace MyCTB.Catalogo.DataPersistence
{
    internal class CuentaRepository : ICuentaRepository
    {
        private readonly MyDbContext _myDbContext;

        public CuentaRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task Add_Cuenta_Async(string codigoContablePadre, string nombre, string createdBy)
        {
            var p_codigo_contable_padre = new OracleParameter("p_codigo_contable_padre", OracleDbType.NVarchar2, codigoContablePadre, ParameterDirection.Input);
            var p_nombre = new OracleParameter("p_nombre", OracleDbType.NVarchar2, nombre, ParameterDirection.Input);
            var p_created_by = new OracleParameter("p_created_by", OracleDbType.NVarchar2, createdBy, ParameterDirection.Input);

            await _myDbContext.Database.ExecuteSqlRawAsync("BEGIN ctb_cuenta_contable_pkg.add_cuenta(:p_codigo_contable_padre, :p_nombre, :p_created_by); END;", p_codigo_contable_padre, p_nombre, p_created_by).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Cuenta>> Get_Plan_Cuentas_Async(int offset, int fetch)
        {
            var connection = new OracleConnection(this._myDbContext.Database.GetDbConnection().ConnectionString);

            var command = new OracleCommand("ctb_cuenta_contable_pkg.get_plan_cuentas", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("p_cuentas", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
            command.Parameters.Add("p_offset", OracleDbType.Int32, offset, ParameterDirection.Input);
            command.Parameters.Add("p_fetch", OracleDbType.Int32, fetch, ParameterDirection.Input);

            await connection.OpenAsync().ConfigureAwait(false);

            var reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            ICollection<Cuenta> cuentas = new Collection<Cuenta>();

            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                cuentas.Add(new Cuenta(
                    id: reader.GetInt32(0),
                    codigo_Contable: new CodigoContable(reader.GetString(1)),
                    nombre: reader.GetString(3),
                    es_Auxiliar: reader.GetBoolean(4)));
            }

            await reader.CloseAsync();

            await connection.CloseAsync();

            return cuentas;
        }
    }
}