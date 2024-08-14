using Microsoft.EntityFrameworkCore;
using MyCTB.Catalogo.ApplicationService;
using MyCTB.Catalogo.BusinessDomain;
using MyDTO.MyContabilidad;
using Oracle.ManagedDataAccess.Client;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Text;

namespace MyCTB.Catalogo.DataPersistence
{
    internal class CentroCostoRepository : ICentroCostoRepository
    {
        private readonly MyDbContext _myDbContext;

        public CentroCostoRepository(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext ?? throw new ArgumentNullException(nameof(myDbContext));
        }

        public async Task Add_Async(int centroCostoPadreId, string nombre, string userName)
        {
            var p_centro_costo_padre = new OracleParameter("p_centro_costo_padre", OracleDbType.Int32, centroCostoPadreId, ParameterDirection.Input);
            var p_nombre = new OracleParameter("p_nombre", OracleDbType.NVarchar2, nombre, ParameterDirection.Input);
            var p_created_by = new OracleParameter("p_created_by", OracleDbType.NVarchar2, userName, ParameterDirection.Input);

            await _myDbContext.Database.ExecuteSqlRawAsync("BEGIN ctb_centro_costo_pkg.add_new (:p_centro_costo_padre, :p_nombre, :p_created_by); END;", p_centro_costo_padre, p_nombre, p_created_by).ConfigureAwait(false);
        }

        public async Task Delete_Async(int id, string updatedBy, DateTime? concurrency_token)
        {
            var p_centro_costo_id = new OracleParameter("p_centro_costo_id", OracleDbType.Int32, id, ParameterDirection.Input);
            var p_updated_by = new OracleParameter("p_updated_by", OracleDbType.NVarchar2, updatedBy, ParameterDirection.Input);
            var p_concurrency_token = new OracleParameter("p_concurrency_token", OracleDbType.TimeStamp, concurrency_token, ParameterDirection.Input);
            var p_rows_affected = new OracleParameter("p_rows_affected", OracleDbType.Int32, ParameterDirection.Output);

            await this._myDbContext.Database.ExecuteSqlRawAsync("BEGIN ctb_centro_costo_pkg.delete_by_id(:p_centro_costo_id, :p_updated_by, :p_concurrency_token, :p_rows_affected); END;", p_centro_costo_id, p_updated_by, p_concurrency_token, p_rows_affected).ConfigureAwait(false);

            if (p_rows_affected.Value.ToString() == "0")
                throw new DbUpdateConcurrencyException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CentroCosto>> Get_All_Async()
        {
            using var oracleConnection = new OracleConnection(this._myDbContext.Database.GetDbConnection().ConnectionString);

            //setting the procedure
            OracleCommand command = new("ctb_centro_costo_pkg.get_all", oracleConnection);
            command.CommandType = CommandType.StoredProcedure;

            // setting the parameters
            command.Parameters.Add("p_result", OracleDbType.RefCursor, ParameterDirection.ReturnValue);

            await oracleConnection.OpenAsync().ConfigureAwait(false);

            DbDataReader dataReader = await command.ExecuteReaderAsync().ConfigureAwait(false);

            Collection<CentroCosto> centrosCostosDTOs = new Collection<CentroCosto>();

            int nivel = 0;
            string space;

            while (await dataReader.ReadAsync().ConfigureAwait(false))
            {
                nivel = dataReader.GetInt32("level");
                space = new string(' ', nivel);

                centrosCostosDTOs.Add(
                        new CentroCosto(
                            centroCostoPadre: dataReader.GetInt32("centro_costo_id"), 
                            nombre: String.Concat(space, dataReader.GetString("centro_costo")), 
                            esAuxiliar: dataReader.GetBoolean("es_auxiliar")));
            }

            await dataReader.CloseAsync();

            await oracleConnection.CloseAsync();

            return centrosCostosDTOs;
        }

        public async Task<CentroCosto?> Get_By_Id_Async(int id)
        {
            return await _myDbContext.CentrosCostos
                .FindAsync(id)
                .ConfigureAwait(false);
        }

        public void Update(CentroCosto centroCosto)
        {
            //this._myDbContext.CentrosCostos.Update(centroCosto);

            this._myDbContext.Attach(centroCosto);
            this._myDbContext.Entry(centroCosto).Property(p => p.Nombre).IsModified = true;
            this._myDbContext.Entry(centroCosto).Property(p => p.UpdatedBy).IsModified = true;
        }
    }
}